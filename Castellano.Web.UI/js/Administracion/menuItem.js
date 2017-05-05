var App = (function () {

    App.nestableLists = function () {
        'use strict'

        $('.dd').nestable();
        
        function update_out(selector, sel2) {

            var out = $(selector).nestable('serialize');

            $(sel2).html(window.JSON.stringify(out));
        }

        update_out('#menu', "#out1");

        $('#menu').on('change', function () {
            update_out('#menu', "#out1");
        });
    };

    return App;
})(App || {});
