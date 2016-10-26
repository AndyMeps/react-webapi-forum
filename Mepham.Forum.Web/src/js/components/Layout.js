import React from "react"
import { connect } from "react-redux"

import Login from './Login';

@connect((store) => {
    return {
        auth: store.auth
    };
})
export default class Layout extends React.Component {
    render() {
        return <div class="container"><Login /></div>;
    }
}