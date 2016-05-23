$(document).ready(function () {

    $('#manufacturerWindowProfil').change(function (event) {
        event.preventDefault();
        var url = $(this).attr("data-url");
        var data = {
            "manufactProfile": $(this).val(),
            "winProf": ""
        };
        $('#modelWinProf').load(url, data);
    })
})

$(document).ready(function () {
    $('#materialRadiators').change(function (event) {
        event.preventDefault();
        var url = $("#manufacturerRadiators").attr("data-url");
        var data = {
            "materialRadiator": $(this).val(),
            "manufacturerRadiator": ""
        };
        $('#manufecRadiator').load(url, data);

        changeManufacturerRadiators();
    })
})

function changeManufacturerRadiators(event) {
    var url = $("#modelRadiator").attr("data-url");
    var data = {
        "materialRadiator": $("#materialRadiators").val(),
        "manufacturerRadiator": $('#manufacturerRadiators').val(),
        "modelRadiator": ""
    };
    $('#modelRadiat').load(url, data);
}
