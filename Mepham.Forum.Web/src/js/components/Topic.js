import React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router';

import AddPost from './AddPost';

import * as topicActions from '../actions/topicActions';

@connect((store) => {
    return {
        auth: store.auth,
        topics: store.topics
    };
})
export default class Topic extends React.Component {
    componentDidMount() {
        this.props.dispatch(topicActions.fetchTopicDetails(this.props.params.topicId));
    }

    handleAddToggle() {
        this.props.dispatch(topicActions.toggleAddPost());
    }

    renderPosts() {
        if (this.props.topics.currentTopic != null) {
        return (
            <ul class="posts-container">
                {
                    this.props.topics.currentTopic.posts.map((post) => {
                        return <li key={post.id}><Link class="clickable" to={`/post/${post.id}`}>{post.title}</Link></li>
                    })
                }
            </ul>
        );
        }
        return;
    }

    renderAddPostButton() {
        return <a class="btn btn-primary btn-xs" onClick={() => this.handleAddToggle()}>
        { (this.props.topics.isAddingPost) ? 'Cancel' : 'Create Post' }</a>
    }

    renderAddPost() {
        if (!this.props.topics.isAddingPost) return null;

        return (
            <AddPost></AddPost>
        )
    }

    renderTopicDetails() {
        if (this.props.topics.currentTopic != null) {
            return (<div class="topic-detail-container well">
                <div><h3>{this.props.topics.currentTopic.title}</h3></div>
                <div><b>Moderator: </b>{this.props.topics.currentTopic.moderatingUser.username}</div>
                <div><b>Number of Posts: </b>{this.props.topics.currentTopic.posts.length}</div>
            </div>)
        }
    }

    render() {
        return (<div class="topic-container">
            {this.renderTopicDetails()}
            {this.renderAddPostButton()}
            {this.renderAddPost()}
            {this.renderPosts()}
        </div>)
    }
}