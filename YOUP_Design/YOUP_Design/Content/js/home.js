﻿(function ($) {
    /*=================================================================================================
            FUNCTIONS
    =================================================================================================*/

    function set_fullscreen_backgrounds() {
        var fullscreen_bg = $('.home-fullscreen-bg');

        fullscreen_bg.each(function () {
            $(this).css({
                'height': window.innerHeight - 65,
            });
        });
    }

    /*=================================================================================================
			DOCUMENT READY
	=================================================================================================*/

    $(document).ready(function () {
        $('.next-section').click(function () {
            var the_id = $(this).attr("href");

            $(window).animate({
                scrollTop: $(the_id).offset().top + 65, 
            }, 'slow');
            return false;
        });
    });

    /*=================================================================================================
            LOAD
    =================================================================================================*/

    $(window).load(function () {

        set_fullscreen_backgrounds();

    });

    /*=================================================================================================
            RESIZE
    =================================================================================================*/

    $(window).resize(function () {

        set_fullscreen_backgrounds();

    });

    /*=================================================================================================
			SCROLL
	=================================================================================================*/

    $(window).scroll(function () {

    });

}(jQuery));