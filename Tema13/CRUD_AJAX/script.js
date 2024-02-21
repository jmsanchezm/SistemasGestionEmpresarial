window.onload = function(){

    cargarDepartamentos().then(function(){
        cargarPersonas().then(function(){                                   
                mostrarPersonas()
        })
    })

    
} 


class Persona{

    constructor(id , nombre, apellidos,tlf, direccion, idDepartamento, fNac, foto ){

        this.id = id
        this.nombre= nombre
        this.apellidos = apellidos
        this.tlf = tlf
        this.direccion = direccion
        this.idDepartamento = idDepartamento
        this.fecha = fNac
        this.foto = foto

    }
}

class Departamento{
    constructor(id, nombre){
        this.id = id
        this.nombre = nombre
    }   
}

class PersonaDepartamento {
    constructor(persona,departamento){
        this.persona = persona
        this.departamento = departamento
    }

}

var listaPersonas = []  
var listaDepartamentos = []

function cargarPersonas(){
    return new Promise((resolve, reject) => {  
        fetch('https://apipersonasdepto.azurewebsites.net/api/personas')
        .then(response => response.json())
        .then(data => {
            listaPersonas = data
            resolve()
            console.log(listaPersonas)  
        })
     })

}

function cargarDepartamentos(){
    return new Promise((resolve, reject) => {  
        fetch('https://apipersonasdepto.azurewebsites.net/api/departamentos')
        .then(response => response.json())
        .then(data => {
            listaDepartamentos = data
            resolve()
            console.log(listaDepartamentos)  

        })
     })

}

function mostrarPersonas(){
    var tabla = document.getElementById("Personas")

    const fila = document.createElement("tr")

    listaPersonas.forEach(persona => {   

        let persDepto = new PersonaDepartamento(persona,listaDepartamentos.find(depto => depto.idDepartamento == persona.idDepartamento))

        fila.innerHTML = "<td>" + "<img src=" + persDepto.persona.foto + " width='100' height='100'>" + "</td>" 
        + "<td>" + persDepto.persona.nombre + "</td>" + "<td>" + persDepto.persona.apellido + "</td>" 
        + "<td>" + persDepto.persona.direccion + "</td>" + "<td>" + persDepto.persona.fNac + "</td>" 
        + "<td>" + persDepto.departamento.nombre + "</td>"

        tabla.appendChild(fila)

    });
}