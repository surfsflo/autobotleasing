
$.validator.setDefaults({
    highlight: function (element) {
        $(element).closest(".form-group").addClass("has-error");
    },
    unhighlight: function (element) {
        $(element).closest(".form-group").removeClass("has-error");
    }
});

_.extend($.fn.select2.defaults, {    
    minimumResultsForSearch: 10
});