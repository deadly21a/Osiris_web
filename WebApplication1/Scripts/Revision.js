
    document.addEventListener('DOMContentLoaded', function () {
        // Función para obtener la fecha y hora actual en el formato adecuado
        function getCurrentDateTime() {
            return moment().format('YYYY-MM-DDTHH:mm');
        }

            // Configuración inicial de la fecha de ingreso
            document.getElementById('fechaIngreso').value = getCurrentDateTime();

    // Evento clic del botón "Buscar"
    $("#btnBuscar").on("click", function () {
                // Obtén la ID ingresada
                var idBusqueda = $("#idBusqueda").val();

    // Realiza una solicitud AJAX para obtener los datos asociados a la ID
    $.ajax({
        type: "GET",
    url: "/Controlador/ObtenerDatosPorId", // Reemplaza con la ruta y acción correctas
    data: {id: idBusqueda },
    dataType: "json",
    success: function (response) {
        // Llena los campos con los datos obtenidos
        $("#id").val(response.Id);
    $("#inputStatus").val(response.Estado);
                        // Llena los demás campos según sea necesario
                    },
    error: function (error) {
        console.error(error);
                    }
                });
            });
        });
