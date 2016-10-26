import React from 'react';
import { connect } from 'react-redux';
import { Control, Form } from 'react-redux-form';

import * as authActions from '../actions/authActions';

@connect((store) => {
    return { auth: store.auth }
})
class Login extends React.Component {
    handleSubmit(u) {
        this.props.dispatch(authActions.fetchUser(u.username, u.password));
    }

    render() {
        return (
            <div class="login-container">
                <h3>Login</h3>
                <Form model="forms.login" onSubmit={(val) => this.handleSubmit(val)}>
                    <Control.text model="forms.login.username" class="form-control" placeholder="Enter Username"/>
                    <Control type="password" model="forms.login.password" class="form-control" placeholder="Enter Password" />
                    <button class="btn btn-default">Submit</button>
                </Form>
            </div>
        );
    }
} 

export default Login;