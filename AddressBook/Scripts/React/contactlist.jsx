var ContactList = React.createClass(
    {
        getInitialState: function () {
            return {
                items: { data: [] }
            }
        },

        componentDidMount: function () {
            var apiData;
            $.get("/api/data/getall", function (data, status) {
                apiData: data
            });

            this.setState({ items: apiData })

            var script = document.createElement('script');
            script.type = 'text/javascript';
            script.src = '/Scripts/populateContacts.js';
            $("#contact-div-script").append(script);
        },


        render: function () {

            return (

                <div>
                    <div className="normalheader transition animated fadeIn">
                        <div className="hpanel">
                            <div className="panel-body">
                                <h2 className="font-light m-b-xs">
                                    Contacts
                                </h2>
                                <small>Rendered with Reactjs</small>
                            </div>
                        </div>
                    </div>

                    <div className="content animate-panel">
                        <div className="row">
                            <div className="col-lg-12">
                                <div className="hpanel">
                                    <div className="panel-body">
                                        <div className="table-responsive">
                                            <table id="contactList" className="display table table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>Name</th>
                                                        <th>Address</th>
                                                        <th>City</th>
                                                        <th width="15%">State</th>
                                                        <th></th>
                                                    </tr>
                                                </thead>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            );
        }
    });

ReactDOM.render(
  <ContactList />,
  document.getElementById('contact-div')
);
