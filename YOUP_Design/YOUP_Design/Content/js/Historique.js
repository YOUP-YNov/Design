﻿$(document).ready(function () {


    $("#SubmitButtonID").click(function () {
        alert("Hola");
            //// Get the value from 'Select1'
            //var value = $("#Pseudo").val();

            //var url = '@Url.Action("StatsUsage", "Historique", new { pseudoUser = "_pseudo_" })'
            //    .replace('_pseudo_', value);

            //$.get(url, '', function (data) {

            //    $("#partialgoeshere").empty();
            //    $("#partialgoeshere").html(data);

            //});
        });



    $(document).on('click', "#menuDeviceOS", function () {

        $('#menuDeviceOS').css("background-color", "#428bca");
        $('#menuPagesVisitees').css("background-color", "#eeeeee");
        $('#menuSaisonnalite').css("background-color", "#eeeeee");
        $('#menuStatsUtilisation').css("background-color", "#eeeeee");
        $('#menuTops').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#menuPagesVisitees", function () {

        $('#menuPagesVisitees').css("background-color", "#428bca");
        $('#menuDeviceOS').css("background-color", "#eeeeee");
        $('#menuSaisonnalite').css("background-color", "#eeeeee");
        $('#menuStatsUtilisation').css("background-color", "#eeeeee");
        $('#menuTops').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#menuSaisonnalite", function () {

        $('#menuSaisonnalite').css("background-color", "#428bca");
        $('#menuDeviceOS').css("background-color", "#eeeeee");
        $('#menuPagesVisitees').css("background-color", "#eeeeee");
        $('#menuStatsUtilisation').css("background-color", "#eeeeee");
        $('#menuTops').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#menuStatsUtilisation", function () {

        $('#menuStatsUtilisation').css("background-color", "#428bca");
        $('#menuDeviceOS').css("background-color", "#eeeeee");
        $('#menuPagesVisitees').css("background-color", "#eeeeee");
        $('#menuSaisonnalite').css("background-color", "#eeeeee");
        $('#menuTops').css("background-color", "#eeeeee");

    });

    $(document).on('click', "#menuTops", function () {

        $('#menuTops').css("background-color", "#428bca");
        $('#menuDeviceOS').css("background-color", "#eeeeee");
        $('#menuPagesVisitees').css("background-color", "#eeeeee");
        $('#menuSaisonnalite').css("background-color", "#eeeeee");
        $('#menuStatsUtilisation').css("background-color", "#eeeeee");

    });

    function combo(thelist, theinput) {
        theinput = document.getElementById(theinput);
        var idx = thelist.selectedIndex;
        var content = thelist.options[idx].innerHTML;
        theinput.value = content;
    }

});