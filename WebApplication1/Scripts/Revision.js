

document.addEventListener('DOMContentLoaded', function () {
    // Función para obtener la fecha y hora actual en el formato adecuado
    function getCurrentDateTime() {
        return moment().format('YYYY-MM-DD HH:mm');
    }

    // Configuración inicial de la fecha de ingreso
    document.getElementById('F_revision').value = getCurrentDateTime();


});



    // Evento clic del botón "Buscar"
        $("#btnBuscar").on("click", function () {

            let IdBusqueda = $('#IdBusqueda').val();

            $.ajax({
                type: "GET",
                url: "/Revision/ConsultaRequerimiento",
                data: {
                    ID_ingreso_requerimiento: IdBusqueda
                },
                dataType: "json",
                success: function (response) {

                    let fechaIngresoFormateada = moment(response.datos.fecha_ingreso).format('YYYY-MM-DD HH:mm');
                    let fechaPlazoFormateada = moment(response.datos.F_Plazo).format('YYYY-MM-DD HH:mm');

                    $('#ID_ingreso_requerimiento').val(response.datos.ID_ingreso_requerimiento);
                    $('#ID_Estado').val(response.datos.ID_Estado);
                    $('#ID_Solicitante').val(response.datos.ID_Solicitante);
                    $('#ID_Tipo_requerimiento').val(response.datos.ID_Tipo_requerimiento);
                    $('#ID_Prioridad').val(response.datos.ID_Prioridad);
                    $('#Requerimiento').val(response.datos.Requerimiento);
                    $('#ID_Proyecto').val(response.datos.ID_Proyecto);
                    $('#ID_Aplicacion').val(response.datos.ID_Aplicacion);
                    $('#Opcion').val(response.datos.Opcion);
                    $('#ID_Hardware').val(response.datos.ID_Hardware);
                    $('#Comentario').val(response.datos.Comentario);
                    $('#fecha_ingreso').val(fechaIngresoFormateada);
                    $('#F_Plazo').val(fechaPlazoFormateada);
                
                },

            });
        });


IdUsuario
$(document).ready(function () {
    $('#ID_Usuario').select2({
        minimumInputLength: 1,
        width: '100%',
        allowClear: true,
        placeholder: 'Buscar Tipo de Usuario',
        ajax: {
            url: '/Revision/ObtenerDatosUsuario',
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    term: params.term || ''
                };
            },
            processResults: function (data) {
                return {
                    results: data.items || []
                };
            }
        }
    });

    $('#ID_Usuario').on('select2:select', function (e) {
        var IdUsuario = e.params.data.id;
        $('#IdUsuario').val(IdUsuario)
    });

    $('#ID_Usuario').on('select2:unselect', function (e) {
        $('#IdUsuario').val(0)
    });
});


    
//$('#ID_Usuario').select2({
//        width: '100%', allowClear: true,
//        placeholder: 'Buscar Usuario Revision',
//        ajax: {
//            url: '/Revision/ObtenerDatosUsuario',
//            data: function (params) {

//                var id_Usuario= params.term;

//                var query = {
//                    ID_Usuario: id_Usuario == null ? 0 : id_Usuario,

//                }

//                return query;
//            },
//            processResults: function (data) {
//                // Transforms the top-level key of the response object from 'items' to 'results'
//                return {
//                    results: data.items
//                };
//            }

//        }
//    });

//$('#ID_Usuario').on('select2:select', function (e) {
//    var IdUsuario = e.params.data.id;
//    $('#IdUsuario').val(IdUsuario)
//    });
//$('#ID_Usuario').on('select2:unselect', function (e) {
//    $('#IdUsuario').val(0)
//    });



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
    var fplazo = moment($("#F_Plazo").val()).format('YYYY-MM-DD HH:mm'); 
    var F_revision = moment($("#F_Plazo").val()).format('YYYY-MM-DD HH:mm'); 
    var datos = {
            fecha_ingreso: $("#fecha_ingreso").val(),
            ID_ingreso_requerimiento: $("#ID_ingreso_requerimiento").val(),
            ID_Estado: $("#ID_Estado").val(),
            ID_Solicitante: $("#ID_Solicitante").val(),
            ID_Tipo_requerimiento: $("#ID_Tipo_requerimiento").val(),
            ID_Prioridad: $("#ID_Prioridad").val(),
            Requerimiento: $("#Requerimiento").val(),   
            ID_Proyecto: $("#ID_Proyecto").val(),
            ID_Aplicacion: $("#ID_Aplicacion").val(),
            Opcion: $("#Opcion").val(),
            ID_Hardware: $("#ID_Hardware").val(),
            Comentario: $("#Comentario").val(),
            F_Plazo: fplazo,
        F_revision: F_revision,
            Comentario_rev: $("#Comentario_rev").val(),
            Duracion_Hr: $("#Duracion_Hr").val(),
            ID_Usuario: $("#ID_Usuario").val()
        };

        console.log("Data", datos);

        $.ajax({
            type: "POST",
            url: '/Revision/BtnEnviarDatos',

            data: {
                ID_ingreso_requerimiento: $("#ID_ingreso_requerimiento").val(),
                ID_Estado: $("#ID_Estado").val(),
                ID_Solicitante: $("#ID_Solicitante").val(),
                ID_Tipo_requerimiento: $("#ID_Tipo_requerimiento").val(),
                ID_Prioridad: $("#ID_Prioridad").val(),
                Requerimiento: $("#Requerimiento").val(),
                ID_Proyecto: $("#ID_Proyecto").val(),
                ID_Aplicacion: $("#ID_Aplicacion").val(),
                Opcion: $("#Opcion").val(),
                ID_Hardware: $("#ID_Hardware").val(),
                Comentario: $("#Comentario").val(),
                fecha_ingreso: $("#fecha_ingreso").val(),
                F_Plazo: fplazo,
                F_revision: F_revision,
                Comentario_rev: $("#Comentario_rev").val(),
                Duracion_Hr: $("#Duracion_Hr").val(),
                ID_Usuario: $("#ID_Usuario").val()
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
