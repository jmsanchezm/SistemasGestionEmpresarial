
function saludarServer(){

    let llamada = new XMLHttpRequest()

    let divMensaje = document.getElementById("saludoServer")

    llamada.open('GET','Server.html',true)

    llamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');

    llamada.onreadystatechange = function () {

        if (llamada.readyState < 4) {

            divMensaje.innerHTML = "Cargando...";

        } else if (llamada.readyState == 4 && llamada.status == 200) {

            divMensaje.innerHTML = llamada.responseText 

        } else {
            divMensaje.innerHTML = "Error";
        }
    };

    llamada.send()

}