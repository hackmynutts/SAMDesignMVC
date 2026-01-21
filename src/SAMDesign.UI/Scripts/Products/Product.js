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

//add offcanvas load
$(document).on('click', '.AddProduct', function () {
    $.ajax({
        url: 'Create',
        type: 'GET',
        success: function (data) {
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

    $.ajax({
        url: $(form).attr('action') || 'Create',
        type: 'POST',
        data: formData,
        processData: false, // IMPORTANT: no convertir a querystring
        contentType: false, // IMPORTANT: dejar multipart/form-data
        success: function (data) {
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
