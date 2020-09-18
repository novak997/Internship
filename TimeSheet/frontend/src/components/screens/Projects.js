import React, { useState, useEffect } from "react";
import API from "../services/API.js";
import ViewProjects from "../basic/ViewProjects";
import Letters from "../basic/Letters";
import NewProject from "../basic/NewProject";
import Search from "../basic/Search";
import Pages from "../basic/Pages";

const Projects = (props) => {
  const [projects, setProjects] = React.useState([]);
  const [clients, setClients] = React.useState([]);
  const [users, setUsers] = React.useState([]);
  const [letters, setLetters] = React.useState([]);
  const [refresh, setRefresh] = React.useState(false);
  const [emptySearch, setEmptySearch] = React.useState(false);
  const [resetLetters, setResetLetters] = React.useState(false);
  const [numberOfProjects, setNumberOfProjects] = React.useState(0);
  const [currentPage, setCurrentPage] = React.useState(1);
  const [itemsPerPage, setItemsPerPage] = React.useState(3);
  const [searchQuery, setSearchQuery] = React.useState("");

  useEffect(() => {
    API.get("/project/" + currentPage + "/" + itemsPerPage).then((response) => {
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

  useEffect(() => {
    console.log(searchQuery);
    if (searchQuery === "") {
      API.get("/project/" + currentPage + "/" + itemsPerPage).then(
        (response) => {
          setProjects(response.data);
          console.log(response.data);
        }
      );
      API.get("/project/number").then((response) => {
        setNumberOfProjects(response.data);
      });
      return;
    }
    let search = {
      name: searchQuery,
      page: currentPage,
      number: itemsPerPage,
    };
    console.log(search);
    API.post("/project/search/", search).then((response) => {
      setProjects(response.data);
      console.log(response.data);
    });
    API.post("/project/number", search).then((response) => {
      setNumberOfProjects(response.data);
    });
  }, [currentPage, searchQuery]);

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
            currentPage={currentPage}
            setCurrentPage={setCurrentPage}
            itemsPerPage={itemsPerPage}
            setSearchQuery={setSearchQuery}
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
          currentPage={currentPage}
          setCurrentPage={setCurrentPage}
          itemsPerPage={itemsPerPage}
          setSearchQuery={setSearchQuery}
        />
        <ViewProjects
          projects={projects}
          clients={clients}
          users={users}
          refresh={refresh}
          setRefresh={setRefresh}
        />
        <Pages
          key="pages-client"
          numberOfItems={numberOfProjects}
          itemsPerPage={itemsPerPage}
          currentPage={currentPage}
          setCurrentPage={setCurrentPage}
          setResetLetters={setResetLetters}
          setEmptySearch={setEmptySearch}
        />
      </section>
    </div>
  );
};

export default Projects;
