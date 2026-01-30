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

// Cargar lista de ESTATUS en modal
$(document).on('click', '.StatusList', function (e) {
    e.preventDefault();
    showLoadingSwal("Cargando lista de estatus..");
    $.ajax({
        url: '/Status/List',
        type: 'GET',
        success: function (html) {
            Swal.close();

            const $modal = $('#staticBackdropStatusList');
            $modal.find('.modal-body').html(html);

            // Mostrar modal
            const modal = new bootstrap.Modal($modal[0]);
            modal.show();

            //datatable load
            if ($.fn.DataTable.isDataTable('#statusTable')) {
                $('#statusTable').DataTable().destroy();
            }
            $('#statusTable').DataTable({ responsive: true, autoWidth: false });

        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "No podemos cargar la lista de status!",
                icon: "error"
            }).then(() => location.reload());
        }
    });
});