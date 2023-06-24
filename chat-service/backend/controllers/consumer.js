const User = require("./../models/userModel");
const mongoose = require("mongoose");
const amqp = require("amqplib");
const Chat = require("../models/chatModel");
const decodedUUID = require("./../middleware/authMiddleware");

async function consumeFromQueue(queueName, handleMessage) {
  try {
    // Connect to RabbitMQ server
    const connection = await amqp.connect(
      process.env.RABBITMQ
    );
    const channel = await connection.createChannel();

    // Assert queue
    const queue = await channel.assertQueue(queueName, { durable: true });

    // Consume messages from queue
    channel.consume(
      queue.queue,
      (msg) => {
        const messageString = msg.content.toString("utf-8");
        const messageJson = JSON.parse(messageString);
        console.log(messageJson);

        handleMessage(messageJson);
      },
      { noAck: true }
    );
  } catch (err) {
    console.error(err);
  }
}

const MyController = {
  async startConsumingMessages() {
    // Call consumeFromQueue with appropriate arguments
   
    const addUserToChat = async (message) => {
      console.log(`Received message: ${JSON.stringify(message)}`);
      console.log(message);
      // Handle incoming message
      try {
        // let user = new User(message);
        let user = new User({
          _id: message.Id,
          name: message.Name,
          email: message.Email,
          // password: "pass5word", // Set a plain password, which will be hashed by the pre-save hook
          pic: "https://icon-library.com/images/anonymous-avatar-icon/anonymous-avatar-icon-25.jpg",
          isAdmin: true,
        });

        user
          .save()
          .then(() => {
            console.log("User saved successfully.✔✔");
          })
          .catch((err) => {
            console.error("Error saving user:❌❌", err);
          });
      } catch (err) {
        console.log(err);
      }
    };

    const createGroup = async (message, req, res) => {
      // Message handling logic
      console.log(`Received message: ${JSON.stringify(message)}`);
      console.log(message);

      try {
        const users = message.JoinedUsers.map((user) => user.Id);
        const existedGroup = await Chat.findById(message.Id);
        console.log("uers😂", users);
        // console.log("decoded uuid ", decodedUUID);
        if (existedGroup) {
          return res.status(400).send("Group already exists");
        } /* else if (users.length < 2) {
          return res
            .status(400)
            .send("More than 2 users are required to form a group chat");
        }*/ else {
          const groupChat = await Chat.create({
            _id: message.Id,
            chatName: message.Name,
            users: users,
            isGroupChat: true,
            // groupAdmin: decodedUUID,
          });

          const fullGroupChat = await Chat.findOne({ _id: groupChat._id })
            .populate("users", "-password")
            .populate("groupAdmin", "-password");

          // res.status(200).json(fullGroupChat);
        }
      } catch (err) {
        console.log(err);
      }
    };

    consumeFromQueue("Authentication.UserToChat", addUserToChat);
    consumeFromQueue("BusinessDomain.GroupCreated", createGroup);
  },

};

module.exports = MyController;
