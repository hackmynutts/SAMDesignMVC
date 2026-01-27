//$(function () {
//    const table = $('#categoryTable').DataTable({
//        responsive: true,
//        autoWidth: false
//    });
//});

function showLoadingSwal(message = "Cargando...") {
    Swal.fire({
        title: message,
        allowOutsideClick: false,
        allowEscapeKey: false,
        didOpen: () => {
            Swal.showLoading();
        }
    });
}

$(document).on('click', '.CategoryList', function (e) {
    e.preventDefault();
    showLoadingSwal("Cargando lista de categorias...");
    $.ajax({
        url: '/Category/List',
        type: 'GET',
        success: function (html) {
            Swal.close();

            const $modal = $('#staticBackdropCategory');
            $modal.find('.modal-body').html(html);

            // Mostrar modal
            const modal = new bootstrap.Modal($modal[0]);
            modal.show();

            //datatable load
            const table = $('#categoryTable').DataTable({
                responsive: true,
                autoWidth: false
            });
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "No podemos cargar la lista de categorias!",
                icon: "error"
            }).then(() => location.reload());
        }
    });
});