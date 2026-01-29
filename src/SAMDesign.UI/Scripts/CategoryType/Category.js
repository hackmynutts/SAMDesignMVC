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

// Cargar lista de categorias en modal
$(document).on('click', '.CategoryList', function (e) {
    e.preventDefault();
    showLoadingSwal("Cargando lista de categorias...");
    $.ajax({
        url: '/Category/List',
        type: 'GET',
        success: function (html) {
            Swal.close();

            const $modal = $('#staticBackdropCategoryList');
            $modal.find('.modal-body').html(html);

            // Mostrar modal
            const modal = new bootstrap.Modal($modal[0]);
            modal.show();

            //datatable load
            if ($.fn.DataTable.isDataTable('#categoryTable')) {
                $('#categoryTable').DataTable().destroy();
            }
            $('#categoryTable').DataTable({ responsive: true, autoWidth: false });

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

// UNA sola vez
$('#staticBackdropAddModal').on('shown.bs.modal', function () {
    $('.modal-backdrop').last().addClass('backdrop-add');
});

$('#staticBackdropAddModal').on('hidden.bs.modal', function () {
    $('.modal-backdrop.backdrop-add').removeClass('backdrop-add');
});


// Add modal category load
$(document).on('click', '.AddCategory', function (e) {
    e.preventDefault();
    showLoadingSwal("Cargando formulario de categoria...");

    $.ajax({
        url: '/Category/Create',
        type: 'GET',
        success: function (html) {
            Swal.close();
            const $modal = $('#staticBackdropAddModal');
            $modal.find('.modal-body').html(html);
            // Mostrar modal
            const modal = new bootstrap.Modal($modal[0]);
            modal.show();
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "No podemos cargar el formulario de categoria!",
                icon: "error"
            }).then(() => location.reload());
        }
    });
});

// Reload list
function reloadCategoryList() {
    return $.ajax({
        url: '/Category/List',
        type: 'GET',
        success: function (html) {
            const $listModal = $('#staticBackdropCategoryList');
            $listModal.find('.modal-body').html(html);

            if ($.fn.DataTable.isDataTable('#categoryTable')) {
                $('#categoryTable').DataTable().destroy();
            }
            $('#categoryTable').DataTable({
                responsive: true,
                autoWidth: false
            });
        }
    });
}

// submit create form 
$(document).on('click', '.submitCategory', function (e) {
    e.preventDefault();
    const $addModal = $('#staticBackdropAddModal');
    const $form = $addModal.find('form');
        $.ajax({
            url: '/Category/Create',
            type: 'POST',
            data: $form.serialize(),
            dataType: 'json',
            success: async function(data) {
                Swal.close();
                if (data.success && data.rows > 0) {
                    Swal.fire({
                        title: "Excelente!",
                        text: "Categoría creada exitosamente!",
                        icon: "success"
                    }).then(async () => {
                        //cerrar modal Crear
                        bootstrap.Modal.getInstance($addModal[0]).hide();
                        // recargar lista sin refresh
                        await reloadCategoryList();
                    });
                } else {
                    Swal.fire({
                        title: "Oops!",
                        text: data.message || "No se pudo crear la categoría.",
                        icon: "warning"
                    });
                }
            },
            error: function () {
                Swal.fire({
                    title: "Oops!",
                    text: "No podemos crear la categoria!",
                    icon: "error"
                }).then(() => {
                    location.reload();
                });
            }
        });
    });

// Edit modal category load
$(document).on('click', '.EditCategory', function (e) {
    e.preventDefault();
    showLoadingSwal("Cargando formulario de categoria...");

    const id = $(this).data('id');
    const url = `/Category/Edit/${id}`;

    $.ajax({
        url: url,
        type: 'GET',
        success: function (html) {
            Swal.close();
            const $modal = $('#staticBackdropEditModal');
            $modal.find('.modal-body').html(html);
            // Mostrar modal
            const modal = new bootstrap.Modal($modal[0]);
            modal.show();
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "No podemos cargar el formulario de categoria!",
                icon: "error"
            }).then(() => location.reload());
        }
    });
});

// submit edit form 
$(document).on('click', '.submitEditCategory', function (e) {
    e.preventDefault();
    const $addModal = $('#staticBackdropEditModal');
    const $form = $addModal.find('form');
    $.ajax({
        url: '/Category/Edit',
        type: 'POST',
        data: $form.serialize(),
        dataType: 'json',
        success: async function (data) {
            Swal.close();
            if (data.success && data.rows > 0) {
                Swal.fire({
                    title: "Excelente!",
                    text: "Categoría editada exitosamente!",
                    icon: "success"
                }).then(async () => {
                    //cerrar modal Crear
                    bootstrap.Modal.getInstance($addModal[0]).hide();
                    // recargar lista sin refresh
                    await reloadCategoryList();
                });
            } else {
                Swal.fire({
                    title: "Oops!",
                    text: data.message || "No se pudo editar la categoría.",
                    icon: "warning"
                });
            }
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "No podemos editar la categoria!",
                icon: "error"
            }).then(() => {
                location.reload();
            });
        }
    });
});

// Delete category
$(document).on('click', '.DeleteCategory', function (e) {
    e.preventDefault();

    const id = $(this).data('id');
    const url = `/Category/Delete/${id}`;

    Swal.fire({
        title: "¿Estás seguro?",
        text: "La categoría será eliminada.",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#d33",
        cancelButtonColor: "#3085d6",
        confirmButtonText: "Sí, ELIMINAR",
        cancelButtonText: "Cancelar"
    }).then((result) => {

        if (result.isConfirmed) {

            showLoadingSwal("Inactivando categoría...");

            $.ajax({
                url: url,
                type: "POST",
                dataType: "json",
                success: async function (data) {
                    Swal.close();
                    if (data.success) {
                        Swal.fire({
                            title: "Listo!",
                            text: "Categoría inactivada correctamente.",
                            icon: "success"
                        });
                        await reloadCategoryList();

                    } else {
                        Swal.fire("Oops!", data.message || "No se pudo inactivar.", "error");
                    }
                },
                error: function (xhr) {
                    console.log(xhr.status);
                    console.log(xhr.responseText);
                    Swal.fire("Error", "Error en el servidor.", "error");
                }
            });
        }
    });
});
