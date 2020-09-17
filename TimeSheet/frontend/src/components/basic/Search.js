import React, { useState, useEffect } from "react";
import API from "../services/API.js";

const Search = (props) => {
  const [searchInput, setSearchInput] = React.useState("");

  const search = (query) => {
    props.setSearchQuery(query);
    props.setCurrentPage(1);
    /*
    let search = {
      name: query,
      page: 1,
      number: props.itemsPerPage,
    };
    if (query) {
      API.post("/" + props.type + "/search", search).then((response) => {
        console.log(response.data);
        props.setParentItems(response.data);
      });
      return;
    }
    API.get("/client/1/" + props.itemsPerPage).then((response) => {
      props.setParentItems(response.data);
    });
    */
  };

  useEffect(() => {
    if (props.emptySearch) setSearchInput("");
  }, [props.emptySearch]);

  const handleSearchChange = (event) => {
    search(event.target.value);
    console.log(event.target.value);
    props.setEmptySearch(false);
    props.setResetLetters(true);
    setSearchInput(event.target.value);
  };

  return (
    <div className="search-page">
      <input
        onChange={handleSearchChange}
        type="search"
        className="in-search"
        value={searchInput}
      />
    </div>
  );
};

export default Search;
