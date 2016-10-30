export default function reducer(state={
    currentPost: null,
    comments: [],
    error: null,
    isAddingComment: false
}, action) {

    switch(action.type) {
        case "FETCH_POST_DETAILS_REJECTED": {
            return {
                ...state,
                error: action.payload
            };
        }
        case "FETCH_POST_DETAILS_FULFILLED": {
            return {
                ...state,
                currentPost: action.payload,
                error: null
            };
        }
        case "FETCH_POST_COMMENTS_REJECTED": {
            return {
                ...state,
                error: action.payload
            };
        }
        case "FETCH_POST_COMMENTS_FULFILLED": {
            return {
                ...state,
                comments: action.payload,
                error: null
            };
        }
        case "TOGGLE_ADD_COMMENT": {
            return {
                ...state,
                isAddingComment: !state.isAddingComment
            }
        }
        case "ADD_COMMENT_FULFILLED": {
            return {
                ...state,
                isAddingComment: false,
                error: null,
                comments: state.comments.concat(action.payload)
            }
        }
        case "ADD_COMMENT_REJECTED": {
            return {
                ...state,
                error: action.payload
            }
        }
    }

    return state;
}