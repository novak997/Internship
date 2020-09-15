import React, { useState, useEffect } from "react";
import API from "../services/API.js";
import ViewProjects from "../basic/ViewProjects";
import Letters from "../basic/Letters";
import NewProject from "../basic/NewProject";
import Search from "../basic/Search";

const Projects = (props) => {
  const [projects, setProjects] = React.useState([]);
  const [clients, setClients] = React.useState([]);
  const [users, setUsers] = React.useState([]);
  const [letters, setLetters] = React.useState([]);
  const [refresh, setRefresh] = React.useState(false);
  const [emptySearch, setEmptySearch] = React.useState(false);
  const [resetLetters, setResetLetters] = React.useState(false);

  useEffect(() => {
    API.get("/project").then((response) => {
      setProjects(response.data);
    });
    API.get("/project/letters").then((response) => {
      setLetters(response.data);
    });
  }, [refresh]);

  useEffect(() => {
    API.get("/client").then((response) => {
      setClients(response.data);
    });
    API.get("/user").then((response) => {
      setUsers(response.data);
    });
  }, []);

  return (
    <div className="wrapper">
      <section className="content">
        <h2>
          <i className="ico projects"></i>Projects
        </h2>
        <div className="grey-box-wrap reports">
          <a href="#new-member" className="link new-member-popup">
            Create new project
          </a>
          <Search
            key="search-project"
            name="search-project"
            setParentItems={setProjects}
            type="project"
            resetLetters={resetLetters}
            setResetLetters={setResetLetters}
            emptySearch={emptySearch}
            setEmptySearch={setEmptySearch}
          />
        </div>
        <NewProject
          clients={clients}
          users={users}
          refresh={refresh}
          setRefresh={setRefresh}
        />
        <Letters
          key="letters-project"
          setParentItems={setProjects}
          letters={letters}
          type="/project"
          resetLetters={resetLetters}
          setResetLetters={setResetLetters}
          emptySearch={emptySearch}
          setEmptySearch={setEmptySearch}
        />
        <ViewProjects
          projects={projects}
          clients={clients}
          users={users}
          refresh={refresh}
          setRefresh={setRefresh}
        />
        <div className="pagination">
          <ul>
            <li>
              <a href="javascript:;">1</a>
            </li>
            <li>
              <a href="javascript:;">2</a>
            </li>
            <li>
              <a href="javascript:;">3</a>
            </li>
            <li className="last">
              <a href="javascript:;">Next</a>
            </li>
          </ul>
        </div>
      </section>
    </div>
  );
};

export default Projects;
