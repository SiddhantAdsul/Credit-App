
// Sidebar menu
$(document).ready(function () {
    $("#accordian a").click(function () {
        var link = $(this);
        var closest_ul = link.closest("ul");
        var parallel_active_links = closest_ul.find(".active")
        var closest_li = link.closest("li");
        var link_status = closest_li.hasClass("active");
        var count = 0;

        closest_ul.find("ul").slideUp(function () {
            if (++count == closest_ul.find("ul").length)
                parallel_active_links.removeClass("active");
        });

        if (!link_status) {
            closest_li.children("ul").slideDown();
            closest_li.addClass("active");
        }
    })

    //Active menu sidebar
    $("ul.nav.mainMenu").find('[href="' + window.location.pathname + '"]').parents('ul.dropdown2').css('display', 'block');
    $("ul.nav.mainMenu").find('[href="' + window.location.pathname + '"]').parents('ul.dropdown1').css('display', 'block');
    $("ul.nav.mainMenu").find('[href="' + window.location.pathname + '"]').parents('ul.dropdown2').parent().addClass('active');
    $("ul.nav.mainMenu").find('[href="' + window.location.pathname + '"]').parents('ul.dropdown1').parents().addClass('active');
    $("ul.nav.mainMenu").find('[href="' + window.location.pathname + '"]').addClass('active');
})

//Hide show sidebar
jQuery(document).ready(function ($) {
    var alterClass = function () {
        var ww = document.body.clientWidth;
        if (ww < 992) {
            $('.sidemenu-wrap').removeClass('SdBarDesktop');
            $('.sidemenu-wrap').addClass('SdBarMobile');
            $('.maincontent-wrap').removeClass('ContentDesktop');
            $('.maincontent-wrap').addClass('ContentMobile');
        } else if (ww >= 992) {
            $('.sidemenu-wrap').addClass('SdBarDesktop');
            $('.sidemenu-wrap').removeClass('SdBarMobile');
            $('.maincontent-wrap').addClass('ContentDesktop');
            $('.maincontent-wrap').removeClass('ContentMobile');
        };
    };
    $(window).resize(function () {
        alterClass();
    });
    alterClass();
});

$(document).ready(function () {
    $(".menubar").click(function () {
        $(".SdBarMobile").toggleClass("activeMobMenu");
        $(".ContentMobile").toggleClass("activeMobContent");

        $(".SdBarDesktop").toggleClass("HideDesktopMenu");
        $(".ContentDesktop").toggleClass("FullContent");
    });
});

// Tooltips bootstrap
$(function () {
    $('[data-toggle="tooltip"]').tooltip();
})
