// configuring environment variables from .env file
require("dotenv").config();

// express setup
const express = require("express");
const app = express();
app.use(express.json());

// cors setup
const cors = require("cors");
const corsOptions = {
  origin: [process.env.CLIENT_URL],
  methods: ["GET", "POST"],
  credentials: true,
};
app.use(cors(corsOptions));

// socket.io setup
const http = require("http");
const server = http.createServer(app);
const socketio = require("socket.io");
const io = socketio(server, { cors: corsOptions });

// data structures to store users and rooms
let roomsUsers = { room_id: ["user_id"] }; // object of arrays {"rommid": [user1, user2, user3]}
let userRoom = {};

// socket.io connection handler
io.on("connection", (socket) => {
  console.log("new user connected with socket: ", socket.id);
  socket.on("join-room", (roomId) => {
    if (roomsUsers[roomId] === null || !roomsUsers[roomId]) {
      roomsUsers[roomId] = [socket.id];
      userRoom[socket.id] = roomId;
      return;
    }
    console.log(roomsUsers);
    let otherUsers = [...roomsUsers[roomId]];
    if (otherUsers && otherUsers.length >= 8) {
      socket.emit("room-is-full");
      return;
    }
    socket.emit("other-users", otherUsers);
    otherUsers.push(socket.id); // persist user into database
    roomsUsers = { ...roomsUsers, [roomId]: otherUsers };
    userRoom[socket.id] = roomId;
  });
  socket.on("offer", (sessionDescription) => {
    // sessionDescription = {target: socket.id, offer: offer}
    io.to(sessionDescription.target).emit(
      "receiving-offer",
      sessionDescription
    );
  });
  socket.on("answer", (sessionDescription) => {
    // sessionDescription = {target: socket.id, answer: answer}
    io.to(sessionDescription.callerId).emit("receiving-answer", {
      signal: sessionDescription.signal,
      id: socket.id,
    });
  });

  //   socket.on("candidate", (candidate) => {
  //     io.to(candidate.target).emit("receiving-candidate", candidate);
  //   });

  socket.on("disconnect", () => {
    // console.log("user disconnected with socket: ", socket.id);
    let roomId = userRoom[socket.id];
    let room = [...roomsUsers[roomId]];
    room = room.filter((id) => id !== socket.id);
    roomsUsers[roomId] = room;
    userRoom[socket.id] = null;
  });
});

port = process.env.PORT || 5000;
server.listen(port, () => console.log(`server is running on port: ${port}`));
