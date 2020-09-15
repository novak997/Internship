import React, { useState, useEffect } from "react";
import API from "../services/API.js";

const Search = (props) => {
  const [searchInput, setSearchInput] = React.useState("");

  const search = (query) => {
    let search = {
      name: query,
    };
    if (query) {
      API.post("/" + props.type + "/search", search).then((response) => {
        console.log(response.data);
        props.setParentItems(response.data);
      });
      return;
    }
    API.get("/client/" + props.currentPage + "/" + props.itemsPerPage).then(
      (response) => {
        props.setParentItems(response.data);
      }
    );
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
