var evenementModule = (function () {

    function listeEvenementDate(data) {
        var self = this;

        self.date = ko.observable(data.date);
        self.listeEvenements = ko.observableArray();

        for (var i = 0; i < data.listeEvenements.length; i++)
            self.listeEvenements.push(new evenement(data.evenements[i]));
    }

    function evenement(data) {
        var self = this;

        self.idEvenement = ko.observable(data.Evenement_id);
        self.titre = ko.observable(data.TitreEvenement);
        self.imgEvt = ko.observable(function ()
            {
                return data.ImgEvt == "" || data.ImgEvt == null ? "~/Images/default_profil.png" : data.ImgEvt;
            });
        self.adresse = ko.observable(data.Adresse);
        self.prix = ko.observable(function () {
            return data.Prix == 0 ? "gratuit" : data.Prix + " €";
        });
        self.description = ko.observable(data.Descrption);
        self.date = ko.observable(data.DateEvenement);
        self.ville = ko.observable(data.Ville);
        self.categorie = ko.observable(data.VilleCategorie);
        self.nbParticipant = ko.observable(data.nbParticipant);
        self.nbMaxParticipant = ko.observable(data.nbMaxParticipant);
        self.imgOrganisateur = ko.observable(data.ImgOrganisateur);
        self.organisateur = ko.observable(data.Organisateur);
        self.visible = ko.observable(true);

    }

    var timeLineViewModel = function (data) {
        var self = this;

        self.listeEvenementDate = ko.observableArray();

        for (var i = 0; i < data.length; i++)
            self.listeEvenementDate.push(new listeEvenementDate(data[i]));
    }

    var apiUrl = "http://youp-evenementapi.azurewebsites.net/api/";

    var recuperationListeEvenements = function () {
        var today = Date.today();
        Date.today().addDays(14)
        $.ajax({
            type: "GET",
            url: apiUrl + 'Evenement',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({ 'dateSearch': today }),
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
            url: apiUrl + 'Evenement/id',
            success: function (msg) {
                var evenement = jQuery.parseJSON(msg);
                alert("sucess recupererEvenementParId");
            }
        });
    }
    
    var init = function () {
        $("#timeLineEvent").hide();
        recuperationListeEvenements();
    }

    return {
        init: init
    }
})();

