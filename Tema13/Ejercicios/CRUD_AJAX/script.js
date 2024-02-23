window.onload = function () {

    func_listadoDepartamentos().then(function () {
        func_listadoPersonas().then(function () {
            RellenarTabla()
        });
    });
}

//Clase Persona
class Persona {
    constructor(id, nombre, apellido, direccion,tlf,idDepartamento,fNac, foto) {
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
function func_listadoPersonas(){
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
function func_listadoDepartamentos(){
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
 * Funcion que rellena la tabla con los datos de las personas
 */
function RellenarTabla() {
    var tabla = document.getElementById('tablaPersonas')

    //Recorro el listado de personas
    listadoPersonas.forEach(persona => {

        //Busco el nombre del departamento al que pertenece la persona
        let nombreDepto = listadoDepartamentos.find(depto => depto.idDepartamento == persona.idDepartamento).nombre

        //Creo una fila para la persona
        const fila = document.createElement('tr')
        fila.setAttribute('id', 'persona' + persona.idPersona)

        //Relleno la fila con los datos de la persona
        fila.innerHTML = "<td>" + "<img src=" + persona.foto + " width='100' height='100'>" + "</td><td>" + persona.nombre + "</td><td>" + persona.apellido + "</td><td>" + nombreDepto + "</td>"

        //Agrego la fila a la tabla
        tabla.appendChild(fila)
    });
}


/**
 * Funcion que crea un modal para agregar una persona
 */
function modalPersona() {
    // Creo el modal
    var contenedorModal = document.createElement('div');
    contenedorModal.className = 'contenedor-modal';

    var modal = document.createElement('div');
    modal.className = 'modal';

    // Creo el título del modal
    var titulo = document.createElement('h2');
    titulo.id = 'title';

    // Creo el formulario
    var form = document.createElement('form');
    form.id = 'form';

    // Creo los campos del formulario
    let labelNombres = ['Nombre', 'Apellidos', 'Direccion', 'Telefono', 'Foto'];
    let idNombres = ['nombre', 'apellidos', 'direccion', 'telefono', 'foto'];

    for (let i = 0; i < labelNombres.length; i++) {
        let label = document.createElement('label');
        label.innerHTML = labelNombres[i];

        let input = document.createElement('input');
        input.type = 'text';
        input.id = idNombres[i];

        form.appendChild(label);
        form.appendChild(input);
    }

    // Creo el campo de departamento, con un select
    var labelDepto = document.createElement('label');
    labelDepto.innerHTML = 'Departamento';

    var select = document.createElement('select');
    select.id = 'depto';

    listadoDepartamentos.forEach(depto => {
        var option = document.createElement('option');
        option.value = depto.idDepartamento;
        option.innerHTML = depto.nombre;

        select.appendChild(option); // Agregar opción al select
    });

    form.appendChild(labelDepto);
    form.appendChild(select);

    // Creo el campo de fecha de nacimiento
    var labelFechaNac = document.createElement('label');
    labelFechaNac.innerHTML = 'Fecha de Nacimiento';

    var inputFechaNac = document.createElement('input');
    inputFechaNac.type = 'date';
    inputFechaNac.id = 'fNac';

    form.appendChild(labelFechaNac);
    form.appendChild(inputFechaNac);

    // Creo el botón de agregar
    var boton = document.createElement('button');
    boton.innerHTML = 'Agregar';
    boton.onclick = AgregarPersona;

    form.appendChild(boton);

    // Agregar el formulario al modal
    modal.appendChild(form);

    // Agregar el modal al contenedorModal
    contenedorModal.appendChild(modal);

    // Agregar el contenedorModal al cuerpo del documento
    document.body.appendChild(contenedorModal);
}

/**
 * Funcion que agrega una persona a la base de datos
 */
function AgregarPersona() { 
    //Obtengo los datos de la persona de los campos del formulario
    var id = listadoPersonas.length + 1  
    var nombre = document.getElementById('nombre').value
    var apellido = document.getElementById('apellidos').value
    var direccion = document.getElementById('direccion').value  
    var tlf = document.getElementById('telefono').value
    var idDepto = document.getElementById('depto').value
    var fNac = document.getElementById('fNac').value
    var foto = document.getElementById('foto').value

    //Creo un objeto persona con los datos obtenidos
    var persona = new Persona(id, nombre, apellido, direccion, tlf, idDepto, fNac, foto)

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
        //Vuelvo a rellenar la tabla
        RellenarTabla()
    })
}