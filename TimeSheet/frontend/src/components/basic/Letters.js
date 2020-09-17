import React, { useState, useEffect } from "react";
import API from "../services/API.js";
import Letter from "./Letter";

const Letters = (props) => {
  const [activeLetter, setActiveLetter] = React.useState("");

  const allLetters = [
    "A",
    "B",
    "C",
    "D",
    "E",
    "F",
    "G",
    "H",
    "I",
    "J",
    "K",
    "L",
    "M",
    "N",
    "O",
    "P",
    "Q",
    "R",
    "S",
    "T",
    "U",
    "V",
    "W",
    "X",
    "Y",
    "Z",
  ];

  const letterItem = (letter) => {
    const exists = props.letters.some((l) => l === letter);
    var letterClass = "";
    if (!props.resetLetters)
      if (letter === activeLetter) letterClass = "active";
    if (exists === true)
      return (
        <li className={letterClass} key={letter}>
          <Letter
            letter={letter}
            setParentItems={props.setParentItems}
            activeLetter={activeLetter}
            setActiveLetter={setActiveLetter}
            type={props.type}
            resetLetters={props.resetLetters}
            setResetLetters={props.setResetLetters}
            emptySearch={props.emptySearch}
            setEmptySearch={props.setEmptySearch}
            letterClass={letterClass}
            currentPage={props.currentPage}
            setCurrentPage={props.setCurrentPage}
            itemsPerPage={props.itemsPerPage}
            setSearchQuery={props.setSearchQuery}
          />
        </li>
      );
    return (
      <li className="disabled" key={letter}>
        <a href="javascript:;">{letter}</a>
      </li>
    );
  };

  return (
    <div className="alpha">
      <ul>{allLetters.map((letter) => letterItem(letter))}</ul>
    </div>
  );
};

export default Letters;
