var evenementModule = (function () {

    var recuperationListeEvenements = function () {
        $.ajax({
            type: "GET",
            url: 'http://youp-evenementapi.azurewebsites.net/api/Evenement',
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
            url: 'http://youp-evenementapi.azurewebsites.net/api/Evenement/id',
            success: function (msg) {
                var evenement = jQuery.parseJSON(msg);
                alert("sucess recupererEvenementParId");
            }
        });
    }

    var creationEvenements = function(){

    }
    
    var init = function () {
        recuperationListeEvenements();
    }

    return {
        init: init
    }
})();

