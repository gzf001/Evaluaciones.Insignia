$(document).ready(

    function () {

        $('input:text').focus(function () {
            $(this).addClass('activeText');
        });

        $('input:textarea').focus(function () {
            $(this).addClass('activeText');
        });

        $('input:password').focus(function () {
            $(this).addClass('activeText');
        });

        $('input:text').blur(function () {
            $(this).removeClass('activeText');
        });

        $('input:textarea').blur(function () {
            $(this).removeClass('activeText');
        });

        $('input:password').blur(function () {
            $(this).removeClass('activeText');
        });
    }
);