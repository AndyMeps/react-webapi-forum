import * as _ from 'lodash';

export default function reducer(state={
    items: [],
    currentTopic: null,
    isAddingTopic: false,
    isAddingPost: false,
    error: null
}, action) {
    
    switch(action.type) {
        case "FETCH_TOPICS": {
            return {...state};
        }
        case "FETCH_TOPICS_REJECTED": {
            return {
                ...state,
                error: action.payload
            };
        }
        case "FETCH_TOPICS_FULFILLED": {
            return {
                ...state,
                items: action.payload,
                error: null
            };
        }
        case "FETCH_TOPIC_DETAILS": {
            return {...state};
        }
        case "FETCH_TOPIC_DETAILS_REJECTED": {
            return {
                ...state,
                error: action.payload
            };
        }
        case "FETCH_TOPIC_DETAILS_FULFILLED": {
            return {
                ...state,
                currentTopic: action.payload,
                error: null
            };
        }
        case "TOGGLE_ADD_TOPIC": {
            return {
                ...state,
                isAddingTopic: !state.isAddingTopic
            }
        }
        case "CREATE_TOPIC_FULFILLED": {
            return {
                ...state,
                items: state.items.concat(action.payload),
                error: null,
                isAddingTopic: false
            }
        }
        case "CREATE_TOPIC_REJECTED": {
            return {
                ...state,
                error: action.payload
            }
        }
        case "TOGGLE_ADD_POST": {
            return {
                ...state,
                isAddingPost: !state.isAddingPost
            }
        }
        case "CREATE_POST_FULFILLED": {
            debugger;
            let newState = _.cloneDeep(state);
            newState.isAddingPost = false;
            newState.error = null;
            newState.currentTopic.posts.push(action.payload);

            return newState;
        }
        case "CREATE_POST_REJECTED": {
            return {
                ...state,
                error: action.payload
            }
        }
    }

    return state;

}