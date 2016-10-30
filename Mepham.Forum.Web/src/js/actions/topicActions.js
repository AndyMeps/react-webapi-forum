import axios from 'axios';
import { push } from 'react-router-redux';
import { environment } from '../env';

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

export function toggleAddTopic() {
    return function(dispatch) {
        dispatch({type: "TOGGLE_ADD_TOPIC"});
    }
}

export function toggleAddPost() {
    return function(dispatch) {
        dispatch({type: "TOGGLE_ADD_POST"});
    }
}

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