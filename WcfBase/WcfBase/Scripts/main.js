; (function ($) {
    // declare var in global scope
    window.MYNAMESPACE = {};

    MYNAMESPACE.SUBNAME = {
        myFunction: function () {
            console.log('running MYNAMESPACE.SUBNAME.myFunction...');
        }
    }

})(jQuery);
MYNAMESPACE.SUBNAME.myFunction(); //function call
