function deleteOwner(idOwnerDelete) {
    var url = '/' + "Home/DeleteUser";
    debugger;
    $.getJSON(url, { idOwner: idOwnerDelete }, function (data) {
        console.log(data);
        location.reload();
        debugger;
    });
}
function acceptOwner(idOwnerAccept) {
    var url = '/' + "Home/AcceptUser";
    debugger;
    $.getJSON(url, { idOwner: idOwnerAccept }, function (data) {
        console.log(data);
        location.reload();
        debugger;
    });
}