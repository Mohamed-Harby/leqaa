const io = require("socket.io-client");
const socket = io("http://localhost:6969");

var uuid = "7ccb0dbc-d6eb-49d5-acc5-0a8e8edf0562";
socket.on("connect", (io) => {
  console.log("Connected to the server");

  var user1 = { _id: 1 };
  var user2 = { _id: 2 };
  var user3 = { _id: 3 };

  socket.emit("setup", user1);
  socket.emit("setup", user2);
  socket.emit("setup", user3);
  socket.emit("join chat", user1._id.toString());
  socket.emit("join chat", user2._id.toString());
  socket.emit("join chat", user3._id.toString());

  let message = {
    chat: { users: [user1._id, user2._id, user3._id] },
    sender: user2._id,
    content: "hello",
  };

  socket.emit("new message", message);
});

socket.on("message received", (newMessage) => {
  console.log(newMessage);
});
