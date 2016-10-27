import React from "react"
import { connect } from "react-redux";
import { Link } from 'react-router';

import Login from './Login';

export default class Layout extends React.Component {
    render() {
        return (
            <div class="container">
                <header>
                    Links: { ' ' } <Link to="/">Home</Link>
                    { ' ' }
                    <Link to="/login">Login</Link>
                </header>
                {this.props.children}
            </div>);
    }
}