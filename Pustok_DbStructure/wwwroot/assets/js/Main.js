$(document).on("click", ".basket-add-btn", function (e) {
    e.preventDefault();
    let url = $(this).attr("href")
    fetch(url).then(response => {
        if (!response.ok) {
            alert("Error!!")
        }
        else {
            return response.text()
        }
    }).then(data => {
        $("#basketCart").html(data)
    })
})

$(document).on("click", ".cross-btn", function (e) {
    e.preventDefault();
    let url = $(this).getAttribute("href")
    fetch(url).then(response => response.text()
    ).then(data => {
        $(".cart-dropdown-block").html(data)
    })
})