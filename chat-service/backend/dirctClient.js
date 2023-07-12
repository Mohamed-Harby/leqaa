const io = require("socket.io-client");
const ENDPOINT = "http://localhost:6969";
let socket, selectedChatCompare, currentUserObj;

socket = io(ENDPOINT); // this will connect to the server
socket.emit("setup", currentUserObj); // this will send the user data object to the server

socket.emit("join chat", selectedChat._id); // this will join the chat room

// ------------------------------------------------------------------------------------------
