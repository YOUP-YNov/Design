﻿
var evenementModule = (function () {

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

    function initializeMapCreation() {
        var geocoder = new google.maps.Geocoder();
        var mapOptions = {
            scaleControl: true,
            center: new google.maps.LatLng(44.854092, -0.566066),
            zoom: 15
        };

        var map = new google.maps.Map(document.getElementById('map-canvas-creation'),
            mapOptions);

        var oA = document.getElementById('btnRechercheAdresse');
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

    function listeEvenementDate(data) {
        var self = this;

        self.date = ko.observable(data.date);
        self.listeEvenements = ko.observableArray();

        self.init = function(data)
        {
            for (var i = 0; i < data.listeEvenements.length; i++)
                self.listeEvenements.push(new evenement(data.listeEvenements[i]));
        }

        self.init(data);
        
    }

    function evenement(data) {
        var self = this;

        self.idEvenement = ko.observable(data.idEvenement);
        self.titre = ko.observable(data.titre);
        self.imgEvt = ko.observable(data.imgEvt == "" || data.imgEvt == null ? "~/Images/default_profil.png" : data.imgEvt);
        self.prix = ko.observable(data.prix == 0 ? "gratuit" : data.prix + " €");
        self.description = ko.observable(data.description);
        self.date = ko.observable(data.date);
        self.categorie = ko.observable(data.categorie);
        self.nbParticipant = ko.observable(data.nbParticipant);
        self.nbMaxParticipant = ko.observable(data.nbMaxParticipant);
        self.imgOrganisateur = ko.observable(data.imgOrganisateur);
        self.organisateur = ko.observable(data.organisateur);
        self.adresse = ko.observable(new adresseEvt(data.adresse));
        self.visible = ko.observable(true);
        self.dateFinInscription = ko.observable(data.dateFinInscription);
        self.premium = ko.observable(data.premium);
        //attribut public
        self.public = ko.observable(data.visible);
        self.hashTag = ko.observable(data.hashTag);

        self.goDetail = function () {

            var id = self.idEvenement();
            var url = '/Evenements/details/' + id;
            window.location.href = url;
        }
    }

    function adresseEvt(data) {
        var self = this;

        self.id = ko.observable(data.Id);
        self.ville = ko.observable(data.Ville);
        self.codePostale = ko.observable(data.CodePostale);
        self.adresse = ko.observable(data.Adresse);
        self.longitude = ko.observable(data.Longitude);
        self.latitude = ko.observable(data.Latitude);
        self.pays = ko.observable(data.Pays);
        self.nom = ko.observable(data.Nom);
    }

    var timeLineViewModel = function (data) {
        var self = this;
        self.lastDate = new Date(data.lastDate);

        self.listeEvenementDate = ko.observableArray();


        for (var i = 0; i < data.liste.length; i++)
            self.listeEvenementDate.push(new listeEvenementDate(data.liste[i]));

        this.loadReports = function () {
            if (self.lastDate == null)
            {
                var dateString = self.RecupererDerniereDate();
                var annee = dateString.split('/')[2];
                var mois = dateString.split('/')[1];
                var jour = dateString.split('/')[0];
                var dateDebut = annee + '-' + mois + '-' + jour;
                self.lastDate = new Date(dateDebut);
            }
            var startRange = new Date(self.lastDate.addDays(1));
            var StartDateToGo = startRange.toString('yyyy/MM/dd');
            var endRange = startRange.addDays(7);
            self.lastDate = endRange;
            parameters = '?startRange=' + StartDateToGo + '&endRange=' + endRange.toString('yyyy/MM/dd');
            $.ajax({
                type: "GET",
                url: apiUrl + 'Evenement' + parameters,
                contentType: 'application/json',
                success: function (msg) {
                    var datas = msg;
                    if (msg != "") {
                        self.traiterData(datas);
                    }
                }
            });
        };

        self.RecupererDernierId = function () {
            var LastListeEvtDate;
            for (var i = self.listeEvenementDate().length - 1; i >= 0; i--)
            {
                if (self.listeEvenementDate()[i].listeEvenements().length > 0)
                    LastListeEvtDate = self.listeEvenementDate()[i];
            }
            return LastListeEvtDate.listeEvenements()[LastListeEvtDate.listeEvenements().length - 1].idEvenement();
        }

        self.RecupererDerniereDate = function () {
            var LastListeEvtDate;
            for (var i = self.listeEvenementDate().length - 1; i >= 0; i--) {
                if (self.listeEvenementDate()[i].listeEvenements().length > 0)
                    LastListeEvtDate = self.listeEvenementDate()[i];
            }
            return LastListeEvtDate.listeEvenements()[LastListeEvtDate.listeEvenements().length - 1].date();
        }

        self.traiterData = function (data) {
            $.ajax({
                type: "POST",
                url: 'Evenements/GestionScroll',
                contentType: 'application/json',
                dataType: 'json',
                data: JSON.stringify(data),
                success: function (msg) {
                    var datas = msg.timeLine;
                    var lastEvent = self.listeEvenementDate()[self.listeEvenementDate().length - 1];
                    for (var i = 0; i < datas.length; i++)
                    {
                        lastEvent.listeEvenements.push(new evenement(datas[i]));
                    }
                }
            });
        }

        $(window).scroll(function () {
            if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                self.loadReports();
            }
        });
    }

    var apiUrl = "http://youp-evenementapi.azurewebsites.net/api/";

    var recuperationListeEvenements = function () {
        var startRange = Date.today().toString('yyyy/MM/dd');
        var endRange = Date.today().addDays(14).toString('yyyy/MM/dd');
        parameters = '?startRange=' + startRange + '&endRange=' + endRange;
        $.ajax({
            type: "GET",
            url: apiUrl + 'Evenement' + parameters,
            contentType: 'application/json',
            success: function (msg) {
                var datas = msg;
                traiterListeEvenement(datas);
            }
        });
    }

    var traiterListeEvenement = function (data) {
        $.ajax({
            type: "POST",
            url: 'Evenements/TimeLine',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify(data ),
            success: function (msg) {
                var datas = msg.timeLine;

                ko.applyBindings(new timeLineViewModel(datas));
                $("#timeLineEvent").show();
            }
        });
    }

    var recupererEvenementParId = function(id)
    {
        $.ajax({
            type: "GET",
            url: apiUrl + 'Evenement/' + id,
            success: function (data) {
                DetaillerEvenement(data);
            }
        });
    }

    var DetaillerEvenement = function (data) {
        $.ajax({
            type: "POST",
            url: '/Evenements/DetailEvenement',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify(data),
            success: function (msg) {
                var datas = msg;
                var event = new evenement(datas);
                ko.applyBindings(event);
                ko.applyBindings(new evenement(datas));

                //initializeMap(45.862998, -0.400314);
                initializeMap(event.adresse().latitude(), event.adresse().longitude());
            }
        });
    }

    var init = function () {
        $("#timeLineEvent").hide();
        recuperationListeEvenements();
    }

    var initDetail = function (id) {
        recupererEvenementParId(id);
    }

    var initMapCreation = function () {
        initializeMapCreation();
    }

    return {
        init: init,
        initDetail: initDetail,
        initMapCreation : initMapCreation

    }
})();

$(function () {
    $(':file').click(function (e) {
        e.stopImmediatePropagation();
    });

    $(".upload-img-event").click(function () { // selecteur pour le clic
        $(this).find(":file").click();
    });

    $(":file").change(function () {
        var d = new FormData();
        var el = $(this);
        if (el[0].files[0]) {
            jQuery.each(el[0].files, function (i, file) {
                d.append('file-' + i, file);
            });
            $.ajax("http://" + location.host + "/Upload/UploadPicture?g=" + el[0].name, { type: "POST", data: d, cache: false, contentType: false, processData: false }).success(function (d) {
                if (d != "fail")
                    $("#photo-profil").attr("src", d); // id img à mettre a jour
                else
                    alert("invalid file type.");
            }).fail(function () {
                console.log("echec de l'appel à la methode upload.");
            });
        }
    });
});

