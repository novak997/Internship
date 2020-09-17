import React, { useState, useEffect } from "react";
import API from "../services/API.js";
import addDays from "date-fns/addDays";

const NewWorktime = (props) => {
  const [client, setClient] = React.useState("");
  const [project, setProject] = React.useState("");
  const [category, setCategory] = React.useState("");
  const [description, setDescription] = React.useState("");
  const [hours, setHours] = React.useState("");
  const [overtime, setOvertime] = React.useState("");
  const [projectOptionsList, setProjectOptionsList] = React.useState([]);
  const clientOptions = props.clients;
  const categoryOptions = props.categories;

  const clientOptionsList = clientOptions.map((opt) => (
    <option key={opt.id} value={opt.id}>
      {opt.name}
    </option>
  ));

  const categoryOptionsList = categoryOptions.map((opt) => (
    <option key={opt.id} value={opt.id}>
      {opt.name}
    </option>
  ));

  const handleSelectChangeClient = (event) => {
    setClient(event.target.value);
    setProject("");
    //let projects = [];
    API.get("/project/client/" + event.target.value)
      .then((response) => {
        console.log(response.data);
        setProjectOptionsList(
          response.data.map((opt) => (
            <option key={opt.id} value={opt.id}>
              {opt.name}
            </option>
          ))
        );
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const handleSelectChangeProject = (event) => {
    setProject(event.target.value);
    if (client !== "" && category !== "" && hours !== "")
      addWorktime(client, event.target.value, category, hours);
  };

  const handleSelectChangeCategory = (event) => {
    setCategory(event.target.value);
    if (client !== "" && project !== "" && hours !== "")
      addWorktime(client, project, event.target.value, hours);
  };

  const handleSelectChangeHours = (event) => {
    setHours(event.target.value);
    if (client !== "" && project !== "" && category !== "")
      addWorktime(client, project, category, event.target.value);
  };

  const addWorktime = (client, project, category, hours) => {
    let overtimeLocal = overtime;
    if (overtimeLocal === "") overtimeLocal = 0;
    let worktime = {
      userID: props.user,
      clientID: parseInt(client),
      projectID: parseInt(project),
      categoryID: parseInt(category),
      description: description,
      hours: parseFloat(hours),
      overtime: parseFloat(overtimeLocal),
      date: addDays(props.day, 1),
    };
    API.post("/worktime", worktime)
      .then((response) => {
        console.log(response.data);
        props.setRefresh(!props.refresh);
        setClient("");
        setProject("");
        setCategory("");
        setDescription("");
        setHours("");
        setOvertime("");
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <tr key={props.key}>
      <td>
        <select value={client} onChange={handleSelectChangeClient}>
          <option value="" disabled selected>
            Choose client
          </option>
          {clientOptionsList}
        </select>
      </td>
      <td>
        <select value={project} onChange={handleSelectChangeProject}>
          <option value="" disabled selected>
            Choose project
          </option>
          {projectOptionsList}
        </select>
      </td>
      <td>
        <select value={category} onChange={handleSelectChangeCategory}>
          <option value="" disabled selected>
            Choose category
          </option>
          {categoryOptionsList}
        </select>
      </td>
      <td>
        <input
          type="text"
          class="in-text medium"
          value={description}
          onChange={(event) => setDescription(event.target.value)}
        />
      </td>
      <td class="small">
        <input
          type="text"
          class="in-text xsmall"
          value={hours}
          onChange={handleSelectChangeHours}
        />
      </td>
      <td class="small">
        <input
          type="text"
          class="in-text xsmall"
          value={overtime}
          onChange={(event) => setOvertime(event.target.value)}
        />
      </td>
    </tr>
  );
};

export default NewWorktime;
