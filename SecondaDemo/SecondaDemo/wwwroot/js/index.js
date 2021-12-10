window.miaPrimaFunzione = function (a, b) {
    console.log('Esecuzione codice javascript');
    return a + b;
};
window.miaSecondaFunzione = (a) => a * a;

window.miaTerzaFunzione = () => {
    var local = DotNet.invokeMethodAsync("SecondaDemo", "ReturnArrayAsync")
        .then(dati => {
            console.log(dati);
            var somma = 0;
            for (var i = 0; i < dati.length; i++) {
                somma += dati[i];
            }
            console.log(somma);
           //  return new Promise((resolve) => { resolve(somma); });
        });
}
 
window.sayHello = (reference) => reference.invokeMethodAsync("SayHello").then(r => console.log(r));


window.showModal = (id) => $('#' + id).modal("show");
window.hideModal = (id) => $('#' + id).modal("hide");

let map;

window.initMap = function (container, zoom, address, markers) {

    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === "OK") {
            if (results && results.length > 0) {
                var center = results[0].geometry.location;
                map = new google.maps.Map(container, {
                    center: center,
                    zoom: zoom,
                });

                if (markers && markers.length > 0) {
                    markers.forEach(m => {
                        geocoder.geocode({ 'address': m }, function (res, stat) {
                            if (stat === 'OK') {
                                if (res && res.length > 0) {
                                    var cen = res[0].geometry.location;
                                    var add = res[0].formatted_address;
                                    DotNet.invokeMethodAsync("SecondaDemo", "InfoWindow", add)
                                        .then(s => {
                                            var infowindow = new google.maps.InfoWindow({
                                                content: s,
                                            });
                                            var marker = new google.maps.Marker(
                                                {
                                                    map: map,
                                                    position: cen
                                                });
                                            marker.addListener('click', function () {
                                                infowindow.open({
                                                    anchor: marker,
                                                    map,
                                                    shouldFocus: false,
                                                });
                                            });

                                        });
                                    
                                }
                            }
                        });
                    });
                }

            }
        }
    });
   
}