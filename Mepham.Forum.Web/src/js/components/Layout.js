import React from "react"
import { connect } from "react-redux";
import { Link } from 'react-router';

import Login from './Login';

import * as authActions from '../actions/authActions';

@connect((store) => {
    return {
        auth: store.auth
    }
})
export default class Layout extends React.Component {

    /**
     * Renders the top navigation allowing the User to log out when isAuthenticated == true
     *
     * @returns JSX
     *
     * @memberOf Layout
     */
    renderNavigation() {
        if (this.props.auth.isAuthenticated) {
            return (<nav class="navbar navbar-default">
                        <div class="container-fluid">
                            <ul class="nav navbar-nav">
                                <li><a class="clickable" onClick={() => this.handleLogout()}>Logout</a></li>
                            </ul>
                        </div>
                    </nav>);
        }
        return null;
    }

    /**
     * Called when the 'Log Out' link is clicked.
     *
     *
     * @memberOf Layout
     */
    handleLogout() {
        this.props.dispatch(authActions.logoutUser());
    }

    /**
     * Combines page elements.
     *
     * @returns JSX
     *
     * @memberOf Layout
     */
    render() {
        return (
            <div class="container">
                {this.renderNavigation()}
                {this.props.children}
            </div>);
    }
}