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

    componentDidMount() {
        this.props.dispatch(topicActions.fetchTopics());
    }

    handleAddToggle() {
        this.props.dispatch(topicActions.toggleAddTopic());
    }

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

    renderAddTopicButton() {
        return <a class="btn btn-primary btn-xs" onClick={() => this.handleAddToggle()}>
        { (this.props.topics.isAddingTopic) ? 'Cancel' : 'Create Topic' }</a>
    }

    renderAddTopic() {
        if (!this.props.topics.isAddingTopic) return null;

        return (
            <AddTopic></AddTopic>
        )
    }

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