window.onload = function () {
    var listPers = document.getElementById('listaPers')
    func_listadoDepartamentos().then(function () {
        func_listadoPersonas().then(function () {
            RellenarTablaPersonas() 
        });
    });
}

//Clase Persona
class Persona {

    constructor(id, nombre, apellido, direccion, tlf, idDepartamento, fNac, foto) {
        this.id = id
        this.nombre = nombre
        this.apellido = apellido
        this.direccion = direccion
        this.tlf = tlf
        this.idDepartamento = idDepartamento
        this.fNac = fNac
        this.foto = foto
    }
   
}

//Clase Departamento
class Departamento {
    constructor(idDepartamento, nombre) {
        this.idDepartamento = idDepartamento
        this.nombre = nombre
    }
}

//Clase PersonaDepartamento
class PersonaDepartamento {
    constructor(persona, departamento) {
        this.persona = persona
        this.departamento = departamento
    }
}

var listadoPersonas
var listadoDepartamentos

/**
 * Funcion que devuelve un listado de personas
 * @returns Una promesa que se resuelve cuando se obtiene el listado de personas
 */
function func_listadoPersonas() {
    return new Promise((resolve, reject) => {
        fetch('https://apipersonasdepto.azurewebsites.net/api/personas')
            .then(response => response.json())
            .then(data => {
                listadoPersonas = data
                resolve()
            })
    })
}
/**
 * Funcion que devuelve un listado de departamentos
 */
function func_listadoDepartamentos() {
    return new Promise((resolve, reject) => {
        fetch('https://apipersonasdepto.azurewebsites.net/api/departamentos')
            .then(response => response.json())
            .then(data => {
                listadoDepartamentos = data
                resolve()
            })
    })
}

/**
 * Funcion que muestra el listado de personas
 */
function MostrarPersonas(){

    if(document.getElementById('tablaDepartamentos')){
        var tablaD = document.getElementById('tablaDepartamentos')
        document.body.removeChild(tablaD)
    }

    if(!document.getElementById('tablaPersonas')){
        RellenarTablaPersonas()
    }
}

/**
 * Funcion que muestra el listado de departamentos
 */ 
function MostrarDepartamentos(){
      
    if(document.getElementById('tablaPersonas')){
        var tablaP = document.getElementById('tablaPersonas')
        document.body.removeChild(tablaP)
    }

    if(!document.getElementById('tablaDepartamentos')){
        RellenarTablaDepartamentos()
    }

}

/**
 * Funcion que rellena la tabla con los datos de los departamentos
 */
function RellenarTablaDepartamentos() {

    var titulo = document.getElementById('titulo')
    titulo.innerHTML = 'Listado de departamentos'

    let div = document.createElement('div')
    div.className = 'tablaDepartamentos'

    let table = document.createElement('table')
    table.className = 'tablaDepts'
    table.innerHTML = "<thead><tr><th>Nombre</th><th colspan = 2><div id='insert' class='boton-modal' onclick='modalInsertarDepartamento()'><label for='btn-modal-depto'>Insertar departamento</label></div></th></tr></thead>"

    //Recorro el listado de departamentos
    listadoDepartamentos.forEach(depto => {

        //Creo una fila
        const fila = document.createElement('tr')
        fila.id = depto.idDepartamento

        //Relleno la fila con los datos del departamento
        fila.innerHTML = "<td>" + depto.nombre + "</td>"

        fila.innerHTML += "<td><div class='boton-modal' onclick='modalModificarDepartamento("+depto.idDepartamento+")'><label for='btn-modal-depto'>Modificar</label></div></td>"
        fila.innerHTML += "<td><div class='btn-eliminar'onclick='EliminarDepartamento("+depto.idDepartamento+")'><label >Eliminar</label></div></td>"

        //Agrego la fila a la tabla
        table.appendChild(fila)

        div.appendChild(table)
        document.body.appendChild(div)
    });

}


/**
 * Funcion que rellena la tabla con los datos de las personas
 */
function RellenarTablaPersonas() {

    var titulo = document.getElementById('titulo')
    titulo.innerHTML = 'Listado de personas'

    var tabla = document.createElement('table')
    tabla.id = 'tablaPersonas'
    tabla.innerHTML = "<thead><tr><th>Foto</th><th>Nombre</th><th>Apellidos</th><th>Departamento</th><th colspan='2'><div id='insert' class='boton-modal' onclick='modalInsertarPersona()'><label for='btn-modal'>Insertar persona</label></div></th></tr></thead>"
    tabla.className = 'tablaPersonas'
    document.body.appendChild(tabla)

    //Recorro el listado de personas
    listadoPersonas.forEach(persona => {

        //Busco el nombre del departamento al que pertenece la persona
        let nombreDepto = listadoDepartamentos.find(depto => depto.idDepartamento == persona.idDepartamento).nombre

        //Creo una fila
        const fila = document.createElement('tr')
        fila.id = persona.id


        //Relleno la fila con los datos de la persona
        fila.innerHTML = "<td>" + "<img src=" + persona.foto + " width='75' height='75'>" + "</td><td>" + persona.nombre + "</td><td>" + persona.apellido + "</td><td>" + nombreDepto + "</td>"

        fila.innerHTML += "<td><div class='boton-modal' onclick='modalModificarPersona("+persona.id+")'><label for='btn-modal'>Modificar</label></div></td>"
        fila.innerHTML += "<td><div class='btn-eliminar'onclick='EliminarPersona("+persona.id+")'><label for='btn-modalD'>Eliminar</label></div></td>"

        //Agrego la fila a la tabla
        tabla.appendChild(fila)
    });
}

function cargarDepartamentos() {
    var select = document.getElementById('departamentos')

    //Elimino los departamentos que ya estaban cargados
    select.innerHTML = ''

    var predet = document.createElement('option')
    predet.value = ''
    predet.text = 'Seleccione un departamento'

    select.appendChild(predet)

    listadoDepartamentos.forEach(depto => {
        var option = document.createElement('option')
        option.value = depto.idDepartamento
        option.text = depto.nombre
        select.appendChild(option)
    })
}


//Personas
/**
 * Funcion que agrega una persona a la base de datos
 */
function AgregarPersona() {

    //Obtengo los datos de la persona de los campos del formulario
    var id = listadoPersonas.length + 1
    var nombre = document.getElementById('nombre').value
    var apellido = document.getElementById('apellidos').value
    var direccion = document.getElementById('direccion').value
    var tlf = document.getElementById('tlf').value
    var idDepartamento = document.getElementById('departamentos').value
    var fNac = document.getElementById('fecha').value
    var foto = document.getElementById('foto').value

    //Creo un objeto persona con los datos obtenidos
    var persona = new Persona(id, nombre, apellido, direccion, tlf, idDepartamento, fNac, foto)

    //Agrego la persona a la base de datos
    fetch('https://apipersonasdepto.azurewebsites.net/api/personas', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(persona)
    })
        .then(response => response.json())
        .then(data => {
            //Agrego la persona al listado de personas
            listadoPersonas.push(data)

            //Limpio los campos del formulario
            id.innerHTML = ''
            nombre.innerHTML = ''
            apellido.innerHTML = ''
            direccion.innerHTML = ''
            tlf.innerHTML = ''
            idDepto.innerHTML = ''
            fNac.innerHTML = ''
            foto.innerHTML = ''

            const fila = "<td>" + "<img src=" + persona.foto + " width='75' height='75'>" + "</td><td>" + persona.nombre + "</td><td>" + persona.apellido + "</td><td>" + nombreDepto + "</td>"

            tabla.appendChild(fila)

        })

}

/**
 * Funcion que modifica una persona a la base de datos
 */
function ModificarPersona(idPersona) {
  
    var nombre = document.getElementById('nombre').value
    var apellido = document.getElementById('apellidos').value
    var direccion = document.getElementById('direccion').value
    var tlf = document.getElementById('tlf').value
    var idDepartamento = document.getElementById('departamentos').value
    var fNac = document.getElementById('fecha').value
    var foto = document.getElementById('foto').value

    //Creo un objeto persona con los datos obtenidos
    var persona = new Persona(idPersona,nombre, apellido, direccion, tlf, idDepartamento, fNac, foto)


    //Agrego la persona a la base de datos
    fetch('https://apipersonasdepto.azurewebsites.net/api/personas/' + idPersona, {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(persona)
    })
        .then(response => response.json())
        .then(data => {
            //Agrego la persona al listado de personas
            listadoPersonas.push(data)

        })
}

/**
 * Funcion que elimina una persona de la base de datos
 */
function EliminarPersona(idPersona) {

    if (!confirm('¿Está seguro de que desea eliminar a esta persona?')) {
        return
    }

    var persona = listadoPersonas.find(persona => persona.id == idPersona)

    console.log(persona)

    fetch('https://apipersonasdepto.azurewebsites.net/api/personas/' + idPersona, {
        method: 'DELETE'
    }).then(response => {

        //Elimino la persona del listado de personas
        listadoPersonas = listadoPersonas.filter(persona => persona.id != idPersona)

        //Elimino la fila de la tabla
        var fila = document.getElementById(idPersona)
        fila.parentNode.removeChild(fila)

    })
}


//Departamentos

/**
 * Funcion que inserta un departamento en la base de datos
 */
function InsertarDepartamento() {
    var idDepartamento = listadoDepartamentos.length + 1
    var nombre = document.getElementById('nombre').value

    var departamento = new Departamento(idDepartamento, nombre)

    fetch('https://apipersonasdepto.azurewebsites.net/api/departamentos', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(departamento)
    })
        .then(response => response.json())
        .then(data => {
            listadoDepartamentos.push(data)
            cargarDepartamentos()
        })
}

/**
 * Funcion que modifica un departamento en la base de datos
 */
function ModificarDepartamento(idDepartamento) {
    var nombre = document.getElementById('nombre').value

    var departamento = new Departamento(idDepartamento, nombre)

    fetch('https://apipersonasdepto.azurewebsites.net/api/departamentos' + idDepartamento, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(departamento)
    })
        .then(response => response.json())
        .then(data => {
            listadoDepartamentos.push(data)
            cargarDepartamentos()
        })
}

/**
 * Funcion que elimina un departamento de la base de datos
 */
function EliminarDepartamento(idDepartamento) {

    if (!confirm('¿Está seguro de que desea eliminar a este departamento?')) {
        return
    }

    fetch('https://apipersonasdepto.azurewebsites.net/api/departamentos/' + idDepartamento, {
        method: 'DELETE'
    }).then(response => {
        listadoDepartamentos = listadoDepartamentos.filter(depto => depto.idDepartamento != idDepartamento)

        //Elimino la fila de la tabla
        var fila = document.getElementById(idDepartamento)
        fila.parentNode.removeChild(fila)

        cargarDepartamentos()
    })
}


function modalInsertarPersona() {

    document.getElementById('nombre').value = ''
    document.getElementById('apellidos').value = ''
    document.getElementById('direccion').value = ''
    document.getElementById('tlf').value = ''
    document.getElementById('fecha').value = ''
    document.getElementById('foto').value = ''
    document.getElementById('departamentos').value = ''

    var titulo = document.getElementById('title')
    titulo.innerHTML = 'Insertar Persona'

    var button = document.getElementById('guardar')
    button.setAttribute('onclick', 'AgregarPersona()')
}

function modalModificarPersona(idPersona) {

    console.log(idPersona)

    var titulo = document.getElementById('title')
    titulo.innerHTML = 'Modificar Persona'

    var persona = listadoPersonas.find(persona => persona.id == idPersona)

    var nombreDepto = listadoDepartamentos.find(depto => depto.idDepartamento == persona.idDepartamento)

    document.getElementById('nombre').value = persona.nombre
    document.getElementById('apellidos').value = persona.apellido
    document.getElementById('direccion').value = persona.direccion
    document.getElementById('tlf').value = persona.tlf
    document.getElementById('fecha').value = persona.fNac
    document.getElementById('foto').value = persona.foto
    document.getElementById('departamentos').value = nombreDepto.nombre

    var button = document.getElementById('guardar')
    button.setAttribute('onclick', 'ModificarPersona(' + idPersona + ')')

}

function modalInsertarDepartamento() {

    document.getElementById('nombre').value = ''

    var titulo = document.getElementById('titleM')
    titulo.innerHTML = 'Insertar Departamento'

    var button = document.getElementById('guardar')
    button.setAttribute('onclick', 'InsertarDepartamento()')
}

function modalModificarDepartamento(idDepartamento) {
    
        var titulo = document.getElementById('titleM')
        titulo.innerHTML = 'Modificar Departamento'
    
        var departamento = listadoDepartamentos.find(depto => depto.idDepartamento == idDepartamento)
    
        console.log(departamento)

        document.getElementById('departa').value = departamento.nombre
    
        var button = document.getElementById('guardar')
        button.setAttribute('onclick', 'ModificarDepartamento(' + idDepartamento + ')')
}