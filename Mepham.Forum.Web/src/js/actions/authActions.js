import axios from "axios";
import { push } from 'react-router-redux'
import { environment } from '../env'

/**
 * Attempts to log in the user with the provided username and
 * password, will add an error message to the state if unsuccessful.
 *
 * @export
 * @param {string} username
 * @param {string} password
 * @returns
 */
export function loginUser(username, password) {
    return function(dispatch) {
        axios.post(environment.apiUrl + "/api/auth/login", {
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

/**
 * Logs out the user, resetting the auth state and redirecting
 * to the login page.
 *
 * @export
 * @returns
 */
export function logoutUser() {
    return function(dispatch) {
        dispatch({type: "LOGOUT_USER"})
        dispatch(push('/'))
    }
}
