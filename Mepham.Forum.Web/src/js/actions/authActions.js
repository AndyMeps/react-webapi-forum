import axios from "axios";
import { push } from 'react-router-redux'

export function loginUser(username, password) {
    return function(dispatch) {
        axios.post("http://localhost:54499/api/auth/login", {
            username,
            password
        })
        .then((response) => {
            dispatch({type: "LOGIN_USER_FULFILLED", payload: response.data});
            dispatch(push('/home'))
        })
        .catch((err) => {
            dispatch({type: "LOGIN_USER_REJECTED", payload: err});
        });
    }
}

export function logoutUser() {
    return function(dispatch) {
        // TODO
    }
}
