import React from 'react';
import { connect} from 'react-redux';
import { Control, Form } from 'react-redux-form';
import * as validation from '../helpers/validation';

import * as topicActions from '../actions/topicActions';

@connect((store) => {
    return { auth: store.auth, topics: store.topics }
})
class AddTopic extends React.Component {

    handleSubmit(t) {
        this.props.dispatch(topicActions.createTopic(this.props.auth.user.id, t.title, t.description));
    }

    errorMessage() {
        if (this.props.topics.error == null) return null;

        let errorDetails = this.props.topics.error.data;

        return (
            <div class="error-container">
                <p class="text-danger">{this.props.topics.error.data.message}</p>
                {validation.renderValidationErrors(errorDetails.modelState)}
            </div>
        )
    }

    render() {
        return (
            <div class="add-topic-container">
                <h3>Add Topic</h3>
                <Form model="forms.addTopic" onSubmit={(val) => this.handleSubmit(val)}>
                    <Control type="text" model="forms.addTopic.title" class="form-control" placeholder="Topic Title" />
                    <Control type="text" model="forms.addTopic.description" class="form-control" placeholder="Topic Description" />
                    <button class="btn btn-default">Add Topic</button>
                </Form>

                {this.errorMessage()}
            </div>
        )
    }
}

export default AddTopic;