$(document).ready(function () {

    $('#afficheProfil').fadeIn();
    $('#lienPro').css("background-color", "#428bca");

    $('#afficheActivite').hide();
    $('#afficheAmis').hide();

    $(document).on('click', "#lienAm", function () {

        $('#afficheProfil').hide();
        $('#afficheActivite').hide();
        $('#afficheAmis').fadeIn();

        $('#lienAct').css("background-color", "#eeeeee");
        $('#lienPro').css("background-color", "#eeeeee");
        $('#lienAm').css("background-color", "#428bca");

    });

    $(document).on('click', "#lienPro", function () {

        $('#afficheProfil').fadeIn();
        $('#afficheActivite').hide();
        $('#afficheAmis').hide();

        $('#lienAct').css("background-color", "#eeeeee");
        $('#lienPro').css("background-color", "#428bca");
        $('#lienAm').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#lienAct", function () {

        $('#afficheProfil').hide();
        $('#afficheActivite').fadeIn();
        $('#afficheAmis').hide();

        $('#lienAct').css("background-color", "#428bca");
        $('#lienPro').css("background-color", "#eeeeee");
        $('#lienAm').css("background-color", "#eeeeee");

    });
});

var ProfilModule = (function () {

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
})();

$(function () {
    $(':file').click(function (e) {
        e.stopImmediatePropagation();
    });
    $(".upload-img").click(function () { // selecteur pour le clic
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