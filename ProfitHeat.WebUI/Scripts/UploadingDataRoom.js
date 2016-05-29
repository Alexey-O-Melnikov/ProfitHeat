function saveChange() {
    var url = $("#saveProject").attr("data-url");
    var data = {
        "projectID": $("#saveProject").attr("data-projectId"),
    };
    $("#result").load(url, data);
}

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
    var url = $(manufacturerWindowProfil).attr("data-url");
    var data = {
        "manufactProfile": $(manufacturerWindowProfil).val(),
        "winProf": ""
    };
    $(modelWinProf).load(url, data);
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

function saveEntity(entityId, inputId) {
    var url = $("#nameProject").attr("data-url");
    var data = {
        "entity": inputId.replace(/[0-9]/g, ''),
        "id": $("#"+entityId).attr("data-id"),
        "value": $("#"+inputId).val()
    };
    $('#result').load(url, data);
}

function saveWindowProfile() {
    var url = $("#window").attr("data-url");
    var data = {
        "windowID": $("#WindowArea").attr("data-id"),
        "model": $("#WindowProfileModel").val(),
        "manufect": $("#manufacturerWindowProfil").val()
    };
    $('#result').load(url, data);
}

function saveWindowGlass() {
    var url = $("#glass").attr("data-url");
    var data = {
        "windowID": $("#WindowArea").attr("data-id"),
        "glassType": $("#typeGlas").val(),
        "camerasCount": $("#countCamer").val(),
        "distanc": $("#distanceBetweenGlas").val()
    };
    $('#result').load(url, data);
}

function saveRadiator() {
    var url = $("#radiator").attr("data-url");
    var data = {
        "roomID": $("#RoomTitle").attr("data-id"),
        "model": $("#modelRadiator").val(),
        "material": $("#materialRadiators").val(),
        "manufect": $("#manufacturerRadiators").val()
    };
    $('#result').load(url, data);
}