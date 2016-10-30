import axios from 'axios';
import { push } from 'react-router-redux';
import { environment } from '../env';

export function fetchPostDetails(id) {
    return function (dispatch) {
        axios.get(environment.apiUrl + `/api/Posts/${id}`)
            .then((response) => {
                dispatch({type: "FETCH_POST_DETAILS_FULFILLED", payload: response.data });
            })
            .catch((err) => {
                dispatch({type: "FETCH_POST_DETAILS_REJECTED", payload: err });
            });
    }
}

export function fetchPostComments(id) {
    return function (dispatch) {
        axios.get(environment.apiUrl + `/api/Posts/${id}/Comments`)
            .then((response) => {
                dispatch({type: "FETCH_POST_COMMENTS_FULFILLED", payload: response.data});
            })
            .catch((err) => {
                dispatch({type: "FETCH_POST_COMMENTS_REJECTED", payload: err});
            });
    }
}

export function toggleAddComment() {
    return function(dispatch) {
        dispatch({type: "TOGGLE_ADD_COMMENT"});
    }
}

export function addComment(authorId, responseToCommentId, postId, description) {
    return function(dispatch) {
        axios.post(environment.apiUrl + '/api/Comments', {
            description,
            postId,
            authorId,
            responseToCommentId
        })
        .then((response) => {
            dispatch({type: "ADD_COMMENT_FULFILLED", payload: response.data});
        })
        .catch((err) => {
            dispatch({type: "ADD_COMMENT_REJECTED", payload: err});
        });
    }
}