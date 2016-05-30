function draw() {
    var canvas = document.getElementById("canvas");
    var context = canvas.getContext("2d");

    var backgroundCanvas = new Image();

    backgroundCanvas.onload = function () {
        context.drawImage(backgroundCanvas, 0, 0);

    };

    backgroundCanvas.src = "http://bti-online.in.ua/var/www/anatolii.levko/data//www/bti-online.in.ua/wp-content/uploads/2016/03/NeedFull.NET_kartinki-3d-modeli-domov-dlya-arkhitektorov-s-chertezhami3.jpg";
}

if (window.addEventListener)
    window.addEventListener("load", draw, true);