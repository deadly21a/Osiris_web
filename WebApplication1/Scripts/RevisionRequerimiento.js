
    var table = $('#myTable').DataTable({
        "autoWidth": true,
        "scrollY": true,
        "scrollX": true,
        "responsive": true,
        "scrollCollapse": true,
        "paging": false,
        orderable: false,
    });


ConsultaDatos();


function ConsultaDatos() {

    $.ajax({
        type: "GET",
        url: '/Revision/Json',
    }).done(function (result) {
        var dataTable = result.ListaRequerimiento;

        if (dataTable != 0)
            CargaDatosTabla(dataTable) 



    }).fail(function (result) {
        alert('Error en la solicitud: ' + result);
    });

}


function CargaDatosTabla(dataTable) {

    $('#myTable').DataTable().destroy();

    $(document).ready(function () {
        $("#myTable").DataTable({
            "autoWidth": true,
            "scrollY": true,
            "scrollX": true,
            "responsive": true,
            "scrollCollapse": true,
            "paging": false,
            orderable: false,
            "data": dataTable,
            "columns": [
                { "data": "ID_ingreso_requerimiento", "name": "Id" },
                { "data": "Estado", "name": "Estado" },
                {
                    "data": "fecha_ingreso", "type": "Datetime", "name": "fecha Ingreso", "autowidth": true
                    , "render": function (data, type, row) {
                        var fecha_ingreso = "";
                        fecha_ingreso = moment(data).format('DD/MM/YYYY');

                        if (fecha_ingreso == "1899/12/31" || fecha_ingreso == "31/12/1899") {
                            return "   ";
                        } else {
                            return fecha_ingreso;
                        }
                        return fecha_ingreso;

                    }, orderable: false, "width": "5%"
                },
                { "data": "Solicitante", "name": "Solicitante" },
                { "data": "Aplicacion", "name": "Aplicacion" },
                { "data": "Hardware", "name": "Hardware" },
                { "data": "Prioridad", "name": "Prioridad" },
                { "data": "Proyecto", "name": "Proyecto" },
                { "data": "Tipo_requerimiento", "name": "Tipo Requerimiento" },
                { "data": "Requerimiento", "name": "Requerimiento" },
                { "data": "Opcion", "name": "Opcion" },
                { "data": "Comentario", "name": "Comentario" },
                {
                    "data": "F_Plazo", "type": "Datetime", "name": "Fecha Plazo", "autowidth": true
                    , "render": function (data, type, row) {
                        var F_Plazo = "";
                        F_Plazo = moment(data).format('DD/MM/YYYY');

                        if (F_Plazo == "1899/12/31" || F_Plazo == "31/12/1899") {
                            return "   ";
                        } else {
                            return F_Plazo;
                        }
                        return F_Plazo;

                    }, orderable: false, "width": "5%"
                },
                { "data": "Comentario_rev", "name": "Comentario Revision" },
                { "data": "Duracion_Hr", "name": "Duracion" },
                {
                    "data": "F_revision", "type": "Datetime", "name": "Fecha Revision", "autowidth": true
                    , "render": function (data, type, row) {
                        var F_revision = "";
                        F_revision = moment(data).format('DD/MM/YYYY');

                        if (F_revision == "1899/12/31" || F_revision == "31/12/1899") {
                            return "   ";
                        } else {
                            return F_revision;
                        }
                        return F_revision;

                    }, orderable: false, "width": "5%"
                },
                { "data": "UsuarioRevision", "name": "Usuario Revision" },
                {
                    "title": "", "width": "5%", "orderable": false
                    , "render": function (data, type, row) {
                        var sCad = '';
                        sCad = '<button type="button" class="btn btn-default btn-sm btnViewDoc" title="Ver referencia Documento"> ';
                        sCad = sCad + '<i class="fas fa-eye"></i>';
                        sCad = sCad + '</button>';
                        return sCad;
                    }
                }
            ]
        });
    });
   
}






