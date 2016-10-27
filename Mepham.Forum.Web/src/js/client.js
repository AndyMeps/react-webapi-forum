import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";

import Layout from "./components/Layout";
import Login from "./components/Login";
import Home from './components/Home';

import store from "./store";

import { Router, Route, IndexRoute, browserHistory } from 'react-router';
import { syncHistoryWithStore } from 'react-router-redux';

const history = syncHistoryWithStore(browserHistory, store);

const app = document.getElementById('app');

ReactDOM.render(
    <Provider store={store}>
      <Router history={history}>
        <Route path="/" component={Layout}>
          <IndexRoute component={Login} />
          <Route path="home" component={Home} />
        </Route>
      </Router>
    </Provider>, app);
