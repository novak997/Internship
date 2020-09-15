import React, { useState, useEffect } from "react";
import API from "../services/API.js";

const Page = (props) => {
  const clickLink = () => {
    if (props.page === "Previous") props.setCurrentPage(props.currentPage - 1);
    else if (props.page === "Next") props.setCurrentPage(props.currentPage + 1);
    else props.setCurrentPage(parseInt(props.page));
    props.setEmptySearch(true);
    props.setResetLetters(true);
  };

  return (
    <a href="javascript:;" onClick={clickLink}>
      {props.page}
    </a>
  );
};

export default Page;
