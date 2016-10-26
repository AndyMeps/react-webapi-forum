import React from "react"
import { connect } from "react-redux"


@connect((store) => {
    return {};
})
export default class Layout extends React.Component {
    render() {
        return  <div>
                    <p>Nothing here yet...</p>
                    <p>Testing Live Reload</p>
                </div>;
    }
}