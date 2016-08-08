var Greeting = React.createClass({
    render: function () {
        return (React.createElement("p", null, "Hello, Universe"));
    }
});
ReactDOM.render(React.createElement(Greeting, null), document.getElementById('greeting-div'));
