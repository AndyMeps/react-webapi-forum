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
    componentDidMount() {
        this.props.dispatch(postActions.fetchPostDetails(this.props.params.postId));
        this.props.dispatch(postActions.fetchPostComments(this.props.params.postId));
    }

    handleAddCommentToggle() {
        this.props.dispatch(postActions.toggleAddComment());
    }
    
    renderNavigation() {
        if (this.props.post.currentPost == null) return null;

        return (
            <Link to={`/topic/${this.props.post.currentPost.topic.id}`}>Back</Link>
        )
    }

    renderPostDetail() {
        let post = this.props.post.currentPost;

        if (post == null) return null;
        
        return (<div class="post-detail-container well">
            <h3>{post.title} <small>posted by {post.author.username}</small></h3>
            <p>{post.description}</p>
        </div>);
    }

    renderAddCommentButton() {
        return <a class="btn btn-primary btn-xs" onClick={() => this.handleAddCommentToggle()}>
        { (this.props.post.isAddingComment) ? 'Cancel' : 'Create Comment'}</a>
    }

    renderAddComment() {
        if (!this.props.post.isAddingComment) return null;

        return (
            <AddComment></AddComment>
        )
    }

    renderComments() {
        let comments = this.props.post.comments;

        if (comments.length <= 0) return null;

        return(
            comments.map((comment) => {
                return this.renderComment(comment)
            })
        );
    }

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