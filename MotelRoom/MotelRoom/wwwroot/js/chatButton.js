function openForm() {
    document.getElementById("myForm").style.display = "block";
}

function closeForm() {
    document.getElementById("myForm").style.display = "none";
}
function sendMessage() {
    var contentMes = document.getElementById("messageInput").value;
    var url = '/' + "Home/SendMessage";
    //debugger;
    $.getJSON(url, { contentMessage: contentMes }, function (data) {
        console.log(data);
        //debugger;
    });
}