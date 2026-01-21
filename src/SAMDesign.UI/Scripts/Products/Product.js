$(function () {
    const table = $('#productTable').DataTable({
        responsive: true,
        autoWidth: false,
        columnDefs: [
            { responsivePriority: 1, targets: 1 }, // ProductName
            { responsivePriority: 2, targets: 4 }, // UnitPrice
            { responsivePriority: 3, targets: 6 }, // statusID
            { targets: [7, 8, 9, 10], visible: false }
        ]
    });
});

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

//add offcanvas load
$(document).on('click', '.AddProduct', function () {

    showLoadingSwal("Cargando formulario...");

    $.ajax({
        url: 'Create',
        type: 'GET',
        success: function (data) {
            Swal.close();
            $('#offcanvasRightAddProduct .offcanvas-body').html(data);
            let offcanvas = bootstrap.Offcanvas.getOrCreateInstance(
                document.getElementById('offcanvasRightAddProduct')
            );
            offcanvas.show();
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "No podemos cargar el offcanvas!",
                icon: "error"
            }).then(() => location.reload());
        }
    });
});

// submit create form (con archivo)
$(document).on('submit', '#createProductForm', function (e) {
    e.preventDefault();

    const form = this;
    const formData = new FormData(form);

    showLoadingSwal("Creando producto...");

    $.ajax({
        url: $(form).attr('action') || 'Create',
        type: 'POST',
        data: formData,
        processData: false, // IMPORTANT: no convertir a querystring
        contentType: false, // IMPORTANT: dejar multipart/form-data
        success: function (data) {
            Swal.close();
            // Si tu POST retorna JSON cuando todo OK:
            if (data && data.success) {
                Swal.fire({
                    title: "¡Éxito!",
                    text: "¡El producto se ha creado exitosamente!",
                    icon: "success"
                }).then(() => location.reload());
            } else {
                // Si retorna la vista con validaciones (HTML)
                $('#offcanvasRightAddProduct .offcanvas-body').html(data);
            }
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "¡No se pudo crear el producto!",
                icon: "error"
            });
        }
    });
});

// Preview de imagen para el offcanvas (funciona con contenido cargado por AJAX)
$(document).on('change', '#ImageFile', function () {
    const input = this;

    if (!input.files || input.files.length === 0) return;

    const file = input.files[0];

    // Opcional: validar que sea imagen
    if (!file.type.startsWith('image/')) {
        Swal.fire('Archivo inválido', 'Selecciona una imagen.', 'warning');
        input.value = '';
        return;
    }

    const reader = new FileReader();
    reader.onload = function (e) {
        $('#preview-image')
            .attr('src', e.target.result)
            .show();
    };

    reader.readAsDataURL(file);
});

//edit offcanvas load
$(document).on('click', '.EditProduct', function (e) {
    e.preventDefault(); // IMPORTANT: evita navegar a la página Edit
    showLoadingSwal("Cargando formulario...");

    const url = $(this).attr('href');

    $.ajax({
        url: url,
        type: 'GET',
        success: function (data) {
            Swal.close();
            $('#offcanvasRightEditProduct .offcanvas-body').html(data);
            let offcanvas = bootstrap.Offcanvas.getOrCreateInstance(
                document.getElementById('offcanvasRightEditProduct')
            );
            offcanvas.show();
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "No podemos cargar el offcanvas!",
                icon: "error"
            }).then(() => location.reload());
        }
    });
});

$(document).on('submit', '#editProductForm', function (e) {
    e.preventDefault();

    const form = this;
    const formData = new FormData(form);

    showLoadingSwal("Actualizando producto...");

    $.ajax({
        url: $(form).attr('action'),   // /Products/Edit
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            Swal.close();

            if (data && data.success) {
                Swal.fire({
                    title: "¡Éxito!",
                    text: "¡El producto ha sido actualizado exitosamente!",
                    icon: "success"
                }).then(() => location.reload());
            } else {
                // si devuelve HTML con validaciones
                $('#offcanvasRightEditProduct .offcanvas-body').html(data);
            }
        },
        error: function (xhr) {
            Swal.close();
            Swal.fire({
                title: "Oops!",
                text: "¡No se pudo actualizar el producto!",
                icon: "error"
            });
            console.log("Edit POST error:", xhr.status, xhr.responseText);
        }
    });
});

