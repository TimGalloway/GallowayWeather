jQuery(document).ready(function ($) {
    $("#spinner").hide();
    $("#searchtext").keyup(function () {
        getAutoCompleteValues($("#searchtext").val());
    });
});

function getAutoCompleteValues(val) {
    if (val.length < 3) return false;
    $("#searchtext").addClass("loading");
    $.ajax({
        type: "GET",
        dataType: "json",
        jsonpCallback: "callback",
        url: "/home/AutoCompleteAsync?searchText=" + val,
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