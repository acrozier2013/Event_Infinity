function searchFailed() {
    $("#searchresults").html("Hmmm... looks like there was a problem with your search");
}

$(function () {
    $(".RemoveLink").click(function () {
        var id = $(this).attr("data-id");
        $.post("/Order/RemoveFromCart", { "id": id }, function (data) {
            $("#update-message").text(data.Message);
            $("#item-count-" + data.DeleteId).text(data.ItemCount);

            if (data.ItemCount < 1) {
                $("#record-" + data.DeleteId).fadeOut();
            }
        });
    })
});