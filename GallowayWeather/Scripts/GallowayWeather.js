jQuery(document).ready(function ($) {
    var language = "en";
    var isMetric = true;
    var apiKey = "URhjqAbLAibbb6EEnwzYSp9OzkKGp6jF";  

    var LocationLookUp = function (freeText) {
        locationUrl = "http://dataservice.accuweather.com/locations/v1/search?q=" + freeText + "&apikey=" + apiKey;
        $.ajax({
            type: "GET",
            url: locationUrl,
            dataType: "jsonp",
            cache: true,                    // Use cache for better reponse times
            jsonpCallback: "awxCallback",   // Prevent unique callback name for better reponse times
            success: function (data) { LookUpFound(data); }
        });
    };

    var awxGetCurrentConditions = function (locationKey) {
        currentConditionsUrl = "http://dataservice.accuweather.com/currentconditions/v1/" +
            locationKey + ".json?language=" + language + "&apikey=" + apiKey;
        $.ajax({
            type: "GET",
            url: currentConditionsUrl,
            dataType: "jsonp",
            cache: true,                    // Use cache for better reponse times
            jsonpCallback: "awxCallback",   // Prevent unique callback name for better reponse times
            success: function (data) {
                var html;
                if (data && data.length > 0) {
                    var conditions = data[0];
                    var temp = isMetric ? conditions.Temperature.Metric : conditions.Temperature.Imperial;
                    html = conditions.WeatherText + ", " + temp.Value + " " + temp.Unit;
                }
                else {
                    html = "N/A";
                }
                $("#awxWeatherInfo").html(html);
                $("#awxWeatherUrl").html("<a href=" + currentConditionsUrl + ">" + currentConditionsUrl + "</a>");
            }
        });
    };

    var LookUpFound = function (data) {
        var msg, locationKey = null;
        $("#awxLocationUrl").html("<a href=" + encodeURI(locationUrl) + ">" + locationUrl + "</a>");
        if (data.length == 1) {
            locationKey = data[0].Key;
            msg = "One location found: <b>" + data[0].LocalizedName + "</b>. Key: " + locationKey;
        }
        else if (data.length == 0) {
            msg = "No locations found."
        }
        else {
            locationKey = data[0].Key;
            msg = "Multiple locations found (" + data.length + "). Selecting the first one: " +
                "<b>" + data[0].LocalizedName + ", " + data[0].Country.ID + "</b>. Key: " + locationKey;
        }
        $("#awxLocationInfo").html(msg);
        if (locationKey != null) {
            awxGetCurrentConditions(locationKey);
        }

    };

    $("#btnLocationSearch").click(function () {
        var text = $("#txtLocation").val();
        LocationLookUp(text);
    });
});