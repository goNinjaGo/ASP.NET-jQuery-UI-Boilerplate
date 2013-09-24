; (function ($) {
    // declare var in global scope
    window.WCFBASE = {};

    WCFBASE.DIALOGS = {
        modalOptions: { modal: true },
        notificationOptions: { position: "right bottom", title: "Notification" }        
    }

    $(function () {
        
        createNewModal = function ($obj, options) {
            $('<div id="modalDialog"></div>').hide().append($obj).appendTo('#form1').dialog($.extend({}, WCFBASE.DIALOGS.modalOptions, options));
        };

        createNewNotification = function ($obj, options) {
            $('<div id="notificationDialog"></div>').hide().append($obj).appendTo('#form1').dialog($.extend({}, WCFBASE.DIALOGS.notificationOptions, options));
        };

        openNotification = function (text, title) {
            createNewNotification($('<div>').text(text), { title: title });
        };
    });

})(jQuery);
