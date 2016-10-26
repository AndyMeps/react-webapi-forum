import { combineReducers } from "redux";
import { combineForms } from 'react-redux-form';


import auth from './authReducer';
import forms from './formsReducer';

export default combineReducers({
  auth,
  forms
})
