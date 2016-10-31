import React from "react"
import { connect } from "react-redux";
import { Link } from 'react-router';
import AddTopic from './AddTopic';

import * as topicActions from '../actions/topicActions';

@connect((store) => {
    return {
        auth: store.auth,
        topics: store.topics
    };
})
export default class Home extends React.Component {

    /**
     * Lifecycle handler.
     *
     *
     * @memberOf Home
     */
    componentDidMount() {
        this.props.dispatch(topicActions.fetchTopics());
    }

    /**
     * Called when the 'Add Topic' button is clicked - Show and Hide
     *
     *
     * @memberOf Home
     */
    handleAddToggle() {
        this.props.dispatch(topicActions.toggleAddTopic());
    }

    /**
     * Enumerate over each topic and display as a list.
     *
     * @returns JSX
     *
     * @memberOf Home
     */
    renderTopics() {
        return (
            <ul class="topics-container">
                {
                    this.props.topics.items.map((topic) => {
                        return (
                            <li key={topic.id}>
                                <Link to={`/topic/${topic.id}`}>{topic.title}</Link><small> {topic.description}</small>
                            </li>
                        );
                    })
                }
            </ul>
        );
    }

    /**
     * Renders the 'Add Topic' button, will display a 'Cancel' button when isAddingTopic == true
     *
     * @returns JSX
     *
     * @memberOf Home
     */
    renderAddTopicButton() {
        return <a class="btn btn-primary btn-xs" onClick={() => this.handleAddToggle()}>
        { (this.props.topics.isAddingTopic) ? 'Cancel' : 'Create Topic' }</a>
    }

    /**
     * Renders the AddTopic component if isAddingTopic == true.
     *
     * @returns JSX
     *
     * @memberOf Home
     */
    renderAddTopic() {
        if (!this.props.topics.isAddingTopic) return null;

        return (
            <AddTopic></AddTopic>
        )
    }

    /**
     * Combines all rendered page elements.
     *
     * @returns JSX
     *
     * @memberOf Home
     */
    render() {
        return (
            <div class="home-container">
                <div>Home</div>
                {this.renderAddTopicButton()}
                {this.renderAddTopic()}
                {this.renderTopics()}
            </div>
        );
    }
}