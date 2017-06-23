jQuery(document).ready(function ($) {
    //$("#searchtext").keyup(function () {
    //    getAutoCompleteValues($("#searchtext").val());
    //});

    $('#spinner').hide(); 



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