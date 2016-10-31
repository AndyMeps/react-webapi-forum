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

    /**
     * Lifecycle hook.
     *
     * @memberOf Topic
     */
    componentDidMount() {
        this.props.dispatch(topicActions.fetchTopicDetails(this.props.params.topicId));
    }

    /**
     * Called when the 'Add Topic'/'Cancel' button is clicked.
     *
     *
     * @memberOf Topic
     */
    handleAddToggle() {
        this.props.dispatch(topicActions.toggleAddPost());
    }

    /**
     * Renders a Back button when the state is loaded.
     *
     * @returns
     *
     * @memberOf Topic
     */
    renderNavigation() {
        return (
            <Link to={'/home'}>Back</Link>
        )
    }

    /**
     * Enumerates of the current Topic's Posts.
     *
     * @returns JSX
     *
     * @memberOf Topic
     */
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

    /**
     * Renders an 'Add Post' button, will render a 'Cancel' button when isAddingPost == true.
     *
     * @returns
     *
     * @memberOf Topic
     */
    renderAddPostButton() {
        return <a class="btn btn-primary btn-xs" onClick={() => this.handleAddToggle()}>
        { (this.props.topics.isAddingPost) ? 'Cancel' : 'Create Post' }</a>
    }

    /**
     * Renders the AddPost component.
     *
     * @returns JSX
     *
     * @memberOf Topic
     */
    renderAddPost() {
        if (!this.props.topics.isAddingPost) return null;

        return (
            <AddPost></AddPost>
        )
    }

    /**
     * Renders details pertaining to the current Topic.
     *
     * @returns JSX
     *
     * @memberOf Topic
     */
    renderTopicDetails() {
        if (this.props.topics.currentTopic != null) {
            return (<div class="topic-detail-container well">
                <div><h3>{this.props.topics.currentTopic.title}</h3></div>
                <div><b>Moderator: </b>{this.props.topics.currentTopic.moderatingUser.username}</div>
                <div><b>Number of Posts: </b>{this.props.topics.currentTopic.posts.length}</div>
            </div>)
        }
    }

    /**
     * Combines and renders the Topic page.
     *
     * @returns
     *
     * @memberOf Topic
     */
    render() {
        return (<div class="topic-container">
            {this.renderNavigation()}
            {this.renderTopicDetails()}
            {this.renderAddPostButton()}
            {this.renderAddPost()}
            {this.renderPosts()}
        </div>)
    }
}