var nombre = document.getElementById("nombre").value
var apellido = document.getElementById("apellidos").value

class Persona {
    constructor(nombre, apellido) {
        this.nombre = nombre;
        this.apellido = apellido;
    }

    toString() {
        return this.nombre + ' ' + this.apellido;
    }
}

function saludo() {
    

    var pers = new Persona(nombre, apellido);

    alert('Hola ' + pers.toString());
}