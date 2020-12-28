function AddTimeEnd(idRoom) {
    var endTime = document.getElementById("endTime").value;
    var url = '/' + "Home/AddTimeEnd";
    debugger;
    $.getJSON(url, { endTime: endTime, idRoom: idRoom }, function (data) {
        console.log(data);
        alert("Gia hạn thành công");
        location.reload();
        debugger;
    });
}