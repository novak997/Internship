import React, { useState, useEffect } from "react";
import API from "../services/API.js";
import { useLocation } from "react-router-dom";
import DaysHeader from "../basic/DaysHeader";

import format from "date-fns/format";
import addMonths from "date-fns/addMonths";
import addWeeks from "date-fns/addWeeks";
import addDays from "date-fns/addDays";
import subMonths from "date-fns/subMonths";
import subWeeks from "date-fns/subWeeks";
import startOfMonth from "date-fns/startOfMonth";
import endOfMonth from "date-fns/endOfMonth";
import startOfWeek from "date-fns/startOfWeek";
import endOfWeek from "date-fns/endOfWeek";
import isSameMonth from "date-fns/isSameMonth";
import isBefore from "date-fns/isBefore";
import isAfter from "date-fns/isAfter";
import getDate from "date-fns/getDate";
import getMonth from "date-fns/getMonth";
import getWeek from "date-fns/getWeek";
import getYear from "date-fns/getYear";
import NewWorktime from "../basic/NewWorktime.js";
import WorktimeItem from "../basic/WorktimeItem.js";

const Days = (props) => {
  const headerDateFormat = "MMMM, yyyy";
  const [currentWeek, setCurrentWeek] = React.useState(
    getWeek(props.location.state.day, { weekStartsOn: 1 })
  );
  const [today, setToday] = React.useState(new Date());
  const [weekStart, setWeekStart] = React.useState(
    startOfWeek(props.location.state.day, { weekStartsOn: 1 })
  );
  const [weekEnd, setWeekEnd] = React.useState(
    endOfWeek(props.location.state.day, { weekStartsOn: 1 })
  );
  const [year, setYear] = React.useState(getYear(props.location.state.day));
  const [day, setDay] = React.useState(props.location.state.day);
  const formatWeek = "MMMM d";

  const [worktimes, setWorktimes] = React.useState([]);
  const [clients, setClients] = React.useState([]);
  const [projects, setProjects] = React.useState([]);
  const [categories, setCategories] = React.useState([]);
  const [refresh, setRefresh] = React.useState(false);
  const [totalHours, setTotalHours] = React.useState(0);

  useEffect(() => {
    /*
    const dayLocal = getDate(day);
    const month = getMonth(day) + 1;
    const year = getYear(day);
    const id = props.location.state.user;
    console.log(day);
    
    API.get("/worktime/" + id + "/" + day + "/" + month + "/" + year)
      .then((response) => {
        setWorktimes(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
      */
    API.get("/client")
      .then((response) => {
        setClients(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
    /*
    API.get("/project")
      .then((response) => {
        setProjects(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
      */
    API.get("/category")
      .then((response) => {
        setCategories(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  useEffect(() => {
    const dayLocal = getDate(day);
    const month = getMonth(day) + 1;
    const year = getYear(day);
    const id = props.location.state.user;
    console.log(day);

    API.get("/worktime/" + id + "/" + dayLocal + "/" + month + "/" + year)
      .then((response) => {
        setWorktimes(response.data);
        setTotalHours(
          response.data.reduce(
            (total, worktime) => total + worktime.hours + worktime.overtime,
            0
          )
        );
      })
      .catch((error) => {
        console.log(error);
      });
  }, [refresh]);

  const nextWeek = () => {
    setDay(addWeeks(day, 1));
  };

  const prevMonth = () => {
    setDay(subWeeks(day, 1));
  };

  return (
    <div class="wrapper">
      <section class="content">
        <h2>
          <i class="ico timesheet"></i>TimeSheet
        </h2>
        <DaysHeader
          day={day}
          setDay={setDay}
          refresh={refresh}
          setRefresh={setRefresh}
        />
        <table class="default-table">
          <tr>
            <th>
              Client <em>*</em>
            </th>
            <th>
              Project <em>*</em>
            </th>
            <th>
              Category <em>*</em>
            </th>
            <th>Description</th>
            <th class="small">
              Time <em>*</em>
            </th>
            <th class="small">Overtime</th>
          </tr>
          {worktimes.map((w) => (
            <WorktimeItem
              key={w.id}
              clients={clients}
              categories={categories}
              worktime={w}
              refresh={refresh}
              setRefresh={setRefresh}
            />
          ))}
          <NewWorktime
            key="new-worktime"
            clients={clients}
            categories={categories}
            user={props.location.state.user}
            day={day}
            refresh={refresh}
            setRefresh={setRefresh}
          />
        </table>
        <div class="total">
          <a href="/index">
            <i></i>back to monthly view
          </a>
          <span>
            Total hours: <em>{totalHours}</em>
          </span>
        </div>
      </section>
    </div>
  );
};

export default Days;
