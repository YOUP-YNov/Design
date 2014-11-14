$(document).ready(function () {

    $('#afficheDeviceOS').fadeIn();
    $('#menuDeviceOS').css("background-color", "#428bca");

    $('#affichePagesVisitees').hide();
    $('#afficheSaisonnalite').hide();
    $('#afficheStatsUtilisation').hide();
    $('#afficheTops').hide();

    $(document).on('click', "#menuDeviceOS", function () {

        $('#afficheDeviceOS').fadeIn();
        $('#affichePagesVisitees').hide();
        $('#afficheSaisonnalite').hide();
        $('#afficheStatsUtilisation').hide();
        $('#afficheTops').hide();

        $('#menuDeviceOS').css("background-color", "#428bca");
        $('#menuPagesVisitees').css("background-color", "#eeeeee");
        $('#menuSaisonnalite').css("background-color", "#eeeeee");
        $('#menuStatsUtilisation').css("background-color", "#eeeeee");
        $('#menuTops').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#menuPagesVisitees", function () {

        $('#affichePagesVisitees').fadeIn();
        $('#afficheDeviceOS').hide();
        $('#afficheSaisonnalite').hide();
        $('#afficheStatsUtilisation').hide();
        $('#afficheTops').hide();

        $('#menuPagesVisitees').css("background-color", "#428bca");
        $('#menuDeviceOS').css("background-color", "#eeeeee");
        $('#menuSaisonnalite').css("background-color", "#eeeeee");
        $('#menuStatsUtilisation').css("background-color", "#eeeeee");
        $('#menuTops').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#menuSaisonnalite", function () {

        $('#afficheSaisonnalite').fadeIn();
        $('#afficheDeviceOS').hide();
        $('#affichePagesVisitees').hide();
        $('#afficheStatsUtilisation').hide();
        $('#afficheTops').hide();

        $('#menuSaisonnalite').css("background-color", "#428bca");
        $('#menuDeviceOS').css("background-color", "#eeeeee");
        $('#menuPagesVisitees').css("background-color", "#eeeeee");
        $('#menuStatsUtilisation').css("background-color", "#eeeeee");
        $('#menuTops').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#menuStatsUtilisation", function () {

        $('#afficheStatsUtilisation').fadeIn();
        $('#afficheDeviceOS').hide();
        $('#affichePagesVisitees').hide();
        $('#afficheSaisonnalite').hide();
        $('#afficheTops').hide();

        $('#menuStatsUtilisation').css("background-color", "#428bca");
        $('#menuDeviceOS').css("background-color", "#eeeeee");
        $('#menuPagesVisitees').css("background-color", "#eeeeee");
        $('#menuSaisonnalite').css("background-color", "#eeeeee");
        $('#menuTops').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#menuTops", function () {

        $('#afficheTops').fadeIn();
        $('#afficheDeviceOS').hide();
        $('#affichePagesVisitees').hide();
        $('#afficheSaisonnalite').hide();
        $('#afficheStatsUtilisation').hide();

        $('#menuTops').css("background-color", "#428bca");
        $('#menuDeviceOS').css("background-color", "#eeeeee");
        $('#menuPagesVisitees').css("background-color", "#eeeeee");
        $('#menuSaisonnalite').css("background-color", "#eeeeee");
        $('#menuStatsUtilisation').css("background-color", "#eeeeee");

    });


});