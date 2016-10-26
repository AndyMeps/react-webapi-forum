export default function reducer(state={
    user: {
        username: null,
        password: null,
        passwordConfirm: null
    },
    isAuthenticated: false,
    error: null
}, action) {
    
    switch (action.type) {
        case "FETCH_USER": {
            return {...state}
        }
        case "FETCH_USER_REJECTED": {
            return {
                ...state,
                error: action.payload
            }
        }
        case "FETCH_USER_FULFILLED": {
            return {
                ...state,
                user: action.payload,
                isAuthenticated: true
            }
        }
    }

    return state;

}