import React, { useState, useEffect } from "react";
import API from "../services/API.js";

const Letter = (props) => {
  const filter = () => {
    if (props.letterClass === "active") {
      props.setActiveLetter("");
      if (props.currentPage === 1) {
        API.get("/client/" + props.currentPage + "/" + props.itemsPerPage).then(
          (response) => {
            props.setParentItems(response.data);
          }
        );
        return;
      }
      props.setEmptySearch(true);
      props.setResetLetters(false);
      props.setCurrentPage(1);
      return;
    }
    props.setActiveLetter(props.letter);
    let search = {
      name: props.letter,
    };
    API.post(props.type + "/search", search).then((response) => {
      props.setParentItems(response.data);
    });
    props.setEmptySearch(true);
    props.setResetLetters(false);
  };

  return (
    <a href="javascript:;" onClick={filter}>
      {props.letter}
    </a>
  );
};

export default Letter;
