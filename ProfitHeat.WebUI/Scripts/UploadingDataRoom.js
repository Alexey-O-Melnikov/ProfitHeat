//$(document).ready(function () {
//    $('#manufacturerRadiators').change(function (event) {
//        //event.preventDefault();
//        var url = "Project/_ManufacturerRadiators";
//        $('#privacy').load(url);
//    });
//});

//$(document).ready(function () {
//    $('#radiator').click(function (event) {
//        event.preventDefault();
//        var data = $(this).serialize();
//        var url = $(this).attr('href');
//        $.post(url, data, function () {
//            $('#renderRadiator').load(url);
//        })
        
//    });
//});

//$(document).ready(function () {
//    $('#resultLink').click(function (event) {
//        event.preventDefault();
//        var url = $(this).attr('href');
//        $('#result').load(url);
//    });
//});

$(function () {
    var autocompleteUrl = '@Url.Action("Find")';
    $("input#city").autocomplete({
        source: autocompleteUrl,
        minLength: 2,
        select: function (event, ui) {
            alert("Selected " + ui.item.label);
        }
    });
});