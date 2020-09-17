import React from "react";
import logo from "./logo.svg";
import "./App.css";

import Navbar from "./components/layout/Navbar";
import Footer from "./components/layout/Footer";
import Clients from "./components/screens/Clients";
import Projects from "./components/screens/Projects";
import Members from "./components/screens/Members";
import Reports from "./components/screens/Reports";
import Timesheets from "./components/screens/Timesheets";
import Days from "./components/screens/Days";
import Categories from "./components/screens/Categories";

import { BrowserRouter as Router, Switch, Route } from "react-router-dom";

function App() {
  const accessToken =
    "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhc2RmQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhc2RmZ2giLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTU5OTY0MjUyOSwiaXNzIjoiVGltZVNoZWV0IiwiYXVkIjoiVGltZVNoZWV0In0.4MR8R6WJnqfaO2MJsul7WIdzt2dpqPJza3Nia48xpLs";

  return (
    <div className="App">
      <div className="container">
        <Router>
          <Navbar />
          <Switch>
            <Route path="/clients">
              <Clients accessToken={accessToken} />
            </Route>
            <Route path="/projects">
              <Projects accessToken={accessToken} />
            </Route>
            <Route path="/team-members">
              <Members accessToken={accessToken} />
            </Route>
            <Route path="/reports">
              <Reports accessToken={accessToken} />
            </Route>
            <Route path="/index">
              <Timesheets accessToken={accessToken} />
            </Route>
            <Route path="/days" component={Days}></Route>
            <Route path="/categories">
              <Categories accessToken={accessToken} />
            </Route>
          </Switch>
          <Footer />
        </Router>
      </div>
    </div>
  );
}

export default App;
