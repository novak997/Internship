import React, { useState, useEffect } from "react";
import API from "../services/API.js";
import NewMember from "../basic/NewMember";
import ViewMembers from "../basic/ViewMembers";

const Members = (props) => {
  const [refresh, setRefresh] = React.useState(false);
  const [users, setUsers] = React.useState([]);

  useEffect(() => {
    API.get("/user").then((response) => {
      setUsers(response.data);
    });
  }, [refresh]);

  return (
    <div class="wrapper">
      <section class="content">
        <h2>
          <i class="ico team-member"></i>Team members
        </h2>
        <div class="grey-box-wrap reports ico-member">
          <a href="#new-member" class="link new-member-popup test">
            <span>Create new member</span>
          </a>
        </div>
        <NewMember refresh={refresh} setRefresh={setRefresh} />
        <ViewMembers users={users} refresh={refresh} setRefresh={setRefresh} />
        <div class="pagination">
          <ul>
            <li>
              <a href="javascript:;">1</a>
            </li>
            <li>
              <a href="javascript:;">2</a>
            </li>
            <li>
              <a href="javascript:;">3</a>
            </li>
            <li class="last">
              <a href="javascript:;">Next</a>
            </li>
          </ul>
        </div>
      </section>
    </div>
  );
};

export default Members;
