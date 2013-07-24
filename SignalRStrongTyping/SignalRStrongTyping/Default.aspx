<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="SignalRStrongTyping._Default" %>

<html>
    <head>
        <script src="http://code.jquery.com/jquery-1.8.2.min.js" type="text/javascript"></script>
        <script src="Scripts/jquery.signalR-1.1.2.min.js" type="text/javascript"></script>
        <!--  If this is an MVC project then use the following -->
        <!--  <script src="~/signalr/hubs" type="text/javascript"></script> -->
        <script src="signalr/hubs" type="text/javascript"></script>
        <script type="text/javascript">
        $(function () {
            // Proxy created on the fly          
            var chat = $.connection.exampleHub;

            // Declare a function on the chat hub so the server can invoke it          
            chat.client.printString = function (message) {
                $('#messages').append('<li>' + message + '</li>');
            };

            // Start the connection
            $.connection.hub.start().done(function () {
                console.log("signalr ready");
            });
        });
</script>
  
  <div>    
    <ul id="messages">
    </ul>
  </div>
</html>