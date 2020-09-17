import React, { useState, useEffect } from "react";
import API from "../services/API.js";
import { Link, useLocation } from "react-router-dom";

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
import isEqual from "date-fns/isEqual";
import getDate from "date-fns/getDate";
import getMonth from "date-fns/getMonth";
import getWeek from "date-fns/getWeek";
import getYear from "date-fns/getYear";
import parse from "date-fns/parse";

const DaysHeader = (props) => {
  const headerDateFormat = "MMMM, yyyy";
  const [currentWeek, setCurrentWeek] = React.useState(
    getWeek(props.day, { weekStartsOn: 1 })
  );
  const [today, setToday] = React.useState(new Date());
  const [weekStart, setWeekStart] = React.useState(
    startOfWeek(props.day, { weekStartsOn: 1 })
  );
  const [weekEnd, setWeekEnd] = React.useState(
    endOfWeek(props.day, { weekStartsOn: 1 })
  );
  const [year, setYear] = React.useState(getYear(props.day));
  const formatWeek = "MMMM dd";
  const [day, setDay] = React.useState(props.day);
  const [selectedDay, setSelectedDay] = React.useState(props.day);

  useEffect(() => {
    setWeekStart(startOfWeek(day, { weekStartsOn: 1 }));
    setWeekEnd(endOfWeek(day, { weekStartsOn: 1 }));
    setCurrentWeek(getWeek(day, { weekStartsOn: 1 }));
    setYear(getYear(day));
    setSelectedDay(props.day);
  }, [day]);

  const nextWeek = () => {
    setDay(addWeeks(day, 1));
  };

  const prevWeek = () => {
    setDay(subWeeks(day, 1));
  };

  const changeDay = (formattedDay) => {
    let dayLocal = parse(formattedDay, "dd-MM-yyyy", new Date());
    //console.log(dayLocal);
    //setSelectedDay(dayLocal);
    //setDay(dayLocal);
    props.setDay(dayLocal);
    setDay(dayLocal);
    props.setRefresh(!props.refresh);
  };

  const generateTabs = () => {
    let className = "";
    let days = [];
    let formatTab = "MMM dd";
    let formatKey = "dd-MM-yyyy";
    let dayLocal = weekStart;
    let daysOfWeek = [
      "monday",
      "tuesday",
      "wednesday",
      "thursday",
      "friday",
      "saturday",
      "sunday",
    ];
    for (let i = 0; i < 7; i++) {
      let formattedDayLocal = format(dayLocal, formatKey);
      if (isEqual(dayLocal, selectedDay)) className = "active";
      if (i === 6) className += " last";
      if (!isAfter(dayLocal, today) && !isEqual(dayLocal, selectedDay))
        days.push(
          <li
            key={formattedDayLocal}
            className={className}
            onClick={() => changeDay(formattedDayLocal)}
          >
            <a href="javascript:;" key={formattedDayLocal}>
              <b>{format(dayLocal, formatTab)}</b>
              <span>{daysOfWeek[i]}</span>
            </a>
          </li>
        );
      else
        days.push(
          <li key={formattedDayLocal} className={className}>
            <a href="javascript:;" key={formattedDayLocal}>
              <b>{format(dayLocal, formatTab)}</b>
              <span>{daysOfWeek[i]}</span>
            </a>
          </li>
        );
      dayLocal = addDays(dayLocal, 1);
      className = "";
    }
    return days;
  };

  return (
    <div className="grey-box-wrap">
      <div className="top">
        <a href="javascript:;" className="prev" onClick={prevWeek}>
          <i></i>previous week
        </a>
        <span className="center">
          {format(weekStart, formatWeek)} - {format(weekEnd, formatWeek)}
          ,&nbsp;
          {year} (week {currentWeek})
        </span>
        <a href="javascript:;" className="next" onClick={nextWeek}>
          next week<i></i>
        </a>
      </div>
      <div className="bottom">
        <ul className="days">{generateTabs()}</ul>
      </div>
    </div>
  );
};

export default DaysHeader;
