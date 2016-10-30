import React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router';
import moment from 'moment';

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

    renderPostDetail() {
        let post = this.props.post.currentPost;

        if (post == null) return null;
        
        return (<div class="post-detail-container well">
            <h3>{post.title} <small>posted by {post.author.username}</small></h3>
            <p>{post.description}</p>
        </div>);
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
        let formattedDate = moment(comment.createDateTime).format('DD MMM YYYY');
        return (
            <div class="comment" key={comment.id}>
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
                {this.renderPostDetail()}
                <div class="comments-container">{this.renderComments()}</div>
            </div>
        );
    }
}