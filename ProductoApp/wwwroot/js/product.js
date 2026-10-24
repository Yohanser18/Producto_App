function showConfirmAcctionEdit(e, id) {
    e.preventDefault();
    Swal.fire({
        title: '¿Está seguro de que desea borrar el registro?',
        icon: 'question', 
        showCancelButton: true,
        confirmButtonText: 'Yes',

    }).then((resultado) => {
        if (resultado.isConfirmed) {
            window.location.href = `/Product/EditProducto/${id}`;
        }
    })
}

function showConfirmAcctionDelete(e, id) {
    e.preventDefault();
    Swal.fire({
        title: '¿Está seguro de que desea borrar el registro?',
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Yes',
    }).then((resultado) => {
        if (resultado.isConfirmed) {
            window.location.href = `/Product/DeleteProduct/${id}`;
        }
    })
}