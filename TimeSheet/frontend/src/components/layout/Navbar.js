import React from "react";

const Navbar = () => {
  return (
    <header>
      <div className="top-bar"></div>
      <div className="wrapper">
        <a href="/index" className="logo left">
          <img src="assets/images/logo.png" alt="VegaITSourcing Timesheet" />
        </a>
        <ul className="user right">
          <li>
            <a href="javascript:;">Sladjana Miljanovic</a>
            <div className="invisible"></div>
            <div className="user-menu">
              <ul>
                <li>
                  <a href="javascript:;" className="link">
                    Change password
                  </a>
                </li>
                <li>
                  <a href="javascript:;" className="link">
                    Settings
                  </a>
                </li>
                <li>
                  <a href="javascript:;" className="link">
                    Export all data
                  </a>
                </li>
              </ul>
            </div>
          </li>
          <li className="last">
            <a href="javascript:;">Logout</a>
          </li>
        </ul>
        <nav>
          <ul className="menu">
            <li>
              <a href="/index" className="btn nav">
                TimeSheet
              </a>
            </li>
            <li>
              <a href="/clients" className="btn nav">
                Clients
              </a>
            </li>
            <li>
              <a href="/projects" className="btn nav">
                Projects
              </a>
            </li>
            <li>
              <a href="/categories" className="btn nav">
                Categories
              </a>
            </li>
            <li>
              <a href="/team-members" className="btn nav">
                Team members
              </a>
            </li>
            <li className="last">
              <a href="/reports" className="btn nav">
                Reports
              </a>
            </li>
          </ul>
          <div className="mobile-menu">
            <a href="javascript:;" className="menu-btn">
              <span>mobile menu</span>
            </a>
            <ul>
              <li>
                <a href="javascript:;">TimeSheet</a>
              </li>
              <li>
                <a href="javascript:;">Clients</a>
              </li>
              <li>
                <a href="javascript:;">Projects</a>
              </li>
              <li>
                <a href="javascript:;">Categories</a>
              </li>
              <li>
                <a href="javascript:;">Team members</a>
              </li>
              <li className="last">
                <a href="javascript:;">Reports</a>
              </li>
            </ul>
          </div>
          <span className="line"></span>
        </nav>
      </div>
    </header>
  );
};

export default Navbar;
