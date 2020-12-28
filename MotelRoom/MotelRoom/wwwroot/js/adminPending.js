function AcceptPost(idRoom, idOwner, contentNotification) {
    var url = '/' + "Home/AcceptPost";
    debugger;
    $.getJSON(url, { idRoom: idRoom }, function (data) {
        console.log(data);
        sendNotification(contentNotification, idOwner);
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
function sendNotification(contentNotification, idOwner) {
    var url = '/' + "Home/SendNotificationToOwner";
    //debugger;
    $.getJSON(url, { contentNotification: contentNotification, idOwner: idOwner }, function (data) {
        console.log(data);
        //debugger;
    });
}