function submitSuccess(data, textStatus, jqXHR) {
    console.log('Success!');
    console.log(data);
}

function submitError(data, textStatus, jqXHR) {
    console.log('Error!');
    console.log(data);
}

function submit() {
    var place = autocompleteOrigin.getPlace();
    var Olong = place.geometry.location.A;
    var Olat = place.geometry.location.k;
    place = autocompleteDest.getPlace();
    var now = new Date();
    var Dlong = place.geometry.location.A;
    var Dlat = place.geometry.location.k;

    var origin = $('#origin').val();
    var destination = $('#destination').val();

    var departureTime = null;
    var arrivalTime = null;

    if ($("#when2").val() == "0")
        departureTime = $("#time").val();
    else
        arrivalTime = $("#time").val();

    var obj = {
        Origin:
        {
            Name: origin,
            Lat: Olat,
            Long: Olong,
        },
        Destination:
        {
            Name: destination,
            Lat: Dlat,
            Long: Dlong,
        },
        DepartureTime: departureTime,
        ArrivalTime: arrivalTime,
        Vehicle: {
            Fuel: {
                Type: $("#fuel-type").val(),
                Value: $("#fuel-value").val()
            }
        }
    };

    $.ajax({
        url: '/farolverde/GetRoute',
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify(obj),
        contentType: 'application/json; charset=utf-8',
        success: submitSuccess,
        error: submitError
    });
}

var placeSearch, autocompleteOrigin, autocompleteDest, Route;

var componentForm = {
    street_number: 'short_name',
    route: 'long_name',
    locality: 'long_name',
    administrative_area_level_1: 'short_name',
    country: 'long_name',
    postal_code: 'short_name'
};

function initialize() {
    // Create the autocomplete object, restricting the search
    // to geographical location types.
    autocompleteOrigin = new google.maps.places.Autocomplete(
        (document.getElementById('origin')),
        { types: ['geocode'] });

    autocompleteDest = new google.maps.places.Autocomplete(
      (document.getElementById('destination')),
      { types: ['geocode'] });
    // When the user selects an address from the dropdown,
    // populate the address fields in the form.
    google.maps.event.addListener(autocompleteOrigin, 'place_changed', function () {
        fillLatLong('origin');
    });

    google.maps.event.addListener(autocompleteDest, 'place_changed', function () {
        fillLatLong('destination');
    });
}

// [START region_fillform]
function fillLatLong(source) {
    // Get the place details from the autocomplete object.
    var input, place;
    if (source == 'origin') {
        place = autocompleteOrigin.getPlace();
        input = $("#divGeoOrigin")
    } else {
        place = autocompleteDest.getPlace();
        input = $("#divGeoDest")
    }

    console.log(source + ' result');
    console.log(place);
    var long = place.geometry.location.A;
    var lat = place.geometry.location.k;
    input.html('Result: ' + lat + ',' + long)
}

function fillLatLongDest() {
    var place = autocompleteDest.getPlace();
    console.log('Origin result');
    console.log(autocompleteDest.getPlace());
}

function geolocate() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var geolocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            autocompleteOrigin.setBounds(new google.maps.LatLngBounds(geolocation, geolocation));
            autocompleteDest.setBounds(new google.maps.LatLngBounds(geolocation, geolocation));
        });
    }
}

$(function () {
    $('input[type=text]').val('');
    initialize();
});

$(document).ready(function () {
    var now = new Date();

    $("#when").val(now.getDate() + "/" + (now.getMonth() + 1) + "/" + now.getFullYear());
    $("#when").datepicker({
        minDate: now
    });
});




window.fbAsyncInit = function () {
    FB.init({
        appId: '275806335921003',
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        xfbml: true  // parse XFBML
    });

    // Here we subscribe to the auth.authResponseChange JavaScript event. This event is fired
    // for any authentication related change, such as login, logout or session refresh. This means that
    // whenever someone who was previously logged out tries to log in again, the correct case below 
    // will be handled. 
    FB.Event.subscribe('auth.authResponseChange', function (response) {
        // Here we specify what we do with the response anytime this event occurs. 
        if (response.status === 'connected') {
            // The response object is returned with a status field that lets the app know the current
            // login status of the person. In this case, we're handling the situation where they 
            // have logged in to the app.
            
            testAPI();
        } else if (response.status === 'not_authorized') {
            // In this case, the person is logged into Facebook, but not into the app, so we call
            // FB.login() to prompt them to do so. 
            // In real-life usage, you wouldn't want to immediately prompt someone to login 
            // like this, for two reasons:
            // (1) JavaScript created popup windows are blocked by most browsers unless they 
            // result from direct interaction from people using the app (such as a mouse click)
            // (2) it is a bad experience to be continually prompted to login upon page load.
            FB.login();
        } else {
            // In this case, the person is not logged into Facebook, so we call the login() 
            // function to prompt them to do so. Note that at this stage there is no indication
            // of whether they are logged into the app. If they aren't then they'll see the Login
            // dialog right after they log in to Facebook. 
            // The same caveats as above apply to the FB.login() call here.
            FB.login();
        }
    });
};

// Load the SDK asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));

// Here we run a very simple test of the Graph API after login is successful. 
// This testAPI() function is only called in those cases. 
function testAPI() {
    FB.api('/me', function (response) {
        Global.User = response;
        _ajax("ProcessUser", { User: { Name: response.name, Username: response.username, FacebookId: response.id, Gender: 0 } }, function () { }, function () { });
    });
}

function _ajax(action, json, success, error) {
    $.ajax({
        url: '/farolverde/' + action,
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify(json),
        contentType: 'application/json; charset=utf-8',
        success: success,
        error: error
    });
}