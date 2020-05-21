points = [];

currentMapId = undefined;

startPointId = undefined;
endPointId = undefined;

onInit();

function onInit() {
    getAllPoints();
}

function getAllPoints() {
    fetch('/Points/GetPoints')
        .then(response => response.json())
        .then(allPoints => points = allPoints);
}

function chooseMap(mapId){
    let mapContainer = document.getElementById(`map-container-${currentMapId}`);
    mapContainer.style.display = 'none';

    currentMapId = mapId;

    mapContainer = document.getElementById(`map-container-${currentMapId}`);
    mapContainer.style.display = 'block';
}

function getTheShortestPath() {
    if (startPointId && endPointId && startPointId != endPointId) {
        let mapId = points.find(p => p.id == startPointId).mapId;
        fetch(`/Maps/GetFromTo?fromId=${startPointId}&toId=${endPointId}&mapId=${mapId}`)
        .then(response => response.json())
        .then(path => {
            let linePoints = "";

            for (let i = 0; i < path.length; ++i) {
                var point = points.find(p => p.id == path[i]);

                if (point)
                    linePoints += `${point.x},${point.y} `;
            }

            document.getElementById(`line-${mapId}`).setAttribute("points", linePoints);
        }
        );
    }
}

function changePoints(pointId) {
    if (startPointId == undefined) {
        document.getElementById('select1').value = pointId;
        changeStartPoint(pointId);
    }

    else if (startPointId == pointId) {
        document.getElementById('select1').value = -1;
        removeStartPoint();
    }

    else if (endPointId == undefined) {
        document.getElementById('select2').value = pointId;
        changeEndPoint(pointId);
    }

    else if (endPointId == pointId) {
        document.getElementById('select2').value = -1;
        removeEndPoint();
    }
}

function removeStartPoint() {
    let oldPoint = document.getElementById(`point-${startPointId}`);
    oldPoint.setAttribute('stroke', '#000000');
    oldPoint.setAttribute('r', 4);
    startPointId = undefined;
}

function removeEndPoint() {
    let oldPoint = document.getElementById(`point-${endPointId}`);
    oldPoint.setAttribute('stroke', '#000000');
    oldPoint.setAttribute('r', 4);
    endPointId = undefined;
}

function changeStartPoint(pointId) {
    if(startPointId) {
        removeStartPoint();
    }

    startPointId = pointId;

    var point = document.getElementById(`point-${pointId}`);
    point.setAttribute('stroke', '#00b31e');
    point.setAttribute('r', 5);
}

function changeEndPoint(pointId) {
    if(endPointId) {
        removeEndPoint();
    }

    endPointId = pointId;

    var point = document.getElementById(`point-${pointId}`);
    point.setAttribute('stroke', '#bf0600');
    point.setAttribute('r', 5);
}