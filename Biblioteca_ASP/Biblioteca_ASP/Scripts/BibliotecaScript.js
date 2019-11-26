
function load(UrlDirection) {   
    $(function () {
        var url = UrlDirection;
        $.post(url).done(function (data) {
            $("#CargarIndex").empty();
            $("#CargarIndex").append(data);
        }).fail(function (s1, s2, error) {
            if (s1.status === 0) {
                alert('No coneccion: Verificar la Network');
            }
            if (s1.status === 404) {
                alert('Requested page not found [404]');
            }
        });
    });
}