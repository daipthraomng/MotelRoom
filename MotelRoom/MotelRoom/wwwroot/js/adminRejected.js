function AcceptPost(idRoom) {
    var url = '/' + "Home/AcceptPost";
    debugger;
    $.getJSON(url, { idRoom: idRoom }, function (data) {
        console.log(data);
        alert("Khôi phục thành công");
        debugger;
    });
}