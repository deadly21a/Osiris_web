$(document).ready(function () {
    
});

$('.kanban-card').click(function () {
    var card = $(this);
    var id = card.data('id');
    

    $.ajax({
        type: 'GET',
        url: "/Kanban/Kanban1",
        data: {
            id: 5013
        },
        dataType: 'html'
    }).done(function (response) {
       

        $('.table-Kanban').html(response);
        $('#DetKanban').modal('show');


    }).fail(function () {
        alert("Error al cargar los datos");
    });

});

