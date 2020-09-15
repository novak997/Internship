import React, { useState, useEffect } from "react";
import API from "../services/API.js";

import MemberItem from "./MemberItem";

const ViewMembers = (props) => {
  return (
    <div className="accordion-wrap">
      {props.users.map((u) => (
        <MemberItem
          user={u}
          refresh={props.refresh}
          setRefresh={props.setRefresh}
        />
      ))}
    </div>
  );
};

export default ViewMembers;
