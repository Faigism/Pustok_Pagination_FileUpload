$(document).on("click", ".modal-btn", function (e) {
    e.preventDefault();
    let url = $(this).attr("href");
    fetch(url).then(response => response.text())
        .then(data => {
            $("#quickModal .modal-dialog").html(data)
        })

    $("#quickModal").modal("show")
});