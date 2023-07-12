const express = require("express");
const dotenv = require("dotenv");

const cors = require("cors");
// const { chats } = require("./data/data");
const connectDB = require("./config/db");
const colors = require("colors");
const userRoutes = require("./routes/userRoutes");
const chatRoutes = require("./routes/chatRoutes");
const messageRoutes = require("./routes/messageRoutes");
const Message = require("./models/messageModel");
const { notFound, errorHandler } = require("./middleware/errorMiddleware");
// const jwt = require("jsonwebtoken");

dotenv.config();
connectDB();
const app = express();

app.use(cors({ origin: "*", credentials: true }));
app.use(express.json()); //   to accept JSON data from frontend

// creating a simple API
app.get("/", (req, res) => {
  res.send("API is running !!");
});

app.use("/api/user", userRoutes);
app.use("/api/chat", chatRoutes);
app.use("/api/message", messageRoutes);

app.use(notFound);
app.use(errorHandler);

// // Handle uncaught exceptions
// process.on("uncaughtException", (error) => {
//   logger.error("Uncaught Exception:", error);
//   // process.exit(1); // Exit the process or take other necessary actions
// });

const MyController = require("./controllers/consumer");

// Initialize controller
const myController = Object.create(MyController);

// Start consuming messages from the queue
myController.startConsumingMessages();

// Other app initialization code...

const PORT = process.env.PORT || 6969;
const server = app.listen(
  PORT,
  console.log(`server is listening on port ${PORT}...`.yellow.bold)
);

const io = require("socket.io")(server, {
  pingTimeout: 60000, // pingTimeout means time will be waited if no connection happend it will be off to save bandwidth
  // cors: {
  //   origin: "*", // this will be changed during deployment
  //   // origin: "http://localhost:3000", // this will be changed during deployment
  //   // credentials: true,
  // },
});

io.on("connection", (socket) => {
  // when a connection is done from the client ==> from front end will log ' kaza' ,,,, socket = io(ENDPOINT);
  console.log("Connected to socket.io");
  socket.on("setup", (userData) => {
    if (!userData) {
      console.log("No user passed to socket.io");
      return;
    }
    // when a user create a new socket and send userData from fornt end ,,,,, the frontend should emit ====>  socket.emit("setup",user)  ,,, user is an object of the user data
    console.log("setup succeeded");
    socket.join(userData.id); // this will create a room for this particular user
    socket.emit("connected"); // this wil send connected to client
  });

  socket.on("join chat", (room) => {
    //will take room id from front end  ,, frontend ,,, socket.emit("join chat", selectedChat._id)
    socket.join(room);
    console.log("User Joined Room: " + room);
  });
  socket.on("typing", (room) => socket.in(room).emit("typing"));
  socket.on("stop typing", (room) => socket.in(room).emit("stop typing"));

  socket.on("new message", (newMessageRecieved) => {
    //to make a realtime messages
    var chat = newMessageRecieved.chat;
    console.log(chat);
    if (!chat.users) return console.log("chat.users not defined");

    chat.users.forEach((user) => {
      console.log(user);
      // if (user._id == newMessageRecieved.sender._id) return; //if user is the sender of the message return nothing
      io.to(user).emit("message received", newMessageRecieved); //The socket.in() method is used to emit the event to a specific room or channel that the user is subscribed to.
    });
    const message = new Message({
      sender: newMessageRecieved.sender._id,
      content: newMessageRecieved.content,
      chat: newMessageRecieved.chat,
      readBy: [],
    });

    // Save the message to the database
    message
      .save()
      .then(() => {
        console.log("✔✔ Message saved to the database");
      })
      .catch((error) => {
        console.error("❌❌ Error saving message to the database:", error);
      });
  });
});
