var evenementModule = (function () {
    var apiUrl = "http://youp-evenementapi.azurewebsites.net/api/";

    var recuperationListeEvenements = function () {
        $.ajax({
            type: "GET",
            url: apiUrl + 'Evenement',
            success: function (msg) {
                var listeEvenements = jQuery.parseJSON(msg);
                alert("sucess recuperationListeEvenements");
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
        recuperationListeEvenements();
    }

    return {
        init: init
    }
})();

