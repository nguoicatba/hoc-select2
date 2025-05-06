$(document).ready(function() {


    let Headers = "";
    let Headers2 = "";
    function formatState2(state) {

        if (!state.id) {
            return state.text;
        }

        if (state.id == '-1') {
            var $state = $(
                '<div class="row px-2 py-1" style="background-color:#d1e7dd; color:#0f5132; font-weight:bold; border-radius:4px;">' +
                '<div class="col-4">' + Headers + '</div>' +
                '<div class="col-8">' + Headers2 + '</div>' +
                '</div>'
            );
            return $state;
        }

        var $state = $(
            '<div class="row px-2 py-1">' +
            '<div class="col-4">' + state.id + '</div>' +
            '<div class="col-8">' + state.text + '</div>' +
            '</div>'


        );
        return $state;
    }
    // Function to format the state
    function formatState(state) {

        if (!state.id) {
            return state.text;
        }
        var $state = $(
            '<span>' + state.id + state.text + '</span>'

        );
        return $state;
    }
    // Initialize Select2
    $('.js-example-basic-multiple').each(function() {
        const $select = $(this);
        const url = $select.data('url');

        $select.select2({
            ajax: {
                url: url,
                dataType: 'json',
               
              
             

                data: function(params) {
                    return {
                        q: params.term || '',
                        page: params.page
                    };
                },
                processResults: function(data, params) {
                    params.page = params.page || 1;
                    Headers = data.header_code;
                    Headers2 = data.header_name;

                    return {
                        results: data.items,
                        pagination: {
                            more: (params.page * 10) < data.total_count
                        }
                    };
                },
                cache: true
            },
            minimumInputLength: 0,
            templateResult: formatState2,
            templateSelection: formatState,


            placeholder: 'Select an option Code - Name'
        });
    });

    $('.js-example-basic-multiple').on('select2:select', function(e) {
        var data = e.params.data;
        console.log(data);
        $('#kien').val(data.id);

        
       
    });

    $('.js-example-basic-multiple').on('select2:select', function () {
        $.ajax({
            url: 'Home/GetInfor',
            type: 'POST',

            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('access_token')  // Gửi token trong header
            },
   
            success: function (response) {
                // Handle the response from the server
                $('#kien2').val(response.id + '\n' + response.name + '\n' + response.age); // Assuming the response contains the data you want to set in the textarea
            },
            error: function (xhr, status, error) {
                // Handle any errors
                console.error(error);
            }
        });
    });




});
