import React, { useState, useEffect } from "react";
import API from "../services/API.js";
import ViewClients from "../basic/ViewClients";
import Letters from "../basic/Letters";
import NewClient from "../basic/NewClient";
import Search from "../basic/Search";
import Pages from "../basic/Pages";

const Clients = (props) => {
  const [clients, setClients] = React.useState([]);
  const [countries, setCountries] = React.useState([]);
  const [letters, setLetters] = React.useState([]);
  const [refresh, setRefresh] = React.useState(false);
  const [emptySearch, setEmptySearch] = React.useState(false);
  const [resetLetters, setResetLetters] = React.useState(false);
  const [numberOfClients, setNumberOfClients] = React.useState(0);
  const [currentPage, setCurrentPage] = React.useState(1);
  const [itemsPerPage, setItemsPerPage] = React.useState(3);
  const [searchQuery, setSearchQuery] = React.useState("");

  useEffect(() => {
    /*
    API.get("/client").then((response) => {
      setClients(response.data);
    });
    */
    API.get("/client/letters").then((response) => {
      setLetters(response.data);
    });
    /*
    API.get("/client/number").then((response) => {
      setNumberOfClients(response.data);
    });
    */
    API.get("/client/1/" + itemsPerPage).then((response) => {
      setClients(response.data);
      console.log(response.data);
    });
  }, [refresh]);

  useEffect(() => {
    API.get("/country").then((response) => {
      setCountries(response.data);
    });
  }, []);

  useEffect(() => {
    console.log(searchQuery);
    if (searchQuery === "") {
      API.get("/client/" + currentPage + "/" + itemsPerPage).then(
        (response) => {
          setClients(response.data);
          console.log(response.data);
        }
      );
      API.get("/client/number").then((response) => {
        setNumberOfClients(response.data);
      });
      return;
    }
    let search = {
      name: searchQuery,
      page: currentPage,
      number: itemsPerPage,
    };
    console.log(search);
    API.post("/client/search/", search).then((response) => {
      setClients(response.data);
      console.log(response.data);
    });
    API.post("/client/number", search).then((response) => {
      setNumberOfClients(response.data);
    });
  }, [currentPage, searchQuery]);

  return (
    <div className="wrapper">
      <section className="content">
        <h2>
          <i className="ico clients"></i>Clients
        </h2>
        <div className="grey-box-wrap reports">
          <a href="#new-member" className="link new-member-popup">
            Create new client
          </a>
          <Search
            key="search-clients"
            name="search-clients"
            setParentItems={setClients}
            type="client"
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
        <NewClient
          countries={countries}
          refresh={refresh}
          setRefresh={setRefresh}
        />
        <Letters
          key="letters-client"
          setParentItems={setClients}
          letters={letters}
          type="/client"
          resetLetters={resetLetters}
          setResetLetters={setResetLetters}
          emptySearch={emptySearch}
          setEmptySearch={setEmptySearch}
          currentPage={currentPage}
          setCurrentPage={setCurrentPage}
          itemsPerPage={itemsPerPage}
          setSearchQuery={setSearchQuery}
        />
        <ViewClients
          clients={clients}
          countries={countries}
          refresh={refresh}
          setRefresh={setRefresh}
        />
        <Pages
          key="pages-client"
          numberOfItems={numberOfClients}
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

export default Clients;
