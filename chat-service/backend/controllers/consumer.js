const User = require("./../models/userModel");
const mongoose = require("mongoose");
const amqp = require("amqplib");

async function consumeFromQueue(queueName, handleMessage) {
  try {
    // Connect to RabbitMQ server
    const connection = await amqp.connect("amqp://localhost");
    const channel = await connection.createChannel();

    // Assert queue
    const queue = await channel.assertQueue(queueName, { durable: false });

    // Consume messages from queue
    channel.consume(
      queue.queue,
      (msg) => {
        const messageString = msg.content.toString("utf-8");
        const messageJson = JSON.parse(messageString);
        console.log(messageJson);
        // try {
        //   User.create({
        //     _id: messageJson.Id,
        //     name: messageJson.Name,
        //     email: messageJson.Email,
        //     password: messageJson.password,
        //     gender: messageJson.Gender,
        //   });
        // } catch (err) {
        //   console.log(err);
        // }

        // User.create(messageJson);

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
    consumeFromQueue("Authentication.UserToChat", (message) => {
      console.log(`Received message: ${JSON.stringify(message)}`);
      // console.log(`Type of the Received message: ${typeof message}`);
      // console.log("NAME ===", message.Id);

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

      // try {

      //   const messageString = JSON.stringify(message);
      //   console.log(messageString)
      //   const messageObject = JSON.parse(messageString)
      //   console.log(messageObject);
      //   // console.log(Object.keys(message));
      //   // const jsonMessage = JSON.parse(message);

      //   // console.log(`Parsed JSON message: ${jsonMessage['Id']}`);
      //   // console.log(`Type of the parsed JSON message: ${typeof jsonMessage}`);
      // } catch (error) {
      //   console.error(`Error parsing message: ${error}`);
      // }
    });
  },

  // Other controller functions...
};

module.exports = MyController;
