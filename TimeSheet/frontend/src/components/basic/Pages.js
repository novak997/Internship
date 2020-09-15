import React, { useState, useEffect } from "react";
import API from "../services/API.js";
import Page from "../basic/Page";

const Pages = (props) => {
  const [pages, setPages] = React.useState([]);
  const [numberOfPages, setNumberOfPages] = React.useState(0);

  useEffect(() => {
    var number = props.numberOfItems / props.itemsPerPage;
    console.log(number);
    if (props.numberOfItems % props.itemsPerPage > 0) number += 1;
    var p = [];
    for (let i = 1; i <= number; i++) p.push(i);
    console.log(p);
    setPages(p);
    setNumberOfPages(p.length);
  }, [props.numberOfItems]);

  const previous = () => {
    if (props.currentPage > 1)
      return (
        <li key="previous">
          <Page
            key="previous"
            page="Previous"
            currentPage={props.currentPage}
            setCurrentPage={props.setCurrentPage}
            setResetLetters={props.setResetLetters}
            setEmptySearch={props.setEmptySearch}
          />
        </li>
      );
  };

  const next = (number) => {
    if (props.currentPage < number)
      return (
        <li key="next">
          <Page
            key="next"
            page="Next"
            currentPage={props.currentPage}
            setCurrentPage={props.setCurrentPage}
            setResetLetters={props.setResetLetters}
            setEmptySearch={props.setEmptySearch}
          />
        </li>
      );
  };

  const page = (number) => {
    return (
      <li key={number}>
        <Page
          key={number}
          page={number}
          currentPage={props.currentPage}
          setCurrentPage={props.setCurrentPage}
          setResetLetters={props.setResetLetters}
          setEmptySearch={props.setEmptySearch}
        />
      </li>
    );
  };

  return (
    <div className="pagination">
      <ul>
        {previous()}
        {pages.map((p) => page(p))}
        {next(numberOfPages)}
      </ul>
    </div>
  );
};

export default Pages;
