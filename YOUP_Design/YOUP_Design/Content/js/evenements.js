var evenementModule = (function () {

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
        self.adresse = ko.observable(data.adresse);
        self.prix = ko.observable(data.prix == 0 ? "gratuit" : data.prix + " €");
        self.description = ko.observable(data.description);
        self.date = ko.observable(data.date);
        self.ville = ko.observable(data.ville);
        self.categorie = ko.observable(data.categorie);
        self.nbParticipant = ko.observable(data.nbParticipant);
        self.nbMaxParticipant = ko.observable(data.nbMaxParticipant);
        self.imgOrganisateur = ko.observable(data.imgOrganisateur);
        self.organisateur = ko.observable(data.organisateur);
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

