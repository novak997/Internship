import React, { useState, useEffect } from "react";
import API from "../services/API.js";

const NewMember = (props) => {
  const [name, setName] = React.useState("");
  const [username, setUsername] = React.useState("");
  const [weekly, setWeekly] = React.useState("");
  const [email, setEmail] = React.useState("");
  const [isActive, setIsActive] = React.useState(true);
  const [isAdmin, setIsAdmin] = React.useState(true);

  const submitForm = () => {
    let user = {
      name: name,
      username: username,
      email: email,
      weekly: parseFloat(weekly),
      isActive: isActive,
      isAdmin: isAdmin,
    };
    API.post("/user", user)
      .then((response) => {
        console.log(response.data);
        props.setRefresh(!props.refresh);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <div class="new-member-wrap">
      <div id="new-member" class="new-member-inner">
        <h2>Create new team member</h2>
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
          <li class="inline">
            <label>Status:</label>
            <span class="radio">
              <label for="inactive">Inactive:</label>
              <input
                type="radio"
                value="1"
                name="status"
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
                name="status"
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
                name="role"
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
                name="role"
                id="user"
                checked={!isAdmin}
                onChange={(event) => setIsAdmin(!isAdmin)}
              />
            </span>
          </li>
        </ul>
        <div class="buttons">
          <div class="inner">
            <a href="javascript:;" class="btn green" onClick={submitForm}>
              Invite team member
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default NewMember;
