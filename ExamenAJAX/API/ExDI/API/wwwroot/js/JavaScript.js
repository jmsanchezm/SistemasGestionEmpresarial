window.onload = function () {
    func_listadoPersonas().then(function () {
        rellenarTabla()
    })

    func_listadoDeptos()

}


var listadoPersonas
var listadoDeptos
var checks = []
var persSelect = []

/**
 * Funcion que trae de la API un listado de personas
 */
function func_listadoPersonas() {
    return new Promise((resolve, reject) => {
        fetch("http://localhost:5264/api/personas")
            .then(response => response.json())
            .then(data => {
                listadoPersonas = data
                console.log(listadoPersonas)

                resolve()
            })
    })
}

/**
 * Función que trae de la API un listado de departamentos
 */
function func_listadoDeptos() {
    fetch("http://localhost:5264/api/departamentos")
        .then(response => response.json())
        .then(data => {
            listadoDeptos = data
            console.log(listadoDeptos)
        })
}

/**
 * Funcion que rellena la tabla de las personas
 */
function rellenarTabla()
{
    //Cojo la tabla de las personas
    let table = document.getElementById("tablaPersonas")

    for (let i = 0; i < listadoPersonas.length; i++) {

        let fila = document.createElement("tr")

        let check = document.createElement("input")
        check.type = "checkbox"
        check.id = listadoPersonas[i].id

        checks.push(check)

        //Le añado la informacion de la persona
        fila.innerHTML = "<td>" + listadoPersonas[i].nombre + "</td><td>" + listadoPersonas[i].apellidos + "</td>"

        //Añado el checkbox
        fila.appendChild(check)

        //Añado la fila a la tabla
        table.appendChild(fila)
        
    }
}

/**
 * Función que mostrará los detalles de la persona, si es seleccionada
 */
function mostrarDetalles() {

    let listPers = document.getElementById("listPers")


    for (let i = 0; i < checks.length; i++) {
        //Si el check está seleccionado
        if (checks[i].checked) {
            //Añado a la lista de personas seleccionadas el id del check
            //Dicho id del check corresponde con el de la persona
            persSelect.push(checks[i].id)
        }

    }

    if (persSelect.length == 0) {
        alert("Debe seleccionar al menos una persona")
    } else {
        persSelect.forEach(id => {
            //Buscamos la persona en el listado, que ya tenemos en la RAM 
            let pers = listadoPersonas.find(persona => persona.id == id)

            //Buscamos tambien el departamento al que pertenece la persona
            let departamento = listadoDeptos.find(depto => depto.id == pers.idDepartamento)
            let persona = document.createElement("div")

            //Creamos un elemento con el nombre
            let nombre = document.createElement("label")
            nombre.innerHTML = "Nombre:" + pers.nombre

            //Apellido
            let apellidos = document.createElement("label")
            apellidos.innerHTML = "Apellidos: " + pers.apellidos

            //Nombre del departamento al que pertenece
            let nombreDepto = document.createElement("label")
            nombreDepto.innerHTML = "Departamento: " + departamento.nombre
            console.log(departamento.nombre)

            //Foto
            let foto = document.createElement("img")
            foto.id = "foto"
            foto.src = "Images/foto.png"


            //Linea separadora
            let linea = document.createElement("hr")

            //Añado la informacion al apartado persona
            persona.appendChild(foto)
            persona.appendChild(nombre)
            persona.appendChild(apellidos)
            persona.appendChild(nombreDepto)
            persona.appendChild(linea)

            listPers.appendChild(persona)


        })
    }

}

