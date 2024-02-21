 function traerPersona(){

    var llamada = new XMLHttpRequest()

    var divMensaje = document.getElementById('persona')

    llamada.open('GET','https://crudjuanmasanchez.azurewebsites.net/API/Personas')

    llamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');

    llamada.onreadystatechange= function(){
        
        if (llamada.readyState < 4) {

            divMensaje.innerHTML = "Cargando...";
            
            }
        
        else if (llamada.readyState == 4 && llamada.status == 200) {
        
            divMensaje.innerHTML =''

            let request = JSON.parse(llamada.responseText)

            divMensaje.innerHTML += request[0].nombre + ' '+ request[0].apellido

        } else{
            divMensaje.innerHTML = "Error";
        }

    }
    llamada.send()
}