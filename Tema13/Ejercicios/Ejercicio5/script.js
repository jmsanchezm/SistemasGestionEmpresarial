window.onload = function(){

    traerDepartamentos().then(function(){
    
        traerPersona()
    
    })
}


class Persona {
    constructor(id, nombre, tlf, direccion,apellido,idDepartamento,fNac,foto,nombreCompleto){
        this.id = id
        this.nombre = nombre
        this.tlf = tlf
        this.direccion = direccion
        this.apellido = apellido
        this.idDepartamento = idDepartamento
        this.fNac = fNac
        this.foto = foto
        this.nombreCompleto = nombreCompleto
    }
}

class Departamento {
    constructor(idDepartamento, nombre){
        this.idDepartamento = idDepartamento
        this.nombre = nombre
    }
}

class PersonaDepartamento {
    constructor(persona, departamento){
        this.persona = persona
        this.departamento = departamento
    }
}

function traerPersona(){

    var tabla = document.getElementById('tablaPersonas')

    fetch('https://crudjuanmasanchez.azurewebsites.net/API/Personas')
    .then(response => response.json())
    .then( data => {
        tabla.innerHTML =''

        let request =data

        request.forEach(personas => {

            let personaDepto = new PersonaDepartamento(personas,listadoDepartamentos.find(depto => depto.idDepartamento == personas.idDepartamento))
            const fila = document.createElement('tr')

            fila.innerHTML = "<td>"+personaDepto.persona.nombre+"</td><td>"+personaDepto.persona.apellido+"</td><td>"+personaDepto.departamento.nombre+"</td>"
            
            tabla.appendChild(fila)
        });
    })
}

function traerDepartamentos(){
    return new Promise((resolve, reject) => {
        fetch('https://crudjuanmasanchez.azurewebsites.net/API/Departamentos')
        .then(response => response.json())
        .then(data => {
            listadoDepartamentos = data;
            resolve();
        })
        .catch(error => reject(error));
    });
}

