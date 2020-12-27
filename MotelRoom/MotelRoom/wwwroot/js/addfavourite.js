function hitFavoriteIcon(x, roomId) {
    if (x.style.color == "red") {
        x.style.color = "black";
    } else {
        x.style.color = "red";
    }
    var content = JSON.stringify(roomId); // chuyen doi tuong sang json
    //debugger;
    $.ajax({
        url: "/Home/PostInterest",
        method: "POST",
        data: content,
        contentType: "application/json",
        dataType: "json"
    }).done(function (res) {
        debugger;
        alert("Thêm vào danh sách yêu thích thành công");
    }).fail(function (res) {
        debugger;
        alert("Thêm vào danh sách yêu thích thành công");
    })
    alert("Thêm vào danh sách yêu thích thành công");
}
