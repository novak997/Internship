import React, { useState, useEffect } from "react";
import API from "../services/API.js";

const NewProject = (props) => {
  const [name, setName] = React.useState("");
  const [description, setDescription] = React.useState("");
  const [client, setClient] = React.useState("");
  const [lead, setLead] = React.useState("");
  const clientOptions = props.clients;
  const leadOptions = props.users;

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

  const submitForm = () => {
    var clientID = client;
    if (clientID === "") clientID = clientOptions[0].id;
    var leadID = lead;
    if (leadID === "") leadID = leadOptions[0].id;

    let project = {
      name: name,
      description: description,
      clientID: parseInt(clientID),
      leadID: parseInt(leadID),
    };
    API.post("/project", project)
      .then((response) => {
        console.log(response.data);
        props.setRefresh(!props.refresh);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <div className="new-member-wrap">
      <div id="new-member" className="new-member-inner">
        <h2>Create new project</h2>
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
            <label>Description:</label>
            <input
              type="text"
              className="in-text"
              value={description}
              onChange={(event) => setDescription(event.target.value)}
            />
          </li>
          <li>
            <label>Customer:</label>
            <select
              value={client}
              onChange={(event) => setClient(event.target.value)}
            >
              {clientOptionsList}
            </select>
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
        <div className="buttons">
          <div className="inner">
            <a href="javascript:;" className="btn green" onClick={submitForm}>
              Save
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default NewProject;
