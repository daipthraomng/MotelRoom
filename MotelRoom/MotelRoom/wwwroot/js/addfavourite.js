function hitFavoriteIcon(x) {
    if (x.style.color == "red") {
        x.style.color = "black";
    } else {
        x.style.color = "red";
        alert("Thêm vào danh sách yêu thích thành công");
    }
}