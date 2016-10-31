import React from 'react';
import { connect } from 'react-redux';
import { Control, Form } from 'react-redux-form';
import * as validation from '../helpers/validation';

import * as topicActions from '../actions/topicActions';

@connect((store) => {
    return { auth: store.auth, topics: store.topics }
})
class AddPost extends React.Component {

    /**
     * Called when the 'Add Post' button is clicked.
     *
     * @param {any} p Represents the addPost form state.
     *
     * @memberOf AddPost
     */
    handleSubmit(p) {
        this.props.dispatch(topicActions.createPost(this.props.auth.user.id, this.props.topics.currentTopic.id, p.title, p.description));
    }

    /**
     * Render error message section, will render nothing if no error message state.
     *
     * @returns JSX
     *
     * @memberOf AddPost
     */
    errorMessage() {
        if (this.props.topics.error == null) return null;

        let errorDetails = this.props.topics.error.data;

        return (
            <div class="error-container">
                <p class="text-danager">{this.props.topics.error.data.message}</p>
                {validation.renderValidationErrors(errorDetails.modelState)}
            </div>
        )
    }

    /**
     * Render the Add Post form.
     *
     * @returns JSX
     *
     * @memberOf AddPost
     */
    render() {
        return (
            <div class="add-post-container">
                <h3>Add Post</h3>
                <Form model="forms.addPost" onSubmit={(val) => this.handleSubmit(val)}>
                    <Control type="text" model="forms.addPost.title" class="form-control" placeholder="Enter title"/>
                    <Control type="text" model="forms.addPost.description" class="form-control" placeholder="Enter description" />
                    <button class="btn btn-default">Add Post</button>
                </Form>

                {this.errorMessage()}
            </div>
        )
    }
}

export default AddPost;