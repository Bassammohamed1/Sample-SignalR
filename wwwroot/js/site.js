var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();


connection.on("ReceiveMessage", function (from, message) {
    var msg = from + ": " + message;
    var li = document.createElement("li");
    li.textContent = msg;
    $("#list").append(li);

});


connection.start();

$("#btnSend").on("click", function () {
    var from = $("#txtUser").val();
    var message = $("#txtMessage").val();

    connection.invoke("sendMessage", from, message);
});