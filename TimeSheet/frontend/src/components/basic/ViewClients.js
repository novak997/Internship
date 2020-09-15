import React, { useState, useEffect } from "react";
import API from "../services/API.js";

import ClientItem from "./ClientItem";

const ViewClients = (props) => {
  return (
    <div className="accordion-wrap clients">
      {props.clients.map((c) => (
        <ClientItem
          client={c}
          countries={props.countries}
          refresh={props.refresh}
          setRefresh={props.setRefresh}
          key={c.id}
        />
      ))}
    </div>
  );
};

export default ViewClients;
