class Persona {
    constructor(nombre, apellidos) {
        this.nombre = nombre;
        this.apellidos = apellidos;
    }
}

function saludoPersona() {
    var nombre = document.getElementById('nombre').value;
    var apellidos = document.getElementById('apellidos').value;

    var persona = new Persona(nombre, apellidos);

    alert('Hola ' + persona.nombre + ' ' + persona.apellidos);
}