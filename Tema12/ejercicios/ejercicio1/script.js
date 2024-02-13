function changeText(){
    var h1s
    var miboton=document.getElementById("boton");
    h1s=document.getElementsByTagName("h1");

    for (i=0;i<h1s.length;i++){
        h1s[i].innerHTML="Bienvenido a mi página web";

        if (i == 1){
            h1s[i].innerHTML="Como tan muchacho";    
        }

    }
    
    miboton.value = "Cambiado";
    miboton.disabled = true;    
    
}


