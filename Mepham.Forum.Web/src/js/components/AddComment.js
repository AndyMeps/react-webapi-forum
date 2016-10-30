import React from 'react';
import { connect } from 'react-redux';
import { Control, Form } from 'react-redux-form';
import * as validation from '../helpers/validation';

import * as postActions from '../actions/postActions';

@connect((store) => {
    return { auth: store.auth, topics: store.topics }
})
class AddComment extends React.Component {
    render() {
        return (<div></div>)
    }
}

export default AddComment;