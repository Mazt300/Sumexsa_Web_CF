﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    //Contenedor principal en la pagina que invoca el modal
    //Mostrar el modal
    var DivContent = $('#contenedorModal');
    //Funcion para encontrar el boton que ejerce con el data-toggle exacto
    $('button[data-toggle="boostrap-modal"]').click(function (event) {

        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            DivContent.html(data);
            DivContent.find('.modal').modal('show');
        })

    })

    //Ocultar el modal
    DivContent.on('click', '[data-dismiss="modal"]', function (event) {
        event.preventDefault();
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (data) {
            DivContent.find('.modal').modal('hide');
        })
    })
})