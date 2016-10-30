import React from 'react';
import { connect } from 'react-redux';
import { Control, Form } from 'react-redux-form';
import * as validation from '../helpers/validation';

import * as postActions from '../actions/postActions';

@connect((store) => {
    return { auth: store.auth, post: store.post }
})
class AddComment extends React.Component {

    handleSubmit(c) {
        this.props.dispatch(postActions.addComment(this.props.auth.user.id, null, this.props.post.currentPost.id, c.description));
    }

    errorMessage() {
        if (this.props.post.error == null) return null;

        let errorDetails = this.props.post.error.data;

        return (
            <div class="error-container">
                <p class="text-danger">{this.props.post.error.data.message}</p>
                {validation.renderValidationErrors(errorDetails.modelState)}
            </div>
        )
    }

    render() {
        return (
            <div class="add-comment-container">
                <h3>Add Comment</h3>
                <Form model="forms.addComment" onSubmit={(val) => this.handleSubmit(val)}>
                    <Control type="text" model="forms.addComment.description" class="form-control" placeholder="Enter comment." />
                    <button class="btn btn-default">Add Comment</button>
                </Form>

                {this.errorMessage()}
            </div>
        )
    }
}

export default AddComment;