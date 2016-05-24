function changeCountCameras() {
    event.preventDefault();
    var url = $("#distanceBetweenGlas").attr("data-url");
    var data = {
        "countCameras": $('#countCamer').val(),
        "distanceBetweenGlasses": ""
    };
    $('#distanceBetweenG').load(url, data);

    changeDistanceBetweenGlasses();
}

function changeDistanceBetweenGlasses(event) {
    var url = $("#typeGlas").attr("data-url");
    var data = {
        "countCameras": $("#countCamer").val(),
        "distanceBetweenGlasses": $("#distanceBetweenGlas").val(),
        "typeGlasses": ""
    };
    $('#typeG').load(url, data);
}

function changeManufacturerWindowProfiles() {
    var url = $('#manufacturerWindowProfil').attr("data-url");
    var data = {
        "manufactProfile": $('#manufacturerWindowProfil').val(),
        "winProf": ""
    };
    $('#modelWinProf').load(url, data);
}

function changeMaterialRadiators() {
    var url = $("#manufacturerRadiators").attr("data-url");
    var data = {
        "materialRadiator": $('#materialRadiators').val(),
        "manufacturerRadiator": ""
    };
    $('#manufecRadiator').load(url, data);

    changeManufacturerRadiators();
}

function changeManufacturerRadiators(event) {
    var url = $("#modelRadiator").attr("data-url");
    var data = {
        "materialRadiator": $("#materialRadiators").val(),
        "manufacturerRadiator": $('#manufacturerRadiators').val(),
        "modelRadiator": ""
    };
    $('#modelRadiat').load(url, data);
}

//function clickToSaveRoom() {
//    var url = $("#listRoomsName").attr("data-url");
//    var data = {
//        "projectID": $("#namesRoomsList").attr("data-projectId"),
//        "roomName": $('#titleRoom').val()
//    };
//    $('#namesRoomsList').load(url, data);
//}

function changeListRoomsName() {
    var url = $("#room").attr("data-url");
    var data = {
        "projectID": $("#namesRoomsList").attr("data-projectId"),
        "roomName": $("#listRoomsName").val()
    };
    $('#room').load(url, data);
    addRoom();
}

function addRoom() {
    var url = $("#listRoomsName").attr("data-url");
    var data = {
        "projectID": $("#namesRoomsList").attr("data-projectId"),
        "roomName": $("#listRoomsName").val()
    };
    $('#namesRoomsList').load(url, data);
}