export default function reducer(state={
    user: {
        id: null,
        username: null
    },
    isAuthenticated: false,
    error: null
}, action) {
    
    switch (action.type) {
        case "LOGIN_USER": {
            return {...state}
        }
        case "LOGIN_USER_REJECTED": {
            return {
                ...state,
                error: action.payload
            }
        }
        case "LOGIN_USER_FULFILLED": {
            return {
                ...state,
                user: action.payload,
                isAuthenticated: true,
                error: null
            }
        }
        case "LOGOUT_USER": {
            return {
                ...state,
                user: {
                    id: null,
                    username: null
                },
                isAuthenticated: false,
                error: null
            }
        }
    }

    return state;

}