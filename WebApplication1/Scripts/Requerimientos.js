document.addEventListener('DOMContentLoaded', function () {
    // Función para obtener la fecha y hora actual en el formato adecuado
    function getCurrentDateTime() {
        return moment().format('YYYY-MM-DD HH:mm');
    }

    // Configuración inicial de la fecha de ingreso
    document.getElementById('fecha_ingreso').value = getCurrentDateTime();
    
    
});


IdAplicacion

$(document).ready(function () {
    $('#ID_Aplicacion').select2({
        minimumInputLength: 1,
        width: '100%',
        allowClear: true,
        placeholder: 'Buscar Aplicacion',
        ajax: {
            url: '/Requerimiento/ObtenerDatosAplicacion',
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

    $('#ID_Aplicacion').on('select2:select', function (e) {
        var IdAplicacion = e.params.data.id;
        $('#IdAplicacion').val(IdAplicacion)
    });

    $('#ID_Aplicacion').on('select2:unselect', function (e) {
        $('#IdAplicacion').val(0)
    });
});



IdEstado
$('#ID_Estado').select2({
    width: '100%', allowClear: true,
    placeholder: 'Buscar Estado',
    ajax: {
        url: '/Requerimiento/ObtenerDatosEstado',
        data: function (params) {

            var id_Estado = params.term;

            var query = {
                ID_Estado: id_Estado == null ? 0 : id_Estado,

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

$('#ID_Estado').on('select2:select', function (e) {
    var IdEstado = e.params.data.id;
    $('#ID_Estado').val(IdEstado)
});
$('#ID_Estado').on('select2:unselect', function (e) {
    $('#IdEstado').val(0)
});

ID_Tipo_requerimiento

$('#ID_Tipo_requerimiento').select2({
    width: '100%', allowClear: true,
    placeholder: 'Buscar Tipo Requerimiento',
    ajax: {
        url: '/Requerimiento/ObtenerDatosTipoRequerimiento',
        data: function (params) {

            var id_Tipo_requerimiento = params.term;

            var query = {
                ID_Tipo_requerimiento: id_Tipo_requerimiento == null ? 0 : id_Tipo_requerimiento,

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

$('#ID_Tipo_requerimiento').on('select2:select', function (e) {
    var id_Tipo_requerimiento = e.params.data.id;
    $('#ID_Tipo_requerimiento').val(id_Tipo_requerimiento)
});
$('#ID_Tipo_requerimiento').on('select2:unselect', function (e) {
    $('#id_Tipo_requerimiento').val(0)
});

IdSolicitante
$(document).ready(function () {
    $('#ID_Solicitante').select2({
        width: '100%',
        allowClear: true,
        placeholder: 'Buscar Solicitante',
        minimumInputLength: 2, 
        ajax: {
            url: '/Requerimiento/ObtenerDatosSolicitante',
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

    $('#ID_Solicitante').on('select2:select', function (e) {
        var IdSolicitante = e.params.data.id;
        $('#IdSolicitante').val(IdSolicitante)
    });

    $('#ID_Solicitante').on('select2:unselect', function (e) {
        $('#IdSolicitante').val(0)
    });
});





//$('#ID_Solicitante').select2({
//    width: '100%', allowClear: true,
//    placeholder: 'Buscar Solicitante',
//    ajax: {
//        url: '/Requerimiento/ObtenerDatosSolicitante',
//        data: function (params) {

//            var id_Solicitante = params.term;

//            var query = {
//                ID_Solicitante: id_Solicitante == null ? 0 : id_Solicitante,

//            }

//            return query;
//        },
//        processResults: function (data) {
//            // Transforms the top-level key of the response object from 'items' to 'results'
//            return {
//                results: data.items
//            };
//        }

//    }
//});

//$('#ID_Solicitante').on('select2:select', function (e) {
//    var IdSolicitante = e.params.data.id;
//    $('#ID_Solicitante').val(IdSolicitante)
//});
//$('#ID_Solicitante').on('select2:unselect', function (e) {
//    $('#IdSolicitante').val(0)
//});


IdPrioridad

$('#ID_Prioridad').select2({
    width: '100%', allowClear: true,
    placeholder: 'Buscar Prioridad',
    ajax: {
        url: '/Requerimiento/ObtenerDatosPrioridad',
        data: function (params) {

            var id_Prioridad = params.term;

            var query = {
                ID_Prioridad: id_Prioridad == null ? 0 : id_Prioridad,

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

$('#ID_Prioridad').on('select2:select', function (e) {
    var IdPrioridad = e.params.data.id;
    $('#ID_Prioridad').val(IdPrioridad)
});
$('#ID_Prioridad').on('select2:unselect', function (e) {
    $('#IdPrioridad').val(0)
});

IdProyecto

$('#ID_Proyecto').select2({
    width: '100%', allowClear: true,
    placeholder: 'Buscar Proyecto',
    ajax: {
        url: '/Requerimiento/ObtenerDatosProyecto',
        data: function (params) {

            var id_Proyecto = params.term;

            var query = {
                ID_Proyecto: id_Proyecto == null ? 0 : id_Proyecto,

            }

            return query;
        },
        processResults: function (data) {
            return {
                results: data.items
            };
        }

    }
});

IdHardware

$(document).ready(function () {
    $('#ID_Hardware').select2({
        minimumInputLength: 1,
        width: '100%',
        allowClear: true,
        placeholder: 'Buscar Tipo de Hardware',
        ajax: {
            url: '/Requerimiento/ObtenerDatosHardware',
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

    $('#ID_Hardware').on('select2:select', function (e) {
        var IdHardware = e.params.data.id;
        $('#IdHardware').val(IdHardware)
    });

    $('#ID_Hardware').on('select2:unselect', function (e) {
        $('#IdHardware').val(0)
    });
});





//$('#ID_Hardware').select2({
//    width: '100%', allowClear: true,
//    placeholder: 'Buscar Hardware',
//    ajax: {
//        url: '/Requerimiento/ObtenerDatosHardware',
//        data: function (params) {

//            var id_Hardware = params.term;

//            var query = {
//                ID_Hardware: id_Hardware == null ? 0 : id_Hardware,

//            }

//            return query;
//        },
//        processResults: function (data) {
//            // Transforms the top-level key of the response object from 'items' to 'results'
//            return {
//                results: data.items
//            };
//        }

//    }
//});

//$('#ID_Hardware').on('select2:select', function (e) {
//    var IdHardware = e.params.data.id;
//    $('#IdHardware').val(IdHardware)
//});
//$('#ID_Hardware').on('select2:unselect', function (e) {
//    $('#IdHardware').val(0)
//});

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
        F_Plazo: fplazo
    };

    console.log("Data", datos);

    $.ajax({
        type: "POST",
        url: '/Requerimiento/BtnEnviarDatos',

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
            F_Plazo: fplazo
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
