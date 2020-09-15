import React, { useState, useEffect } from "react";
import API from "../services/API.js";

const NewClient = (props) => {
  const [name, setName] = React.useState("");
  const [address, setAddress] = React.useState("");
  const [city, setCity] = React.useState("");
  const [zip, setZip] = React.useState("");
  const [country, setCountry] = React.useState("");
  const countryOptions = props.countries;

  const handleSelectChangeCountry = (event) => {
    setCountry(event.target.value);
  };

  const countryOptionsList = countryOptions.map((opt) => (
    <option key={opt.id} value={opt.id}>
      {opt.name}
    </option>
  ));

  const submitForm = () => {
    var countryID = country;
    if (countryID === "") countryID = countryOptions[0].id;

    let client = {
      name: name,
      address: address,
      city: city,
      zip: zip,
      countryID: parseInt(countryID),
    };
    API.post("/client", client)
      .then((response) => {
        console.log(response.data);
        props.setRefresh(!props.refresh);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <div className="new-member-wrap">
      <div id="new-member" className="new-member-inner">
        <h2>Create new client</h2>
        <ul className="form">
          <li>
            <label>Client name:</label>
            <input
              value={name}
              onChange={(event) => setName(event.target.value)}
              type="text"
              className="in-text"
            />
          </li>
          <li>
            <label>Address:</label>
            <input
              value={address}
              onChange={(event) => setAddress(event.target.value)}
              type="text"
              className="in-text"
            />
          </li>
          <li>
            <label>City:</label>
            <input
              value={city}
              onChange={(event) => setCity(event.target.value)}
              type="text"
              className="in-text"
            />
          </li>
          <li>
            <label>Zip/Postal code:</label>
            <input
              value={zip}
              onChange={(event) => setZip(event.target.value)}
              type="text"
              className="in-text"
            />
          </li>
          <li>
            <label>Country:</label>
            <select value={country} onChange={handleSelectChangeCountry}>
              {countryOptionsList}
            </select>
          </li>
        </ul>
        <div className="buttons">
          <div className="inner">
            <a href="javascript:;" className="btn green" onClick={submitForm}>
              Save
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default NewClient;
