$(document).ready(function () {
    var couleur = $("#colorSexe").text();
    if (couleur == "Masculin")
    {
        $("#pseudoColor").css("color", "blue");
    }
    else
    {
        $("#pseudoColor").css("color", "fuchsia");
    }

    $('#afficheDeviceOS').fadeIn();
    $('#menuDeviceOS').css("background-color", "#428bca");

    $('#affichePagesVisitees').hide();
    $('#afficheSaisonnalite').hide();
    $('#afficheStatsUtilisation').hide();
    $('#afficheTops').hide();

    $(document).on('click', "#menuDevice", function () {

        $('#afficheDevice').fadeIn();
        $('#afficheOS').hide();
        $('#affichePagesVisitees').hide();
        $('#afficheSaisonnalite').hide();
        $('#afficheStatsUtilisation').hide();
        $('#afficheTops').hide();

        $('#menuDevice').css("background-color", "#428bca");
        $('#menuOS').css("background-color", "#eeeeee");
        $('#menuDevice').css("background-color", "#eeeeee");
        $('#menuPagesVisitees').css("background-color", "#eeeeee");
        $('#menuSaisonnalite').css("background-color", "#eeeeee");
        $('#menuStatsUtilisation').css("background-color", "#eeeeee");
        $('#menuTops').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#menuOS", function () {

        $('#afficheOS').fadeIn();
        $('#afficheDevice').hide();
        $('#affichePagesVisitees').hide();
        $('#afficheSaisonnalite').hide();
        $('#afficheStatsUtilisation').hide();
        $('#afficheTops').hide();

        $('#menuOS').css("background-color", "#428bca");
        $('#menuDevice').css("background-color", "#eeeeee");
        $('#menuPagesVisitees').css("background-color", "#eeeeee");
        $('#menuSaisonnalite').css("background-color", "#eeeeee");
        $('#menuStatsUtilisation').css("background-color", "#eeeeee");
        $('#menuTops').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#menuPagesVisitees", function () {

        $('#affichePagesVisitees').fadeIn();
        $('#afficheDevice').hide();
        $('#afficheOS').hide();
        $('#afficheSaisonnalite').hide();
        $('#afficheStatsUtilisation').hide();
        $('#afficheTops').hide();

        $('#menuPagesVisitees').css("background-color", "#428bca");
        $('#menuDevice').css("background-color", "#eeeeee");
        $('#menuOS').css("background-color", "#eeeeee");
        $('#menuSaisonnalite').css("background-color", "#eeeeee");
        $('#menuStatsUtilisation').css("background-color", "#eeeeee");
        $('#menuTops').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#menuSaisonnalite", function () {

        $('#afficheSaisonnalite').fadeIn();
        $('#afficheDevice').hide();
        $('#afficheOS').hide();
        $('#affichePagesVisitees').hide();
        $('#afficheStatsUtilisation').hide();
        $('#afficheTops').hide();

        $('#menuSaisonnalite').css("background-color", "#428bca");
        $('#menuDevice').css("background-color", "#eeeeee");
        $('#menuOS').css("background-color", "#eeeeee");
        $('#menuPagesVisitees').css("background-color", "#eeeeee");
        $('#menuStatsUtilisation').css("background-color", "#eeeeee");
        $('#menuTops').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#menuStatsUtilisation", function () {

        $('#afficheStatsUtilisation').fadeIn();
        $('#afficheDevice').hide();
        $('#afficheOS').hide();
        $('#affichePagesVisitees').hide();
        $('#afficheSaisonnalite').hide();
        $('#afficheTops').hide();

        $('#menuStatsUtilisation').css("background-color", "#428bca");
        $('#menuDevice').css("background-color", "#eeeeee");
        $('#menuOS').css("background-color", "#eeeeee");
        $('#menuPagesVisitees').css("background-color", "#eeeeee");
        $('#menuSaisonnalite').css("background-color", "#eeeeee");
        $('#menuTops').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#menuTops", function () {

        $('#afficheTops').fadeIn();
        $('#afficheDevice').hide();
        $('#afficheOS').hide();
        $('#affichePagesVisitees').hide();
        $('#afficheSaisonnalite').hide();
        $('#afficheStatsUtilisation').hide();

        $('#menuTops').css("background-color", "#428bca");
        $('#menuDevice').css("background-color", "#eeeeee");
        $('#menuOS').css("background-color", "#eeeeee");
        $('#menuPagesVisitees').css("background-color", "#eeeeee");
        $('#menuSaisonnalite').css("background-color", "#eeeeee");
        $('#menuStatsUtilisation').css("background-color", "#eeeeee");

    });


});