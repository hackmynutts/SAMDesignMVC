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

//submit create form
$(document).on('click', '#submitAddProduct', function (e) {
    e.preventDefault();
    const $form = $('#offcanvasRightAddProduct').find('form');
    $.ajax({
        url: 'Create',
        type: 'POST',
        data: $form.serialize(),
        success: function (data) {
            if (data.success) {
                Swal.fire({
                    title: "¡Éxito!",
                    text: "¡El producto se ha sido creado exitosamente!",
                    icon: "success"
                }).then(() => location.reload());
            } else {
                $('#offcanvasRightAddProduct .offcanvas-body').html(data);
            }
        },
        error: function () {
            Swal.fire({
                title: "Oops!",
                text: "¡No se pudo crear el producto!",
                icon: "error"
            }).then(() => location.reload());
        }
    });
});