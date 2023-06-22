import React, { useEffect, useState } from "react";
import io from "socket.io-client";

// const ENDPOINT = "http://localhost:6969";

const ChatComponent = () => {
  const [messages, setMessages] = useState([]);
  const [newMessage, setNewMessage] = useState("");

  useEffect(() => {
    // const socket = io(ENDPOINT);

    // console.log('Connected to socket.io');

    // const userData = {
    //   "id": "7ccb0dbc-d6eb-49d5-acc5-0a8e8edf0562",
    //   "name": "Leqaa",
    //   "email": "Leqaa.Technical@gmail.com",
    //   "userName": "Leqaa",
    //   "gender": 1
    // };

    // socket.emit('setup', userData); // Send user data to the server

    // socket.on('connected', () => {
    //   console.log('Connected to socket.io server');
    // });

    // socket.on('message received', (newMessageReceived) => {
    //   console.log('New message received:', newMessageReceived);
    //   setMessages((prevMessages) => [...prevMessages, newMessageReceived]);
    // });

    // return () => {
    //   socket.disconnect(); // Clean up the socket connection when the component unmounts
    // };
    const ENDPOINT = "http://localhost:6969";

    // Establish a connection with the server
    const socket = io(ENDPOINT); // Replace ENDPOINT with the server's URL

    // console.log("Connected to socket.io");

    socket.on("connect", () => {
      console.log("Connected to the server");

      // Emit 'setup' event with user data
      const userData = {
        id: "7ccb0dbc-d6eb-49d5-acc5-0a8e8edf0562",
        name: "Leqaa",
        email: "Leqaa.Technical@gmail.com",
        userName: "Leqaa",
        gender: 1,
      };
      socket.emit("setup", userData);
    });

    socket.on("connected", () => {
      console.log("Connected to the chat");
    });

    const room = "08db7294-0b99-40f2-833f-7cf9b608d8b7";

    socket.on("join chat", (room) => {
      console.log("User joined room: " + room);
    });

    socket.on("typing", () => {
      console.log("Someone is typing");
    });

    socket.on("stop typing", () => {
      console.log("Someone stopped typing");
    });

    socket.on("message received", (newMessageReceived) => {
      console.log("New message received:", newMessageReceived);
    });

    socket.on("disconnect", () => {
      console.log("Disconnected from the server");
    });

    // You can also emit events from the client to the server
    // socket.emit("join chat", selectedChat._id); // Emit 'join chat' event with the selected chat ID
    socket.emit("typing", room); // Emit 'typing' event for a specific room
    socket.emit("stop typing", room); // Emit 'stop typing' event for a specific room
    socket.emit("new message", newMessage); // Emit 'new message' event with a new message object
  }, []);

  // const handleInputChange = (e) => {
  //   setNewMessage(e.target.value);
  // };

  // const handleSendMessage = () => {
  //   // Send the new message to the server
  //   const socket = io(ENDPOINT);
  //   socket.emit('new message', { message: newMessage });

  //   // Clear the input field
  //   setNewMessage('');
  // };

  return (
    <div>
      {/* <h1>Chat Component</h1>
      <div>
        <ul>
          {messages.map((message, index) => (
            <li key={index}>{message}</li>
          ))}
        </ul>
      </div>
      <div>
        <input type="text" value={newMessage} onChange={handleInputChange} />
        <button onClick={handleSendMessage}>Send</button>
      </div> */}
    </div>
  );
};

export default ChatComponent;
