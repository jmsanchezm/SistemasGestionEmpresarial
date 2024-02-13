class Marca{
    constructor (idMarca, nombre){
        this.idMarca = idMarca
        this.nombre = nombre
    }
}

class Modelo {
    constructor(idModelo, nombre,idMarca){
        this.idModelo = idModelo
        this.nombre=nombre
        this.idMarca = idMarca
    }
}

const Marcas = [
    new Marca (1,'Mercedes'),
    new Marca (2, 'Audi'),
    new Marca (3, 'Tesla'),
    new Marca (4,'Cupra')
]

const Modelos = [
    new Modelo(1, "Modelo A", 1),
    new Modelo(2, "Modelo B", 1),
    new Modelo(3, "Modelo C", 1),
    new Modelo(4, "Modelo X", 2),
    new Modelo(5, "Modelo Y", 2),
    new Modelo(6, "Modelo Z", 2),
    new Modelo(7, "Modelo S", 3),
    new Modelo(8, "Modelo 3", 3),
    new Modelo(9, "Modelo X", 3),
    new Modelo(10, "Modelo T", 4),
    new Modelo(11, "Modelo U", 4),
    new Modelo(12, "Modelo V", 4)
]

function mostrarMod() {
    var marcaSelect = document.getElementById('Marcas').value;
    var modelosPorMarca = document.getElementById('Modelos');

    modelosPorMarca.innerHTML = '';

    for (let i = 0; i < Modelos.length; i++) {
        if (Modelos[i].idMarca == marcaSelect){
            const option = document.createElement('option');
            option.value = Modelos[i].idModelo;
            option.text = Modelos[i].nombre;
            modelosPorMarca.add(option);
        }
    }
}