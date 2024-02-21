window.onload = function () {
    
    traerMarcas().then(function () {
        traerModelos().then(function () {
            RellenarMarcas()
        });
    });
}

var listadoModelos 
var listadoMarcas 

class Marca {
    constructor(id, nombre) {
        this.id = id
        this.nombre = nombre
    }
}

class Modelo {
    constructor(idModelo, nombre, idMarca, precio) {
        this.idModelo = idModelo
        this.nombre = nombre
        this.idMarca = idMarca
        this.precio = precio
    }
}


function traerMarcas() {

    return new Promise((resolve, reject) => {
        fetch('https://apimarcamodelo.azurewebsites.net/api/marcas')
            .then(response => response.json())
            .then(data => {
                listadoMarcas = data
                resolve()
            })
    }
    )
}

function traerModelos() {
    return new Promise((resolve, reject) => {
        fetch('https://apimarcamodelo.azurewebsites.net/api/modelos')
            .then(response => response.json())
            .then(data => {
                console.log(data); // Agrega esta línea para ver la respuesta en la consola

                listadoModelos = data
                resolve()
            })
    
    }) 

}

function RellenarMarcas() {
    var marcasSelect = document.getElementById('Marca')

    listadoMarcas.forEach(marcas => { 

        const option = document.createElement('option')
        option.innerHTML = marcas.nombre
        option.value = marcas.id
        marcasSelect.appendChild(option)
    })
}

function MostrarModelos() {

    var marcaSeleccionada = document.getElementById('Marca').value

    console.log(marcaSeleccionada)

    var modelosSelect = document.getElementById('Modelo')

    modelosSelect.innerHTML = ""

    listadoModelos.forEach(modelos => {
        if (modelos.idMarca == marcaSeleccionada) {
            const modelo = document.createElement('option')
            modelo.innerHTML = modelos.nombre
            modelo.value = modelos.id
            modelosSelect.appendChild(modelo)
        }

    });

}

function MostrarInformacion() {
    var modeloSeleccionado = document.getElementById('Modelo').value

    var modelo = listadoModelos.find(modelo => modelo.id == modeloSeleccionado)

    console.log(modeloSeleccionado)

    var label = document.createElement('label');
    label.innerHTML = 'Precio:';

    var precio = document.createElement('input');
    precio.type = 'text';
    precio.id = 'PrecioMod';
    precio.value = modelo.precio;

    var boton = document.createElement('button');
    boton.textContent = 'Cambiar precio';
    boton.onclick = GuardarPrecio;

    document.body.appendChild(label);
    document.body.appendChild(precio);
    document.body.appendChild(boton);
}


function GuardarPrecio() {

    var precioModificado = document.getElementById('PrecioMod').value

    var modeloSeleccionado = document.getElementById('Modelo').value

    var modelo = listadoModelos.find(modelo => modelo.id == modeloSeleccionado)


    if (precioModificado == modelo.precio) {
        alert('El precio es el mismo que el actual, no se ha modificado')
        
    }else{

        modelo.precio = precioModificado

        fetch('https://apimarcamodelo.azurewebsites.net/api/modelos/' + modelo.id, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(modelo)
        })
            .then(response => response.json())
            .then(data => {
                console.log(data)
            })
            .catch(err => console.log(err))
    
        alert('Precio modificado correctamente')
        
    }

}