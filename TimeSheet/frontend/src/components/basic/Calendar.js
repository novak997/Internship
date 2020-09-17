import React, { useState, useEffect } from "react";
import API from "../services/API.js";
import format from "date-fns/format";
import addMonths from "date-fns/addMonths";
import addDays from "date-fns/addDays";
import subMonths from "date-fns/subMonths";
import startOfMonth from "date-fns/startOfMonth";
import endOfMonth from "date-fns/endOfMonth";
import startOfWeek from "date-fns/startOfWeek";
import endOfWeek from "date-fns/endOfWeek";
import isSameMonth from "date-fns/isSameMonth";
import isBefore from "date-fns/isBefore";
import isAfter from "date-fns/isAfter";
import getDate from "date-fns/getDate";
import getMonth from "date-fns/getMonth";
import getYear from "date-fns/getYear";
import parse from "date-fns/parse";

import Day from "./Day";

const Calendar = (props) => {
  const headerDateFormat = "MMMM, yyyy";
  const [currentMonth, setCurrentMonth] = React.useState(new Date());
  const [entireMonth, setEntireMonth] = React.useState([]);

  useEffect(() => {
    const monthStart = startOfMonth(currentMonth);
    const monthEnd = endOfMonth(monthStart, { weekStartsOn: 1 });
    const startDate = startOfWeek(monthStart, { weekStartsOn: 1 });
    const endDate = endOfWeek(monthEnd, { weekStartsOn: 1 });
    const id = 1;

    const day1 = getDate(startDate);
    const month1 = getMonth(startDate) + 1;
    const year1 = getYear(startDate);
    const day2 = getDate(endDate);
    const month2 = getMonth(endDate) + 1;
    const year2 = getYear(endDate);
    const month3 = getMonth(currentMonth) + 1;
    let month = [];
    API.get(
      "/worktime/" +
        id +
        "/" +
        day1 +
        "/" +
        month1 +
        "/" +
        year1 +
        "/" +
        day2 +
        "/" +
        month2 +
        "/" +
        year2 +
        "/" +
        month3
    )
      .then((response) => {
        month = response.data;
        console.log(month);
        setEntireMonth(month);
      })
      .catch((error) => {
        console.log(error);
      });
  }, [currentMonth]);

  const nextMonth = () => {
    setCurrentMonth(addMonths(currentMonth, 1));
  };

  const prevMonth = () => {
    setCurrentMonth(subMonths(currentMonth, 1));
  };

  const generateDays = () => {
    let month = entireMonth;

    const today = new Date();
    const monthStart = startOfMonth(currentMonth);
    const monthEnd = endOfMonth(monthStart, { weekStartsOn: 1 });
    const startDate = startOfWeek(monthStart, { weekStartsOn: 1 });
    const endDate = endOfWeek(monthEnd, { weekStartsOn: 1 });
    const id = 1;
    const dateFormat = "d.";

    let rows = [];
    let days = [];
    let formattedDate = "";
    let listLength = month.length;
    console.log(listLength);

    for (let i = 0; i < listLength - 1; i++) {
      let day = parse(month[i][0].substring(0, 10), "yyyy-MM-dd", new Date());
      formattedDate = format(day, dateFormat);

      if (isAfter(day, today)) {
        days.push(
          <td className="disable" key={day}>
            <div className="date">
              <span>{formattedDate}</span>
            </div>
            <div className="hours">
              <a>
                Hours: <span>0</span>
              </a>
            </div>
          </td>
        );
      } else {
        let tdClass = "";
        if (isBefore(day, monthStart)) tdClass = "previous";
        else if (isAfter(day, monthEnd)) tdClass = "next";
        if (month[i][2] === 0) tdClass += " negative";
        else if (month[i][2] === 1) tdClass += " positive";
        days.push(
          <Day
            user={id}
            key={day}
            day={day}
            formattedDate={formattedDate}
            tdClass={tdClass}
            hours={month[i][1]}
          />
        );
      }

      if (i % 7 === 6) {
        rows.push(<tr key={day}>{days}</tr>);
        days = [];
      }
    }
    return rows;
  };

  const totalHours = () => {
    return parseFloat(entireMonth[entireMonth.length - 1]);
  };

  return (
    <div class="wrapper">
      <section class="content">
        <h2>
          <i class="ico timesheet"></i>TimeSheet
        </h2>
        <div class="grey-box-wrap">
          <div class="top">
            <a href="javascript:;" class="prev" onClick={prevMonth}>
              <i></i>previous month
            </a>
            <span class="center">{format(currentMonth, headerDateFormat)}</span>
            <a href="javascript:;" class="next" onClick={nextMonth}>
              next month<i></i>
            </a>
          </div>
          <div class="bottom"></div>
        </div>
        <table class="month-table">
          <tr class="head">
            <th>
              <span>monday</span>
            </th>
            <th>tuesday</th>
            <th>wednesday</th>
            <th>thursday</th>
            <th>friday</th>
            <th>saturday</th>
            <th>sunday</th>
          </tr>
          <tr class="mobile-head">
            <th>mon</th>
            <th>tue</th>
            <th>wed</th>
            <th>thu</th>
            <th>fri</th>
            <th>sat</th>
            <th>sun</th>
          </tr>
          {generateDays()}
        </table>
        <div class="total">
          <span>
            Total hours: <em>{totalHours()}</em>
          </span>
        </div>
      </section>
    </div>
  );
};

export default Calendar;
