jQuery(document).ready(function ($) {
    $('input[type=radio][name=lstWeatherType]').on('change', function () {
        switch ($(this).val()) {
            case 'AccuWeather':
                $("#divResults").show();
                break;
            case 'OpenWeather':
                $("#divResults").hide();
                break;
        }
    });
    switch ($('input[type=radio][name=lstWeatherType]')) {
        case 'AccuWeather':
            alert($(this).val());
                $("#divResults").show();
                break;
        case 'OpenWeather':
            alert($(this).val());
                $("#divResults").hide();
                break;
        }
    


    $("#searchtext").keyup(function () {
        if ($("#lstWeatherType:checked").val() == "AccuWeather") {
            getAutoCompleteValues($("#searchtext").val(), "AccuWeather");
        }
    });
});

function getAutoCompleteValues(val, weatherType) {
    if (val.length < 3) return false;
    $("#searchtext").addClass("loading");
    $.ajax({
        type: "GET",
        dataType: "json",
        jsonpCallback: "callback",
        url: "/home/AutoCompleteAsync?weatherType=" + weatherType + "&searchText=" + val,
        cache: false,
        success: function (data) {
            $("#lstResults").html('');
            $.each(data, function (i, item) {
                $("#lstResults").append('<option value="' + item.Key + '">' + item.LocalizedName + ', ' + item.Country.LocalizedName + '</option>');
            });
            $("#searchtext").removeClass("loading");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
            $("#searchtext").removeClass("loading");
        }
    });
}