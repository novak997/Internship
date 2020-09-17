import React, { useState, useEffect } from "react";
import API from "../services/API.js";
import { Link, useLocation } from "react-router-dom";
import getDate from "date-fns/getDate";
import getMonth from "date-fns/getMonth";
import getYear from "date-fns/getYear";

const Day = (props) => {
  const [worktimes, setWorktimes] = React.useState([]);
  /*
  useEffect(() => {
    const day = getDate(props.day);
    const month = getMonth(props.day) + 1;
    const year = getYear(props.day);
    const id = props.user;
    
    API.get("/worktime/" + id + "/" + day + "/" + month + "/" + year)
      .then((response) => {
        setWorktimes(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
      
  }, []);
*/
  return (
    <td className={props.tdClass}>
      <div className="date">
        <span>{props.formattedDate}</span>
      </div>
      <div className="hours">
        <Link
          to={{
            pathname: "/days",
            state: {
              day: props.day,
              user: props.user,
            },
          }}
        >
          Hours: <span>{props.hours}</span>
        </Link>
      </div>
    </td>
  );
};

export default Day;
