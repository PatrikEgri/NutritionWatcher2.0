let list = document.getElementById("lista");
let numberInput = document.getElementById("gramm");

$(document).ready(function () {
    var tabla = $("#tablazat").DataTable({
        ajax: {
            url: "/api/Food/GetFoods",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data) {
                    return data;
                }
            },
            {
                data: "proteinAmount",
                render: function (data) {
                    return data + " gr.";
                }
            },
            {
                data: "fatAmount",
                render: function (data) {
                    return data + " gr.";
                }
            },
            {
                data: "hydrocarbonateAmount",
                render: function (data) {
                    return data + " gr.";
                }
            },
            {
                data: "gramm",
                render: function (data) {
                    return data + " gr.";
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<i class='fas fa-plus js-assign' data-food-id=" + data + "></i>";
                }
            }
        ]
    });

    $("#tablazat").on("click", ".js-assign", function () {
        var gomb = $(this);
        $.ajax({
            url: "/api/Consumption/CreateAssign/" + gomb.attr("data-food-id") + "/" + list.value + "/" + numberInput.value,
            method: "POST",
            success: function () {
                alert("Sikeres hozzárendelés!");
            }
        });
    });
});