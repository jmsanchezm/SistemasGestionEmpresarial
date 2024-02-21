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

    var llamada = new XMLHttpRequest()

    var tabla = document.getElementById('tablaPersonas')

    llamada.open('GET','https://crudjuanmasanchez.azurewebsites.net/API/Personas')

    llamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');

    llamada.onreadystatechange= function(){
        
        if (llamada.readyState < 4) {
            
            tabla.innerHTML = "<tr><td>Nombre</td><td>Apellido</td><td>Departamento</td><tr>"
            
            const fila1 = document.createElement('tr')
            fila1.innerHTML = "<td>Cargando...</td><td>Cargando...</td><td>Cargando...</td>"
            tabla.appendChild(fila1)
            
        }            
        
        else if (llamada.readyState == 4 && llamada.status == 200) {

            tabla.innerHTML =''

            let request = JSON.parse(llamada.responseText)

            request.forEach(personas => {

                let personaDepto = new PersonaDepartamento(personas,listadoDepartamentos.find(depto => depto.idDepartamento == personas.idDepartamento))
                const fila = document.createElement('tr')

                fila.innerHTML = "<td>"+personaDepto.persona.nombre+"</td><td>"+personaDepto.persona.apellido+"</td><td>"+personaDepto.departamento.nombre+"</td>"
                
                tabla.appendChild(fila)
            });

            

        }else{
            console.error('Error al cargar personas:', llamada.status, llamada.statusText);
        }
        

    }
    llamada.send()
}

function traerDepartamentos(){

    return new Promise(function(resolve, reject){
            
            var llamada = new XMLHttpRequest()
    
            llamada.open('GET','https://crudjuanmasanchez.azurewebsites.net/API/departamentos')
    
            llamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    
            llamada.onreadystatechange= function(){
                
                if (llamada.readyState < 4) {
                    
                }
                
                else if (llamada.readyState == 4 && llamada.status == 200) {
                
                    listadoDepartamentos = JSON.parse(llamada.responseText)
                    resolve(listadoDepartamentos)
    
                }else{
                    reject('Error al cargar departamentos: ' + llamada.status + ' ' + llamada.statusText);
                }
    
            }
            llamada.send()
    })
}

