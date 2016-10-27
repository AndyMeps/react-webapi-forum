import React from "react"
import { connect } from "react-redux"

import Login from './Login';

@connect((store) => {
    return {
        auth: store.auth
    };
})
export default class Layout extends React.Component {
    render() {
        if (!this.props.auth.isAuthenticated) {
            return  (<div class="container">
                        <Login />
                    </div>);
        }
        return <div class="container">Logged in!</div>;
    }
}