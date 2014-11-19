var profilModule = (function () {

    function initializeMap(Lat, Long) {
        var mapOptions = {
            scaleControl: true,
            center: new google.maps.LatLng(Lat, Long),
            zoom: 15
        };

        var map = new google.maps.Map(document.getElementById('map-canvas'),
            mapOptions);

        var marker = new google.maps.Marker({
            map: map,
            position: map.getCenter()
        });
    }

    function initializeMapProfil() {
        var geocoder = new google.maps.Geocoder();
        var mapOptions = {
            scaleControl: true,
            center: new google.maps.LatLng(44.854092, -0.566066),
            zoom: 15
        };

        var map = new google.maps.Map(document.getElementById('map-canvas-profil'),
            mapOptions);

        var oA = document.getElementById('btnRechercheAdresseProfil');
        oA.onclick = function () {
            searchAddress(map);
            return false;
        };

        /* SEARCH ADDRESS */
        function searchAddress(map) {
            var adresse = document.getElementById('exampleInputAdresse').value;
            geocoder.geocode({ 'address': adresse }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    map.setCenter(results[0].geometry.location);
                    var marker = new google.maps.Marker({
                        map: map,
                        position: results[0].geometry.location
                    });

                    var latitude = marker.getPosition().lat();
                    var longitude = marker.getPosition().lng();

                } else {
                    alert('Geocode was not successful for the following reason: ' + status);
                }
            });
        }
    }

    var initMapProfil = function () {
        initializeMapProfil();
    }

    return {
        initMapProfil: initMapProfil
    }
})();

/*var ProfilModule = (function () {

    var apiUrl = "http://aspmoduleprofil.azurewebsites.net/api/";

    var recupererProfilParId = function (id) {
        $.ajax({
            type: "GET",
            url: apiUrl + 'User/' + id,
            success: function (data) {
                
                var self = this;

                self.User_id = ko.observable(data.Utilisateur_id); 
                self.Nom = ko.observable(data.Nom); 
                self.Prenom = ko.observable(data.Prenom);
                
                //self. = ko.observable(data.); 
                //self. = ko.observable(data.); 
            }
        });
    }

    var initProfil = function (id) {
        recupererProfilParId(id);
    }

    return {
        initProfl: initProfil
    }
})();*/

