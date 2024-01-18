window.onload = inicializaEventos;

function inicializaEventos() {
    let button = document.getElementById("btnSaludar");

    button.addEventListener("click", saludar, false);
}

function saludar() {

    let miLlamada = new XMLHttpRequest();
    let divMensaje = document.getElementById("divMensaje");

    miLlamada.open("GET", "https://crudjuanmasanchez.azurewebsites.net/api/Personas");

    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {

            divMensaje.innerHTML = "Cargando...";

        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {

            divMensaje.innerHTML = "";

            let request = JSON.parse(miLlamada.responseText);

            for (let i = 0; i < request.length; i++) {
                divMensaje.innerHTML += request[i].nombre + " " + request[i].apellido + "<br>";
            }

        } else {
            divMensaje.innerHTML = "Error";
        }
    };
    miLlamada.send();
}