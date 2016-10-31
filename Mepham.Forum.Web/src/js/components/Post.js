import React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router';
import moment from 'moment';

import AddComment from './AddComment';

import * as postActions from '../actions/postActions';

@connect((store) => {
    return {
        auth: store.auth,
        post: store.post
    };
})
export default class Topic extends React.Component {

    /**
     * Lifecycle hook.
     *
     * @memberOf Topic
     */
    componentDidMount() {
        this.props.dispatch(postActions.fetchPostDetails(this.props.params.postId));
        this.props.dispatch(postActions.fetchPostComments(this.props.params.postId));
    }

    /**
     * Called when the 'Add Comment'/'Cancel' button is clicked.
     *
     * @memberOf Topic
     */
    handleAddCommentToggle() {
        this.props.dispatch(postActions.toggleAddComment());
    }

    /**
     * Renders a Back button when the state is loaded.
     *
     * @returns
     *
     * @memberOf Topic
     */
    renderNavigation() {
        if (this.props.post.currentPost == null) return null;

        return (
            <Link to={`/topic/${this.props.post.currentPost.topic.id}`}>Back</Link>
        )
    }

    /**
     * Renders details pertaining to the current Post.
     *
     * @returns JSX
     *
     * @memberOf Topic
     */
    renderPostDetail() {
        let post = this.props.post.currentPost;

        if (post == null) return null;

        return (<div class="post-detail-container well">
            <h3>{post.title} <small>posted by {post.author.username}</small></h3>
            <p>{post.description}</p>
        </div>);
    }

    /**
     * Renders an 'Add Comment', will display a 'Cancel' button when isAddingComment == true
     *
     * @returns JSX
     *
     * @memberOf Topic
     */
    renderAddCommentButton() {
        return <a class="btn btn-primary btn-xs" onClick={() => this.handleAddCommentToggle()}>
        { (this.props.post.isAddingComment) ? 'Cancel' : 'Create Comment'}</a>
    }

    /**
     * Renders the AddComment component.
     *
     * @returns
     *
     * @memberOf Topic
     */
    renderAddComment() {
        if (!this.props.post.isAddingComment) return null;

        return (
            <AddComment></AddComment>
        )
    }

    /**
     * Renders all comments on the current Post.
     *
     * @returns JSX
     *
     * @memberOf Topic
     */
    renderComments() {
        let comments = this.props.post.comments;

        if (comments.length <= 0) return null;

        return(
            comments.map((comment) => {
                return this.renderComment(comment)
            })
        );
    }

    /**
     * Recursively renders comments and replies to comments in a nested format.
     *
     * @param {any} comment Comment object to be rendered
     * @returns JSX
     *
     * @memberOf Topic
     */
    renderComment(comment) {
        let formattedDate = moment(comment.createDateTime).format('lll');
        return (
            <div class="comment" key={comment.id}>
                <h4>{comment.author.username} says:</h4>
                <div>{comment.description} - {formattedDate}</div>
                {
                    comment.replies.map((reply) => {
                        return this.renderComment(reply)
                    })
                }
            </div>
        )
    }

    /**
     * Combines and renders the Post page.
     *
     * @returns JSX
     *
     * @memberOf Topic
     */
    render() {
        return (
            <div class="post-container">
                {this.renderNavigation()}
                {this.renderPostDetail()}
                {this.renderAddCommentButton()}
                {this.renderAddComment()}
                <div class="comments-container">{this.renderComments()}</div>
            </div>
        );
    }
}