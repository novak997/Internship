import React, { useState, useEffect } from "react";
import API from "../services/API.js";

const MemberItem = (props) => {
  const [itemClass, setItemClass] = useState("item");
  const [detailsDisplay, setDetailsDisplay] = useState("none");
  const [name, setName] = React.useState(props.user.name);
  const [username, setUsername] = React.useState(props.user.username);
  const [weekly, setWeekly] = React.useState(props.user.weekly);
  const [email, setEmail] = React.useState(props.user.email);
  const [isActive, setIsActive] = React.useState(props.user.isActive);
  const [isAdmin, setIsAdmin] = React.useState(props.user.isAdmin);

  const handleItemClick = () => {
    if (itemClass === "item") {
      setItemClass("item open");
      setDetailsDisplay("block");
    } else {
      setItemClass("item");
      setDetailsDisplay("none");
    }
  };

  const saveSubmit = () => {
    let user = {
      id: props.user.id,
      name: name,
      username: username,
      email: email,
      weekly: parseFloat(weekly),
      isActive: isActive,
      isAdmin: isAdmin,
    };
    API.put("/user", user)
      .then((response) => {
        console.log(response.data);
        props.setRefresh(!props.refresh);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const deleteSubmit = () => {
    API.put("/user/" + props.user.id)
      .then((response) => {
        console.log(response.data);
        props.setRefresh(!props.refresh);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <div class={itemClass}>
      <div class="heading" onClick={handleItemClick}>
        <span>{name}</span>
        <i>+</i>
      </div>
      <div class="details" style={{ display: detailsDisplay }}>
        <ul class="form">
          <li>
            <label>Name:</label>
            <input
              type="text"
              class="in-text"
              value={name}
              onChange={(event) => setName(event.target.value)}
            />
          </li>
          <li>
            <label>Hours per week:</label>
            <input
              type="text"
              class="in-text"
              value={weekly}
              onChange={(event) => setWeekly(event.target.value)}
            />
          </li>
        </ul>
        <ul class="form">
          <li>
            <label>Username:</label>
            <input
              type="text"
              class="in-text"
              value={username}
              onChange={(event) => setUsername(event.target.value)}
            />
          </li>
          <li>
            <label>Email:</label>
            <input
              type="text"
              class="in-text"
              value={email}
              onChange={(event) => setEmail(event.target.value)}
            />
          </li>
        </ul>
        <ul class="form last">
          <li class="inline">
            <label>Status:</label>
            <span class="radio">
              <label for="inactive">Inactive:</label>
              <input
                type="radio"
                value="1"
                name={"status-" + username}
                id="inactive"
                checked={!isActive}
                onChange={(event) => setIsActive(!isActive)}
              />
            </span>
            <span class="radio">
              <label for="active">Active:</label>
              <input
                type="radio"
                value="2"
                name={"status-" + username}
                id="active"
                checked={isActive}
                onChange={(event) => setIsActive(!isActive)}
              />
            </span>
          </li>
          <li class="inline">
            <label>Role:</label>
            <span class="radio">
              <label for="admin">Admin:</label>
              <input
                type="radio"
                value="1"
                name={"role-" + username}
                id="admin"
                checked={isAdmin}
                onChange={(event) => setIsAdmin(!isAdmin)}
              />
            </span>
            <span class="radio">
              <label for="worker">Worker:</label>
              <input
                type="radio"
                value="2"
                name={"role-" + username}
                id="user"
                checked={!isAdmin}
                onChange={(event) => setIsAdmin(!isAdmin)}
              />
            </span>
          </li>
        </ul>
        <div class="buttons">
          <div class="inner">
            <a href="javascript:;" class="btn green" onClick={saveSubmit}>
              Save
            </a>
            <a href="javascript:;" class="btn red" onClick={deleteSubmit}>
              Delete
            </a>
            <a href="javascript:;" class="btn orange">
              Reset Password
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default MemberItem;
