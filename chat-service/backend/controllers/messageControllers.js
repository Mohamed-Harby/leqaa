const asyncHandler = require("express-async-handler");
const Message = require("../models/messageModel");
const User = require("../models/userModel");
const Chat = require("../models/chatModel");
var uuid = require("node-uuid");

const protect = require("./../middleware/authMiddleware");

const mongoose = require("mongoose");

//@description     Get all Messages
//@route           GET /api/Message/:chatId
//@access          Protected
const allMessages = asyncHandler(async (req, res) => {
  try {
    const messages = await Message.find({ chat: req.params.chatId })
      .populate("sender", "name pic email")
      .populate("chat");
    res.json(messages);
  } catch (error) {
    res.status(400);
    throw new Error(error.message);
  }
});

//@description     Create New Message
//@route           POST /api/Message/
//@access          Protected
const sendMessage = asyncHandler(async (req, res) => {
  const { content, chatId } = req.body;
  // console.log("👿👿👿", Object.keys(req.decoded));
  // console.log("😂keys😁", req.decoded.keys());
  if (!content || !chatId) {
    console.log("Invalid data passed into request");
    return res.sendStatus(400);
  }
  const senderObj = {
    name: req.decoded[
      "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
    ],

    email:
      req.decoded[
        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"
      ],

    _id: req.decoded[
      "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid"
    ],
  };

  var newMessage = {
    _id: uuid.v1(),
    // sender: req.user._id,
    sender: senderObj,
    content: content,
    chat: chatId, //chatid , isGroupChat, createdAt, users array
  };

  try {
    var message = await Message.create(newMessage);

    message = await message.populate("sender", "_id name email");
    message = await message.populate("chat");
    message = await User.populate(message, {
      path: "chat.users",
      select: "name pic email",
    });

    await Chat.findByIdAndUpdate(req.body.chatId, { latestMessage: message });

    res.json(message);
  } catch (error) {
    res.status(400);
    throw new Error(error.message);
  }
});

module.exports = { allMessages, sendMessage };
