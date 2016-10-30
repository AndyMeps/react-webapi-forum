import { combineReducers } from "redux";
import { combineForms } from 'react-redux-form';
import { routerReducer } from 'react-router-redux';

import auth from './authReducer';
import forms from './formsReducer';
import topics from './topicReducer';
import post from './postReducer';

export default combineReducers({
  auth,
  forms,
  topics,
  post,
  routing: routerReducer
})
