import axios from 'axios';
import { push } from 'react-router-redux';
import { environment } from '../env';

/**
 * Attempts to return all Topics.
 *
 * @export
 * @returns
 */
export function fetchTopics() {
    return function(dispatch) {
        axios.get(environment.apiUrl + '/api/Topics')
            .then((response) => {
                dispatch({type: "FETCH_TOPICS_FULFILLED", payload: response.data });
            })
            .catch((err) => {
                dispatch({type: "FETCH_TOPICS_REJECTED", payload: err});
            });
    }
}

/**
 * Attempts to return details of a Topic with the specified ID.
 *
 * @export
 * @param {string} id GUID of the Topic to be queried.
 * @returns
 */
export function fetchTopicDetails(id) {
    return function(dispatch) {
        axios.get(environment.apiUrl + `/api/Topics/${id}`)
            .then((response) => {
                dispatch({type: "FETCH_TOPIC_DETAILS_FULFILLED", payload: response.data});
            })
            .catch((err) => {
                dispatch({type: "FETCH_TOPICS_DETAILS_REJECTED", payload: err});
            });
    }
}

/**
 * Toggles the state of the Add Topic functionality.
 *
 * @export
 * @returns
 */
export function toggleAddTopic() {
    return function(dispatch) {
        dispatch({type: "TOGGLE_ADD_TOPIC"});
    }
}

/**
 * Toggles the state of the Add Post functionality.
 *
 * @export
 * @returns
 */
export function toggleAddPost() {
    return function(dispatch) {
        dispatch({type: "TOGGLE_ADD_POST"});
    }
}

/**
 * Attempts to create a new Topic.
 *
 * @export
 * @param {string} moderatingUserId GUID of the current User.
 * @param {string} title Title of the new Topic.
 * @param {string} description Description of the new Topic.
 * @returns
 */
export function createTopic(moderatingUserId, title, description) {
    return function(dispatch) {
        axios.post(environment.apiUrl + '/api/Topics', {
            moderatingUserId,
            title,
            description
        })
        .then((response) => {
            dispatch({type: "CREATE_TOPIC_FULFILLED", payload: response.data});
        })
        .catch((err) => {
            dispatch({type: "CREATE_TOPIC_REJECTED", payload: err});
        })
    }
}

/**
 * Attempts to create a new Post.
 *
 * @export
 * @param {string} authorId GUID of the current User.
 * @param {string} topicId GUID of the current topic.
 * @param {string} title Title of the Post.
 * @param {string} description Description of the Post.
 * @returns
 */
export function createPost(authorId, topicId, title, description) {
    return function(dispatch) {
        axios.post(environment.apiUrl + '/api/Posts', {
            title,
            description,
            authorId,
            topicId
        })
        .then((response) => {
            dispatch({type: "CREATE_POST_FULFILLED", payload: response.data});
        })
        .catch((err) => {
            dispatch({type: "CREATE_POST_REJECTED", payload: err });
        })
    }
}