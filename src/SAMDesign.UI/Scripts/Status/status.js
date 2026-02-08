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

// Reload list
function reloadStatusList() {
    return $.ajax({
        url: '/Status/List',
        type: 'GET',
        success: function (html) {
            const $listModal = $('#staticBackdropStatusList');
            $listModal.find('.modal-body').html(html);

            if ($.fn.DataTable.isDataTable('#statusTable')) {
                $('#statusTable').DataTable().destroy();
            }
            $('#statusTable').DataTable({
                responsive: true,
                autoWidth: false
            });
        }
    });
}

// UNA sola vez
$('#staticBackdropStatusAddModal').on('shown.bs.modal', function () {
    $('.modal-backdrop').last().addClass('backdrop-add');
});

$('#staticBackdropStatusAddModal').on('hidden.bs.modal', function () {
    $('.modal-backdrop.backdrop-add').removeClass('backdrop-add');
});

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

// Add modal status load
$(document).on('click', '.AddStatus', function (e) {
    e.preventDefault();
    showLoadingSwal("Cargando formulario de estado...");

    $.ajax({
        url: '/Status/Create',
        type: 'GET',
        success: function (html) {
            Swal.close();
            const $modal = $('#staticBackdropStatusAddModal');
            $modal.find('.modal-body').html(html);
            // Mostrar modal
            const modal = new bootstrap.Modal($modal[0]);
            modal.show();
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "No podemos cargar el formulario de estados!",
                icon: "error"
            }).then(() => location.reload());
        }
    });
});

// submit add form 
$(document).on('click', '.submitAddStatus', function (e) {
    e.preventDefault();
    const $addModal = $('#staticBackdropStatusAddModal');
    const $form = $addModal.find('form');
    $.ajax({
        url: '/Status/Create',
        type: 'POST',
        data: $form.serialize(),
        dataType: 'json',
        success: async function (data) {
            Swal.close();
            if (data.success && data.rows > 0) {
                Swal.fire({
                    title: "Excelente!",
                    text: "Estado creado exitosamente!",
                    icon: "success"
                }).then(async () => {
                    //cerrar modal Crear
                    bootstrap.Modal.getInstance($addModal[0]).hide();
                    // recargar lista sin refresh
                    await reloadStatusList();
                });
            } else {
                Swal.fire({
                    title: "Oops!",
                    text: data.message || "No se pudo crear el estado.",
                    icon: "warning"
                });
            }
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "No podemos crear el estado!",
                icon: "error"
            }).then(() => {
                location.reload();
            });
        }
    });
});

// Edit modal status load
$(document).on('click', '.EditStatus', function (e) {
    e.preventDefault();
    showLoadingSwal("Cargando formulario de estado...");

    const id = $(this).data('id');
    const url = `/Status/Edit/${id}`;

    $.ajax({
        url: url,
        type: 'GET',
        success: function (html) {
            Swal.close();
            const $modal = $('#staticBackdropStatusEditModal');
            $modal.find('.modal-body').html(html);
            // Mostrar modal
            const modal = new bootstrap.Modal($modal[0]);
            modal.show();
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "No podemos cargar el formulario de estados!",
                icon: "error"
            }).then(() => location.reload());
        }
    });
});

// submit edit form 
$(document).on('click', '.submitEditStatus', function (e) {
    e.preventDefault();
    const $addModal = $('#staticBackdropStatusEditModal');
    const $form = $addModal.find('form');
    $.ajax({
        url: '/Status/Edit',
        type: 'POST',
        data: $form.serialize(),
        dataType: 'json',
        success: async function (data) {
            Swal.close();
            if (data.success && data.rows > 0) {
                Swal.fire({
                    title: "Excelente!",
                    text: "Estado editado exitosamente!",
                    icon: "success"
                }).then(async () => {
                    //cerrar modal Crear
                    bootstrap.Modal.getInstance($addModal[0]).hide();
                    // recargar lista sin refresh
                    await reloadStatusList();
                });
            } else {
                Swal.fire({
                    title: "Oops!",
                    text: data.message || "No se pudo editar el estado.",
                    icon: "warning"
                });
            }
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "No podemos editar el estado!",
                icon: "error"
            }).then(() => {
                location.reload();
            });
        }
    });
});