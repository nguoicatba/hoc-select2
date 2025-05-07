$(document).ready(function () {
    $('#example').DataTable({
       
       
        "ajax": {
            "url": "/Home/GetDataTable",
            "type": "GET",
            "datatype": "json"
        },
        "layout": {
            "top2Start": 'search',
          
            "topStart": 'info',

            "topEnd": function () {
                return '<button class="btn btn-primary" id="btnExport">Export</button>';
            },

            "bottom": 'paging',
            "bottomStart": null,
            "bottomEnd": null,
        },

        "columns": [

            {
                "data": "id",
                "render": function (data, type, row) {
                    return '<input type="checkbox" class="select-checkbox" value="' + data.id + '">';
                },
                "orderable": false,
                "searchable": false
            },
            {
                "data": "id",
                
            },
            { "data": "name" },
            { "data": "email" },
            { "data": "phone" },
            { "data": "address" },
            { "data": "city" },
            { "data": "state" },
            { "data": "zipCode" },
            { "data": "createdAt" },
            { "data": "updatedAt" }
           
        ]
    });

    
});