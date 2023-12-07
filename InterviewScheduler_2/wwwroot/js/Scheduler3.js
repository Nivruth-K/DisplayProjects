$(document).ready(function () {

      // Get Company view Component on click 
    $("#AddCompanyButton").on('click', function () {

        var companyContainer = $(".ShowCompanyCreate");
        if ((companyContainer.is(':visible'))) {
            companyContainer.hide();
        }
        else {
            companyContainer.show();
        }

        if (!companyContainer.is(':visible')) {

            $.ajax(
                {
                    url: '/ScheduleContent/Scheduler_Create?handler=CompanyComponent',
                    type: 'GET',
                    success: function (data) {
                        $(".ShowCompanyCreate").html(data);

                    },
                    error: function (error) {
                        console.error('Error fetching component:', error);
                    }
                });
        }

    }
    );

    // Get Round view Component on click 

    $("#AddRoundButton").on('click', function () {
        var createContainer = $('.ShowRoundCreate');
        if ((createContainer.is(':visible'))) {
            createContainer.hide();
        }
        else {
            createContainer.show();
        }

        if (!createContainer.is(':visible')) {
            $.ajax(
                {
                    url: '/ScheduleContent/Scheduler_Create?handler=RoundComponent',
                    type: 'GET',
                    success: function (data) {
                        $(".ShowRoundCreate").html(data);

                    },
                    error: function (error) {
                        console.error('Error fetching component:', error);
                    }
                });
        }


    });

    // Fetch company details on page load
    $.ajax({
        url: '/ScheduleContent/Scheduler_Create?handler=CompanyDetails',
        type: 'GET',
        success: function (data) {
            console.log(data);
            var companyDropdown = $('#companyDropdown');
            companyDropdown.empty();
            companyDropdown.append($('<option></option>').val('').text('Select Company')); // Placeholder option

            $.each(data, function (index, item) {
                companyDropdown.append($('<option></option>').val(item.companyId).text(item.companyName));
            });
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error fetching company details:', errorThrown);
        }
    });

    // Fetch round details on page load
    $.ajax({
        url: '/ScheduleContent/Scheduler_Create?handler=RoundDetails',
        type: 'GET',
        success: function (data) {
            console.log(data);
            var roundDropdown = $('#roundDropdown');
            roundDropdown.empty();
            roundDropdown.append($('<option></option>').val('').text('Select Round')); // Placeholder option

            $.each(data, function (index, item) {
                roundDropdown.append($('<option></option>').val(item.roundId).text(item.round_Type));
            });
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error fetching round details:', errorThrown);
        }
    });

    //on Round Created Trigger
    $(document).on('roundCreated', function (event, data) {
        var roundDropdown = $('#roundDropdown');
        roundDropdown.empty();
        roundDropdown.append($('<option></option>').val('').text('Select Round')); // Placeholder option
        $.each(data, function (index, item) {
            roundDropdown.append($('<option></option>').val(item.roundId).text(item.round_Type));
        });
        alert("Round added");
    });

    //on Company Created Trigger
    $(document).on('companyCreated', function (event, data) {
        var companyDropdown = $('#companyDropdown');
        companyDropdown.empty();
        companyDropdown.append($('<option></option>').val('').text('Select Company')); // Placeholder option
        $.each(data, function (index, item) {
            companyDropdown.append($('<option></option>').val(item.companyId).text(item.companyName));
        });
        alert("Company added");
    });



});
