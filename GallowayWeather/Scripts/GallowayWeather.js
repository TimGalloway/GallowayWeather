jQuery(document).ready(function ($) {
    //$("#searchtext").keyup(function () {
    //    getAutoCompleteValues($("#searchtext").val());
    //});

    $('#spinner').hide(); 
    $('#searchtext').autocomplete({
        minLength: 4,
        delay: 1000,
        source: function (request, response) {
            $('#spinner').show(); 
            $.ajax({
                url: "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=URhjqAbLAibbb6EEnwzYSp9OzkKGp6jF",
                dataType: 'json',
                data: { q: request.term },
                success: function (data) {
                    var out = "";
                    $(data).each(function (i, val) {
                        out = out + val.LocalizedName;
                    });
                    response(out);
                    $('#spinner').hide();
                },
                error: function (data) {
                    $('#spinner').hide();
                }
            }); 
        },
        open: function () {
            $(this).removeClass('ui-corner-all').addClass('ui-corner-top');
        },
        close: function () {
            $(this).removeClass('ui-corner-top').addClass('ui-corner-all');
        } 
    });


 });

//function getAutoCompleteValues(val) {
//    if (val.length < 3) return false;
//    $.ajax({
//        type: "GET",
//        dataType: "jsonp",
//        jsonp: "callback", jsonpCallback: "callback",
//        url: "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=URhjqAbLAibbb6EEnwzYSp9OzkKGp6jF&q=" + val,
//        cache: false,
//        success: function (data) {
//            $("#lstResults").html('');
//            $.each(data, function (i, item) {
//                $("#lstResults").append('<option value="' + item.Key + '">' + item.LocalizedName + ', ' + item.Country.LocalizedName + '</option>');
//            }
//        )}
//    });
// }