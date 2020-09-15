import React, { useState, useEffect } from "react";
import API from "../services/API.js";

const ProjectItem = (props) => {
  const [itemClass, setItemClass] = useState("item");
  const [detailsDisplay, setDetailsDisplay] = useState("none");
  const [name, setName] = React.useState(props.project.name);
  const [description, setDescription] = React.useState(
    props.project.description
  );
  const [client, setClient] = React.useState(props.project.clientID);
  const [lead, setLead] = React.useState(props.project.leadID);
  const [status, setStatus] = React.useState(props.project.status);
  const [id, setId] = React.useState(props.project.id);
  const clientOptions = props.clients;
  const leadOptions = props.users;

  const handleItemClick = () => {
    if (itemClass === "item") {
      setItemClass("item open");
      setDetailsDisplay("block");
    } else {
      setItemClass("item");
      setDetailsDisplay("none");
    }
  };

  const statusToBoolean = (statusCheck) => {
    if (statusCheck === status) return true;
    return false;
  };

  const handleChangeStatus = (event) => {
    if (event.target.checked) setStatus(event.target.id);
  };

  const clientOptionsList = clientOptions.map((opt) => (
    <option key={opt.id} value={opt.id}>
      {opt.name}
    </option>
  ));

  const leadOptionsList = leadOptions.map((opt) => (
    <option key={opt.id} value={opt.id}>
      {opt.name}
    </option>
  ));

  const saveSubmit = () => {
    let project = {
      id: id,
      name: name,
      description: description,
      clientID: parseInt(client),
      leadID: parseInt(lead),
      status: status,
    };
    API.put("/project", project)
      .then((response) => {
        console.log(response.data);
        props.setRefresh(!props.refresh);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const deleteSubmit = () => {
    API.put("/project/" + id)
      .then((response) => {
        console.log(response.data);
        props.setRefresh(!props.refresh);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <div className={itemClass}>
      <div className="heading" onClick={handleItemClick}>
        <span>{props.project.name}</span>{" "}
        <span>
          <em>({client})</em>
        </span>
        <i>+</i>
      </div>
      <div className="details" style={{ display: detailsDisplay }}>
        <ul className="form">
          <li>
            <label>Project name:</label>
            <input
              type="text"
              className="in-text"
              value={name}
              onChange={(event) => setName(event.target.value)}
            />
          </li>
          <li>
            <label>Lead:</label>
            <select
              value={lead}
              onChange={(event) => setLead(event.target.value)}
            >
              {leadOptionsList}
            </select>
          </li>
        </ul>
        <ul className="form">
          <li>
            <label>Description:</label>
            <input
              type="text"
              className="in-text"
              value={description}
              onChange={(event) => setDescription(event.target.value)}
            />
          </li>
        </ul>
        <ul className="form last">
          <li>
            <label>Customer:</label>
            <select
              value={client}
              onChange={(event) => setClient(event.target.value)}
            >
              {clientOptionsList}
            </select>
          </li>
          <li className="inline">
            <label>Status:</label>
            <span className="radio">
              <label for="active">Active:</label>
              <input
                type="radio"
                value="1"
                name={"status-" + id}
                id="active"
                checked={statusToBoolean("active")}
                onChange={handleChangeStatus}
              />
            </span>
            <span className="radio">
              <label for="inactive">Inactive:</label>
              <input
                type="radio"
                value="2"
                name={"status-" + id}
                id="inactive"
                checked={statusToBoolean("inactive")}
                onChange={handleChangeStatus}
              />
            </span>
            <span className="radio">
              <label for="archived">Archive:</label>
              <input
                type="radio"
                value="3"
                name={"status-" + id}
                id="archived"
                checked={statusToBoolean("archived")}
                onChange={handleChangeStatus}
              />
            </span>
          </li>
        </ul>
        <div className="buttons">
          <div className="inner">
            <a href="javascript:;" className="btn green" onClick={saveSubmit}>
              Save
            </a>
            <a href="javascript:;" className="btn red" onClick={deleteSubmit}>
              Delete
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProjectItem;
