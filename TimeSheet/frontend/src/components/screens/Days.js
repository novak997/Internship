import React from "react";

const Days = (props) => {
  return (
    <div class="wrapper">
      <section class="content">
        <h2>
          <i class="ico timesheet"></i>TimeSheet
        </h2>
        <div class="grey-box-wrap">
          <div class="top">
            <a href="javascript:;" class="prev">
              <i></i>previous week
            </a>
            <span class="center">February 04 - February 10, 2013 (week 6)</span>
            <a href="javascript:;" class="next">
              next week<i></i>
            </a>
          </div>
          <div class="bottom">
            <ul class="days">
              <li>
                <a href="javascript:;">
                  <b>Feb 04</b>
                  <span>monday</span>
                </a>
              </li>
              <li>
                <a href="javascript:;">
                  <b>Feb 06</b>
                  <span>tuesday</span>
                </a>
              </li>
              <li>
                <a href="javascript:;">
                  <b>Feb 06</b>
                  <span>wednesday</span>
                </a>
              </li>
              <li class="active">
                <a href="javascript:;">
                  <b>Feb 07</b>
                  <span>thursday</span>
                </a>
              </li>
              <li>
                <a href="javascript:;">
                  <b>Feb 08</b>
                  <span>friday</span>
                </a>
              </li>
              <li>
                <a href="javascript:;">
                  <b>Feb 09</b>
                  <span>saturday</span>
                </a>
              </li>
              <li class="last">
                <a href="javascript:;">
                  <b>Feb 10</b>
                  <span>sunday</span>
                </a>
              </li>
            </ul>
          </div>
        </div>
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
          <tr>
            <td>
              <select>
                <option>Choose client</option>
                <option>Client 1</option>
                <option>Client 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose project</option>
                <option>Project 1</option>
                <option>Project 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose category</option>
                <option>Front-End Development</option>
                <option>Design</option>
              </select>
            </td>
            <td>
              <input type="text" class="in-text medium" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
          </tr>
          <tr>
            <td>
              <select>
                <option>Choose client</option>
                <option>Client 1</option>
                <option>Client 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose project</option>
                <option>Project 1</option>
                <option>Project 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose category</option>
                <option>Front-End Development</option>
                <option>Design</option>
              </select>
            </td>
            <td>
              <input type="text" class="in-text medium" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
          </tr>
          <tr>
            <td>
              <select>
                <option>Choose client</option>
                <option>Client 1</option>
                <option>Client 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose project</option>
                <option>Project 1</option>
                <option>Project 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose category</option>
                <option>Front-End Development</option>
                <option>Design</option>
              </select>
            </td>
            <td>
              <input type="text" class="in-text medium" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
          </tr>
          <tr>
            <td>
              <select>
                <option>Choose client</option>
                <option>Client 1</option>
                <option>Client 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose project</option>
                <option>Project 1</option>
                <option>Project 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose category</option>
                <option>Front-End Development</option>
                <option>Design</option>
              </select>
            </td>
            <td>
              <input type="text" class="in-text medium" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
          </tr>
          <tr>
            <td>
              <select>
                <option>Choose client</option>
                <option>Client 1</option>
                <option>Client 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose project</option>
                <option>Project 1</option>
                <option>Project 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose category</option>
                <option>Front-End Development</option>
                <option>Design</option>
              </select>
            </td>
            <td>
              <input type="text" class="in-text medium" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
          </tr>
          <tr>
            <td>
              <select>
                <option>Choose client</option>
                <option>Client 1</option>
                <option>Client 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose project</option>
                <option>Project 1</option>
                <option>Project 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose category</option>
                <option>Front-End Development</option>
                <option>Design</option>
              </select>
            </td>
            <td>
              <input type="text" class="in-text medium" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
          </tr>
          <tr>
            <td>
              <select>
                <option>Choose client</option>
                <option>Client 1</option>
                <option>Client 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose project</option>
                <option>Project 1</option>
                <option>Project 2</option>
              </select>
            </td>
            <td>
              <select>
                <option>Choose category</option>
                <option>Front-End Development</option>
                <option>Design</option>
              </select>
            </td>
            <td>
              <input type="text" class="in-text medium" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
            <td class="small">
              <input type="text" class="in-text xsmall" />
            </td>
          </tr>
        </table>
        <div class="total">
          <a href="index.html">
            <i></i>back to monthly view
          </a>
          <span>
            Total hours: <em>7.5</em>
          </span>
        </div>
      </section>
    </div>
  );
};

export default Days;
