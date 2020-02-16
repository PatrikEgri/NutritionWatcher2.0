$(document).ready(function () {
    var tabla = $("#tablazat").DataTable({
        ajax: {
            url: "/api/Consumption/GetConsumptions",
            dataSrc: ""
        },
        columns: [
            {
                data: "date",
            },
            {
                data: "time",
            },
            {
                data: "id",
                render: function (data) {
                    return "<a href='/Consumption/Assignments/" + data + "'><i class='fas fa-external-link-alt'></i></a>";
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<a href='/Consumption/EditConsumption/" + data + "'><i class='fas fa-edit'></i></a>";
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<i class='far fa-trash-alt js-torles' data-consumption-id=" + data + "></i>";
                }
            }
        ]
    });

    $("#tablazat").on("click", ".js-torles", function () {
        var gomb = $(this);
        bootbox.confirm(
            "Biztosan törölni akarod ezt a fogyasztást?",
            function (valasz) {
                if (valasz) {
                    $.ajax({
                        url: "/api/Consumption/DeleteConsumption/" + gomb.attr("data-consumption-id"),
                        method: "DELETE",
                        success: function () {
                            tabla.row(gomb.parents("tr")).remove().draw();
                        }
                    });
                }
            });
    });
});