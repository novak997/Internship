import React, { useState, useEffect } from "react";
import API from "../services/API.js";

import ProjectItem from "./ProjectItem";

const ViewProjects = (props) => {
  return (
    <div className="accordion-wrap projects">
      {props.projects.map((p) => (
        <ProjectItem
          project={p}
          clients={props.clients}
          users={props.users}
          refresh={props.refresh}
          setRefresh={props.setRefresh}
          key={p.id}
        />
      ))}
    </div>
  );
};

export default ViewProjects;
