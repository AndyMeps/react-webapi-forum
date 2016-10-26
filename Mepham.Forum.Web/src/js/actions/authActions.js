import axios from "axios";

export function fetchUser(username, password) {
    return function(dispatch) {
        debugger;
        axios.post("http://localhost:8080/api/auth/", {
            username,
            password
        })
        .then((response) => {
            dispatch({type: "FETCH_USER_FULFILLED", payload: response.data})
        })
        .catch((err) => {
            dispatch({type: "FETCH_USER_REJECTED", payload: err})
        });
    }
}