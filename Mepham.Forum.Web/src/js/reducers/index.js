import { combineReducers } from "redux";
import { combineForms } from 'react-redux-form';

import { routerReducer } from 'react-router-redux';

import auth from './authReducer';
import forms from './formsReducer';

export default combineReducers({
  auth,
  forms,
  routing: routerReducer
})
