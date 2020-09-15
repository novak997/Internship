import React from "react";

const Footer = () => {
  return (
    <footer>
      <div className="wrapper">
        <ul>
          <li>
            <span>Copyright @ 2013. VegaITSourcing All rights reserved</span>
          </li>
        </ul>
        <ul className="right">
          <li>
            <a href="javascript:;">Terms of service</a>
          </li>
          <li>
            <a href="javascript:;" className="last">
              Privacy policy
            </a>
          </li>
        </ul>
      </div>
    </footer>
  );
};

export default Footer;
