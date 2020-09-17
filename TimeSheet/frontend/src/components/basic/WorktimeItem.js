import React, { useState, useEffect } from "react";
import API from "../services/API.js";

const WorktimeItem = (props) => {
  const [client, setClient] = React.useState(props.worktime.clientID);
  const [project, setProject] = React.useState(props.worktime.projectID);
  const [category, setCategory] = React.useState(props.worktime.categoryID);
  const [description, setDescription] = React.useState(
    props.worktime.description
  );
  const [hours, setHours] = React.useState(props.worktime.hours);
  const [overtime, setOvertime] = React.useState(props.worktime.overtime);
  const [projectOptionsList, setProjectOptionsList] = React.useState([]);
  const clientOptions = props.clients;
  const categoryOptions = props.categories;

  useEffect(() => {
    API.get("/project/client/" + props.worktime.clientID)
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
  }, []);

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
      updateWorktime(
        client,
        event.target.value,
        category,
        hours,
        description,
        overtime
      );
  };

  const handleSelectChangeCategory = (event) => {
    setCategory(event.target.value);
    if (client !== "" && project !== "" && hours !== "")
      updateWorktime(
        client,
        project,
        event.target.value,
        hours,
        description,
        overtime
      );
  };

  const handleSelectChangeHours = (event) => {
    setHours(event.target.value);
    if (client !== "" && project !== "" && category !== "")
      updateWorktime(
        client,
        project,
        category,
        event.target.value,
        description,
        overtime
      );
  };

  const handleSelectChangeDescription = (event) => {
    setDescription(event.target.value);
    if (client !== "" && project !== "" && category !== "")
      updateWorktime(
        client,
        project,
        category,
        hours,
        event.target.value,
        overtime
      );
  };

  const handleSelectChangeOvertime = (event) => {
    setOvertime(event.target.value);
    if (client !== "" && project !== "" && category !== "")
      updateWorktime(
        client,
        project,
        category,
        hours,
        description,
        event.target.value
      );
  };

  const updateWorktime = (
    client,
    project,
    category,
    hours,
    description,
    overtime
  ) => {
    let overtimeLocal = overtime;
    if (overtimeLocal === "") overtimeLocal = 0;
    let worktime = {
      clientID: parseInt(client),
      projectID: parseInt(project),
      categoryID: parseInt(category),
      description: description,
      hours: parseFloat(hours),
      overtime: parseFloat(overtimeLocal),
      id: props.worktime.id,
    };
    API.put("/worktime", worktime)
      .then((response) => {
        console.log(response.data);
        props.setRefresh(!props.refresh);
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
          onChange={handleSelectChangeDescription}
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
          onChange={handleSelectChangeOvertime}
        />
      </td>
    </tr>
  );
};

export default WorktimeItem;
