import React, { useState, useEffect } from "react";
import API from "../services/API.js";

const ClientItem = (props) => {
  const [itemClass, setItemClass] = useState("item");
  const [detailsDisplay, setDetailsDisplay] = useState("none");
  const [name, setName] = React.useState(props.client.name);
  const [address, setAddress] = React.useState(props.client.address);
  const [city, setCity] = React.useState(props.client.city);
  const [zip, setZip] = React.useState(props.client.zip);
  const [country, setCountry] = React.useState(props.client.countryID);
  const countryOptions = props.countries;

  const handleItemClick = () => {
    if (itemClass === "item") {
      setItemClass("item open");
      setDetailsDisplay("block");
    } else {
      setItemClass("item");
      setDetailsDisplay("none");
    }
  };

  const handleSelectChangeCountry = (event) => {
    setCountry(event.target.value);
  };

  const countryOptionsList = countryOptions.map((opt) => (
    <option key={opt.id} value={opt.id}>
      {opt.name}
    </option>
  ));

  const saveSubmit = () => {
    let client = {
      id: props.client.id,
      name: name,
      address: address,
      city: city,
      zip: zip,
      countryID: parseInt(country),
      concurrency: props.client.concurrency,
    };
    API.put("/client", client)
      .then((response) => {
        console.log(response.data);
        props.setRefresh(!props.refresh);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const deleteSubmit = () => {
    API.put("/client/" + props.client.id, props.client.concurrency)
      .then((response) => {
        console.log(response.data);
        props.setRefresh(!props.refresh);
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <div className={itemClass}>
      <div className="heading" onClick={handleItemClick}>
        <span>{props.client.name}</span>
        <i>+</i>
      </div>
      <div className="details" style={{ display: detailsDisplay }}>
        <ul className="form">
          <li>
            <label>Client name:</label>
            <input
              type="text"
              className="in-text"
              value={name}
              onChange={(event) => setName(event.target.value)}
            />
          </li>
          <li>
            <label>Zip/Postal code:</label>
            <input
              type="text"
              className="in-text"
              value={zip}
              onChange={(event) => setZip(event.target.value)}
            />
          </li>
        </ul>
        <ul className="form">
          <li>
            <label>Address:</label>
            <input
              type="text"
              className="in-text"
              value={address}
              onChange={(event) => setAddress(event.target.value)}
            />
          </li>
          <li>
            <label>Country:</label>
            <select value={country} onChange={handleSelectChangeCountry}>
              {countryOptionsList}
            </select>
          </li>
        </ul>
        <ul className="form last">
          <li>
            <label>City:</label>
            <input
              type="text"
              className="in-text"
              value={city}
              onChange={(event) => setCity(event.target.value)}
            />
          </li>
        </ul>
        <div className="buttons">
          <div className="inner">
            <a href="javascript:;" className="btn green" onClick={saveSubmit}>
              Save
            </a>
            <a href="javascript:;" className="btn red" onClick={deleteSubmit}>
              Delete
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ClientItem;
