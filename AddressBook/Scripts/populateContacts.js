$(document).ready((function () {

    $('#contactList').dataTable({
        "ajax": '/api/data/getall',
        dom: "<'row'<'col-sm-4'l><'col-sm-4 text-center'B><'col-sm-4'f>>tp",
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
        buttons: [
            { extend: 'copy', className: 'btn-sm' },
            { extend: 'csv', title: 'ExampleFile', className: 'btn-sm' },
            { extend: 'pdf', title: 'ExampleFile', className: 'btn-sm' },
            { extend: 'print', className: 'btn-sm' }
        ],
        "columns": [
            { "data": "Name" },
            { "data": "Address" },
            { "data": "City" },
            { "data": "State" },
            { "data": "ID" }
        ],
        "columnDefs": [{
            "targets": 4,
            "data": "ID",
            "render": function (data) {
                return '<a href=contact/edit/' + data + '>Edit</a>' + '&nbsp;&nbsp;&nbsp;<a href=contact/remove/' + data + '>Delete</a>';
            }
        }]
    });

}));