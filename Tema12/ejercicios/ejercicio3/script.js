class Marca{
    constructor(id, nombre){
        this.id = id;
        this.nombre = nombre;
    }
}

class Modelo{
    constructor(id, nombre, marca){
        this.id = id;
        this.nombre = nombre;
        this.marca = marca;
    }
}


const modelos = [
    new Modelo(1, "Modelo 1", new Marca(1, "Mercedes")),
    new Modelo(2, "Modelo 2", new Marca(2, "Audi")),
    new Modelo(3, "Modelo 3", new Marca(1, "Seat")),
    new Modelo(4, "Modelo 4", new Marca(3, "BMW")),
    new Modelo(5, "Modelo 5", new Marca(2, "Skoda")),
];

function cargarModelosDeMarca(marca) {
    const modelosDeMarca = modelos.filter(modelo => modelo.marca === marca);

    var modelosSelect = document.getElementById("modelo");


    return modelosDeMarca;
}




