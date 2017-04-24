﻿$(document).ready(

    function () {

        $('input:text').focus(function () {
            $(this).addClass('activeText');
        });

        $('textarea').focus(function () {
            $(this).addClass('activeText');
        });

        $('input:password').focus(function () {
            $(this).addClass('activeText');
        });

        $('input:text').blur(function () {
            $(this).removeClass('activeText');
        });

        $('textarea').blur(function () {
            $(this).removeClass('activeText');
        });

        $('input:password').blur(function () {
            $(this).removeClass('activeText');
        });

        $('input[onlyNumbers]').keydown(function (e) {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                (e.keyCode == 65 && e.ctrlKey === true) ||
                (e.keyCode >= 35 && e.keyCode <= 39)) {
                return;
            }

            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                e.preventDefault();
            }
        })

        $('.md-trigger').modalEffects();
    }
);