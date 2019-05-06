$(function () {
    $('.js-animations').bind('change', function () {
        var animation = $(this).val();
        $('.js-animating-object').animateCss(animation);
    });
});


$.fn.extend({
    animateCss: function (animationName) {
        var animationEnd = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
        $(this).addClass('animated ' + animationName).one(animationEnd, function() {
            $(this).removeClass('animated ' + animationName);
        });
    }
});