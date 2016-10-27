import axios from "axios";

export function loginUser(username, password) {
    return function(dispatch) {
        axios.post("http://localhost:54499/api/auth/login", {
            username,
            password
        })
        .then((response) => {
            dispatch({type: "LOGIN_USER_FULFILLED", payload: response.data});
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
