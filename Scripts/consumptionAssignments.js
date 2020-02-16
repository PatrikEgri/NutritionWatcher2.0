$(document).ready(function () {
    var tabla = $("#tablazat");
    $("#tablazat").on("click", ".js-torles", function () {
        var gomb = $(this);
        bootbox.confirm("Biztosan törölni akarod ezt az ételt a fogyasztásból?",
            function (valasz) {
                if (valasz) {
                    $.ajax({
                        url: "/api/Consumption/DeleteAssignment/" + gomb.attr("data-assignment-id"),
                        method: "DELETE",
                        success: function () {
                            gomb.closest("tr").remove();                            
                        }
                    });
                }
            });
    });
});