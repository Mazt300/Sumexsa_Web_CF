function Modal_confirmacion(docuement) {
    // Obtener modal
    var modal = document.getElementById("Modal_confirmacion");
    // Obtener el boton que generará la accion
    var btn = document.getElementById("btn_modal");
    // Obtener el span de cierre
    var span = document.getElementsByClassName("close")[0];
    // Evento apertura de modal en el boton
    btn.onclick = function () {
        modal.style.display = "block";
    }
    // Cuando clicke la X se cerrara la ventana modal
    span.onclick = function () {
        modal.style.display = "none";
    }
    // Si el usuario da click en la parte exterior del modal cerrar la ventana
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}