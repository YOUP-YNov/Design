var evenementModule = (function () {

    var init = function () {
        $.ajax({
            type: "GET",
            url: 'http://youp-evenementapi.azurewebsites.net/api/Evenement',
            success: function (msg) {
                alert("toto");
            }
        });
    }
    return {
        init: init
    }
})();

