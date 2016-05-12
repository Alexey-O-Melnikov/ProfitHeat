function draw() {
    //if (!Modernizr.canvas) return;

    var canvas = document.getElementById("canvas");
    var context = canvas.getContext("2d");

    var backgroundCanvas = new Image();

    backgroundCanvas.onload = function () {
        context.drawImage(backgroundCanvas, 0, 0);

    };

    backgroundCanvas.src = "https://photos-4.dropbox.com/t/2/AADg475qXe875q7LgjKG7ZgxsGzDCbCJTrPoEnKNXjquxA/12/192385417/png/32x32/3/1463086800/0/2/canvas_background.png/EObbgJIBGOXeASACKAI/IFAGTZwEzJW0bojo-riNt1nY6Aeuti38heFvc0NIqAA?size_mode=3&size=2048x1536";
}

if (window.addEventListener)
    window.addEventListener("load", draw, true);