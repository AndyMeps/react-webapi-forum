import axios from 'axios';
import { push } from 'react-router-redux';
import { environment } from '../env';

/**
 * Attempts to return details of a Post using the provided Post ID.
 *
 * @export
 * @param {string} id String representation of a GUID
 * @returns
 */
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

/**
 * Attempts to return Comments for the provided Post ID.
 *
 * @export
 * @param {string} id String representation of a GUID
 * @returns
 */
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

/**
 * Toggles the state of adding a Comment on a Post.
 *
 * @export
 * @returns
 */
export function toggleAddComment() {
    return function(dispatch) {
        dispatch({type: "TOGGLE_ADD_COMMENT"});
    }
}

/**
 * Attempts to add a Comment to the current Post.
 *
 * @export
 * @param {string} authorId Guid for the current User.
 * @param {string} responseToCommentId Guid for the Comment being replied to.
 * @param {string} postId Guid for the Post being commented on.
 * @param {string} description Comment content.
 * @returns
 */
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