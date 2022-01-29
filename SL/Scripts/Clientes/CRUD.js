function Add() {

    var subcategoria = {
        IdCliente: 1,
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val()
    }
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5914/api/Cliente',
        dataType: 'json',
        data: subcategoria,
        success: function (result) {
            //$('#myModal').modal();
            alert('Agregado Exitosamente');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};


function GetById(IdSubCategoria) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:14982/api/SubCategoria/GetById/' + IdSubCategoria,
        success: function (result) {
            $('#txtIdSubCategoria').val(result.Object.IdSubCategoria);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtDescripcion').val(result.Object.Descripcion);
            $('#txtIdCategoria').val(result.Object.Categoria.IdCategoria);
            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }


    });

}


function Update() {

    var subcategoria = {
        IdSubCategoria: $('#txtIdSubCategoria').val(),
        Nombre: $('#txtNombre').val(),
        Descripcion: $('#txtDescripcion').val(),
        IdCategoria: {
            IdCategoria: $('#txtIdCategoria').val()
        }
    }

    $.ajax({
        type: 'POST',
        url: 'http://localhost:14982/api/SubCategoria/Update',
        datatype: 'json',
        data: subcategoria,
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
            Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};



function Eliminar(IdSubCategoria) {

    if (confirm("¿Estas seguro de eliminar la SubCategoria seleccionada?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:14982/api/SubCategoria/Delete/' + IdSubCategoria,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};