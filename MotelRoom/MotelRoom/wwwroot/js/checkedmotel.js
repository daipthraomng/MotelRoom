function UpdateStatusRent(statusRent, idRoom) {
    var url = '/' + "Home/UpdateStatusRent";
    //debugger;
    $.getJSON(url, { statusRent: statusRent, idRoom: idRoom }, function (data) {
        console.log(data);
        alert("Cập nhật trạng thái thành công");
        //debugger;
    });
}