"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

    var div = document.createElement("div");
    var strong = document.createElement("strong");
    strong.textContent = user;
    div.appendChild(strong);

    var p = document.createElement("p");
    p.style.fontSize = "14px";
    p.textContent = msg;

    var messageContainer = document.createElement("div");
    messageContainer.classList.add("border-bottom");

    messageContainer.appendChild(div);
    messageContainer.appendChild(p);

    //var encodedMsg = user + " says " + msg;

    document.getElementById("messagesList").appendChild(messageContainer);
    document.getElementById("messageInput").value = "";
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", "Do Quang Anh", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});