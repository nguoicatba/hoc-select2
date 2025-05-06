$(document).ready(function () {
    $('#example').DataTable({
        "searching": false, 
       
        "ajax": {
            "url": "/Home/GetDataTable",
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "id" },
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