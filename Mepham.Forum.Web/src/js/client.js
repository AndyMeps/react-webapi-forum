import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import { Router, Route, IndexRoute, browserHistory } from 'react-router';
import { syncHistoryWithStore } from 'react-router-redux';

import Layout from "./components/Layout";
import Login from "./components/Login";
import Home from './components/Home';
import Topic from './components/Topic';
import Post from './components/Post';

import store from "./store";

const history = syncHistoryWithStore(browserHistory, store);

const app = document.getElementById('app');

ReactDOM.render(
    <Provider store={store}>
      <Router history={history}>
        <Route path="/" component={Layout}>
          <IndexRoute component={Login} />
          <Route path="home" component={Home} />
          <Route path="topic/:topicId" component={Topic} />
          <Route path="post/:postId" component={Post} />
        </Route>
      </Router>
    </Provider>, app);
