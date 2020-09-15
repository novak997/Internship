import React from "react";

const Reports = (props) => {
  return (
    <div className="wrapper">
      <section className="content">
        <h2>
          <i className="ico report"></i>Reports
        </h2>
        <div className="grey-box-wrap reports">
          <ul className="form">
            <li>
              <label>Team member:</label>
              <select>
                <option>All</option>
              </select>
            </li>
            <li>
              <label>Category:</label>
              <select>
                <option>All</option>
              </select>
            </li>
          </ul>
          <ul className="form">
            <li>
              <label>Client:</label>
              <select>
                <option>All</option>
              </select>
            </li>
            <li>
              <label>Start date:</label>
              <input type="text" className="in-text datepicker" />
            </li>
          </ul>
          <ul className="form last">
            <li>
              <label>Project:</label>
              <select>
                <option>All</option>
              </select>
            </li>
            <li>
              <label>End date:</label>
              <input type="text" className="in-text datepicker" />
            </li>
            <li>
              <a href="javascript:;" className="btn orange right">
                Reset
              </a>
              <a href="javascript:;" className="btn green right">
                Search
              </a>
            </li>
          </ul>
        </div>
        <table className="default-table">
          <tr>
            <th>Date</th>
            <th>Team member</th>
            <th>Projects</th>
            <th>Categories</th>
            <th>Description</th>
            <th className="small">Time</th>
          </tr>
          <tr>
            <td>2013-02-13</td>
            <td>Slađana Miljanovic</td>
            <td>Seachange - Nitro</td>
            <td>Front-End Development</td>
            <td>Lorem ipsum dolor sit amet</td>
            <td className="small">7.5</td>
          </tr>
          <tr>
            <td>2013-02-13</td>
            <td>Sladjana Miljanovic</td>
            <td>Seachange - Nitro</td>
            <td>Front-End Development</td>
            <td>Lorem ipsum dolor sit amet</td>
            <td className="small">7.5</td>
          </tr>
          <tr>
            <td>2013-02-13</td>
            <td>Sladjana Miljanovic</td>
            <td>Seachange - Nitro</td>
            <td>Front-End Development</td>
            <td>Lorem ipsum dolor sit amet</td>
            <td className="small">7.5</td>
          </tr>
        </table>
        <div className="total">
          <span>
            Report total: <em>7.5</em>
          </span>
        </div>
        <div className="grey-box-wrap reports">
          <div className="btns-inner">
            <a href="javascript:;" className="btn white">
              <i className="ico print"></i>
              <span>Print report</span>
            </a>
            <a href="javascript:;" className="btn white">
              <i className="ico pdf"></i>
              <span>Create PDF</span>
            </a>
            <a href="javascript:;" className="btn white">
              <i className="ico excel"></i>
              <span>Export to excel</span>
            </a>
          </div>
        </div>
      </section>
    </div>
  );
};

export default Reports;
