function Formulario() {
    if ($('#txtIdEmpleado').val() == "") {
        var empleado = {
            NumeroNomina: $('#txtNumeroNomina').val(),
            Nombre: $('#txtNombre').val(),
            ApellidoPaterno: $('#txtApellidoPaterno').val(),
            ApellidoMaterno: $('#txtApellidoMaterno').val(),
            Estado: {
                IdEstado: $('#ddlIdEstado').val()
            }
        }
        $.ajax({
            type: 'POST',
            url: 'http://localhost:1742/api/Empleado/',
            dataType: 'json',
            data: empleado,
            success: function (result) {
                $('#myModalAdd').modal();
                $('#Modal').modal('hide');
                GetAll();
                Console(respond);
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });
    }
    else {
        var IdEmpleado = $('#txtIdEmpleado').val()

        var empleado = {
            NumeroNomina: $('#txtNumeroNomina').val(),
            Nombre: $('#txtNombre').val(),
            ApellidoPaterno: $('#txtApellidoPaterno').val(),
            ApellidoMaterno: $('#txtApellidoMaterno').val(),
            Estado: {
                IdEstado: $('#ddlIdEstado').val()
            }
        }

        $.ajax({
            type: 'POST',
            url: 'http://localhost:1742/api/Empleado/' + IdEmpleado,
            datatype: 'json',
            data: empleado,
            success: function (result) {
                $('#myModalUpdate').modal();
                $('#Modal').modal('hide');
                GetAll();
                Console(respond);
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });
    }
}
function Delete(IdEmpleado) {

    if (confirm("¿Estas seguro de eliminar a este empleado?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:1742/api/Empleado/Delete/' + IdEmpleado,
            success: function (result) {
                $('#myModalEliminar').modal();
                GetList();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};
