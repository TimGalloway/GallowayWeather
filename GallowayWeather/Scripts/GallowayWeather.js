jQuery(document).ready(function ($) {
        $("#searchtext").keyup(function () {
            //getAutoCompleteValues($("#searchtext").first().attr("value"));
            getAutoCompleteValues($("#searchtext").val());
        });
 });

function getAutoCompleteValues(val) {
    //alert(val);
    //alert(val.length);
    if (val.length < 3) return false;
    $.ajax({
        type: "GET",
        dataType: "jsonp",
        jsonp: "callback", jsonpCallback: "callback",
        url: "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=URhjqAbLAibbb6EEnwzYSp9OzkKGp6jF&q=" + val,
        cache: false,
        success: function (data) {
            $("#results").html('');
            $.each(data, function (i, item) {
                alert(item.LocalizedName + ", " + item.AdministrativeArea.ID + ", " + item.Country.ID);
                $("#results")
                    .append(item.LocalizedName + ", " + item.AdministrativeArea.ID + ", " + item.Country.ID);
                });
            }
      });
 }