function AcceptPost(idRoom) {
    var url = '/' + "Home/AcceptPost";
    debugger;
    $.getJSON(url, { idRoom: idRoom }, function (data) {
        console.log(data);
        alert("Phê duyệt thành công");
        debugger;
    });
}
function DenyPost(idRoom) {
    var url = '/' + "Home/DenyPost";
    debugger;
    $.getJSON(url, { idRoom: idRoom }, function (data) {
        console.log(data);
        alert("Từ chối bài viết thành công");
        debugger;
    });
}