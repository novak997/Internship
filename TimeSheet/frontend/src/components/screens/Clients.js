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

  useEffect(() => {
    /*
    API.get("/client").then((response) => {
      setClients(response.data);
    });
    */
    API.get("/client/letters").then((response) => {
      setLetters(response.data);
    });
    API.get("/client/number").then((response) => {
      setNumberOfClients(response.data);
      console.log(response.data);
      console.log(numberOfClients);
    });
    API.get("/client/" + currentPage + "/" + itemsPerPage).then((response) => {
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
    API.get("/client/" + currentPage + "/" + itemsPerPage).then((response) => {
      setClients(response.data);
      console.log(response.data);
    });
  }, [currentPage]);

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
