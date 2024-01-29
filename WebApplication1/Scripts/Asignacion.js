// Evento clic del botón "Buscar"
$("#btnBuscar").on("click", function () {

    let IdBusqueda = $('#IdBusqueda').val();

    $.ajax({
        type: "POST",
        url: "/Asignado/ConsultaRequerimiento",
        data: {
            ID_ingreso_requerimiento: IdBusqueda
        },
        dataType: "json",
        success: function (response) {

            let fechaRevisionFormateada = moment(response.datos.F_revision).format('YYYY-MM-DD HH:mm');

            $('#ID_ingreso_requerimiento').val(response.datos.ID_ingreso_requerimiento);
            $('#ID_Solicitante').val(response.datos.ID_Solicitante);
            $('#Requerimiento').val(response.datos.Requerimiento);
            $('#Duracion_Hr').val(response.datos.Duracion_Hr);
            $('#Comentario_rev').val(response.datos.Comentario_rev);
            $('#F_revision').val(fechaRevisionFormateada);
            $('#ID_Estado').val(response.datos.ID_Estado);

        },

    });
});


IdEjecutor

$('#ID_Ejecutor').select2({
    width: '100%', allowClear: true,
    placeholder: 'Buscar Ejecutor',
    ajax: {
        url: '/Asignado/ObtenerDatosEjecutor',
        data: function (params) {

            var id_Ejecutor = params.term;

            var query = {
                ID_Ejecutor: id_Ejecutor == null ? 0 : id_Ejecutor,

            }

            return query;
        },
        processResults: function (data) {
            // Transforms the top-level key of the response object from 'items' to 'results'
            return {
                results: data.items
            };
        }

    }
});

$('#ID_Ejecutor').on('select2:select', function (e) {
    var IdEjecutor = e.params.data.id;
    $('#ID_Ejecutor').val(IdEjecutor)
});
$('#ID_Ejecutor').on('select2:unselect', function (e) {
    $('#IdEjecutor').val(0)
});




IdPublicado
$('#ID_Publicado').select2({
    width: '100%', allowClear: true,
    placeholder: '¿Deseas Publicarlo?',
    ajax: {
        url: '/Asignado/ObtenerDatosPublicado',
        data: function (params) {

            var id_Publicado = params.term;

            var query = {
                ID_Publicado: id_Publicado == null ? 0 : id_Publicado,

            }

            return query;
        },
        processResults: function (data) {
            // Transforms the top-level key of the response object from 'items' to 'results'
            return {
                results: data.items
            };
        }

    }
});

$('#ID_Publicado').on('select2:select', function (e) {
    var IdPublicado = e.params.data.id;
    $('#ID_Publicado').val(IdPublicado)
});
$('#ID_Publicado').on('select2:unselect', function (e) {
    $('#IdPublicado').val(0)
});

$("#BtnCancelar").on("click", function (e) {
    var agree = confirm("¿Realmente deseas eliminar los datos?");

    if (!agree) {
        e.preventDefault();
    } else {

        location.reload();
    }
});


// Evento clic del botón
$("#BtnEnviarDatos").on("click", function () {
    // Recolecta los datos que deseas enviar al servidor
    var F_inicio = moment($("#F_Plazo").val()).format('YYYY-MM-DD HH:mm'); 
    var F_fin = moment($("#F_Plazo").val()).format('YYYY-MM-DD HH:mm'); 
    var datos = {
        ID_ingreso_requerimiento: $("#ID_ingreso_requerimiento").val(),
        ID_Solicitante: $("#ID_Solicitante").val(),
        Requerimiento: $("#Requerimiento").val(),
        F_revision: $("#F_revision").val(),
        Comentario_rev: $("#Comentario_rev").val(),
        Duracion_Hr: $("#Duracion_Hr").val(),
        ID_Ejecutor: $("#ID_Ejecutor").val(),
        Comentario_asig: $("#Comentario_asig").val(),
        ID_Publicado: $("#ID_Publicado").val(),
        Cumplimiento: $("#Cumplimiento").val(),
        F_inicio:F_inicio,
        F_fin:F_fin,
        ID_Estado: $("#ID_Estado").val()
    };

    console.log("Data", datos);

    $.ajax({
        type: "POST",
        url: '/Asignado/BtnEnviarDatos',

        data: {
            ID_ingreso_requerimiento: $("#ID_ingreso_requerimiento").val(),
            ID_Solicitante: $("#ID_Solicitante").val(),
            Requerimiento: $("#Requerimiento").val(),
            F_revision: $("#F_revision").val(),
            Comentario_rev: $("#Comentario_rev").val(),
            Duracion_Hr: $("#Duracion_Hr").val(),
            ID_Ejecutor: $("#ID_Ejecutor").val(),
            Comentario_asig: $("#Comentario_asig").val(),
            ID_Publicado: $("#ID_Publicado").val(),
            Cumplimiento: $("#Cumplimiento").val(),
            F_inicio: F_inicio,
            F_fin: F_fin,
            ID_Estado: $("#ID_Estado").val()
        },
    }).done(function (result) {
        if (result.success) {
            alert(result.message);
            // Recargar la página si el requerimiento se guarda exitosamente
            location.reload();
        } else {
            console.log(result.error);
            // Manejar errores de validación u otros casos
            // Puedes mostrar mensajes de error al usuario según tus necesidades
        }
    }).fail(function (result) {
        alert('Error en la solicitud: ' + result);
    });
});