const io= require("socket.io-client");
const socket = io("http://localhost:3000");

var uuid="7ccb0dbc-d6eb-49d5-acc5-0a8e8edf0562";
socket.emit("connection", (socket) => {
    console.log("Connected to socket.io");
    socket.emit("setup", (userData) => {
      socket.join(userData._id);
      socket.on("connected","data");
    })});