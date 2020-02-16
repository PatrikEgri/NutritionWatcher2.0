var tabButtons = document.querySelectorAll(".tabContainer .buttonContainer button");
var tabPanels = document.querySelectorAll(".tabContainer .tabPanel");

function showPanel(panelIndex) {
    tabButtons.forEach(function (node) {
        node.style.backgroundColor = "#353535";
    });
    tabButtons[panelIndex].style.backgroundColor = "#181818";
    tabPanels.forEach(function (node) {
        node.style.display = "none";
    });
    tabPanels[panelIndex].style.display = "block";
}

showPanel(0);

$(document).ready(function () {
    var tabla = $("#tablazat").DataTable({
        ajax: {
            url: "/api/Food/GetSystemFoods",
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
            }
        ]
    });
});

$(document).ready(function () {
    var tabla = $("#tablazat2").DataTable({
        ajax: {
            url: "/api/Food/GetUsersFoods",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, food) {
                    return "<a href='/Food/ViewFood/" + food.id + "'>" + food.name + "</a>";
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
                    return "<a href='/Food/EditFood/" + data + "'><i class='fas fa-edit'></i></a>";
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<i class='far fa-trash-alt js-torles' data-food-id=" + data + "></i>";
                }
            }
        ]
    });

    $("#tablazat2").on("click", ".js-torles", function () {
        var gomb = $(this);
        bootbox.confirm(
            "Biztosan törölni akarod ezt az ételt?",
            function (valasz) {
                if (valasz) {
                    $.ajax({
                        url: "/api/Food/DeleteFood/" + gomb.attr("data-food-id"),
                        method: "DELETE",
                        success: function () {
                            tabla.row(gomb.parents("tr")).remove().draw();
                        }
                    });
                }
            });
    });
});

$(document).ready(function () {
    var tabla = $("#tablazat3").DataTable({
        ajax: {
            url: "/api/Food/GetOtherUsersFoods",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, food) {
                    return "<a href='/Food/ViewFood/" + food.id + "'>" + food.name + "</a>";
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
            }
        ]
    });
});