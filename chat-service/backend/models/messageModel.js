const mongoose = require("mongoose");
var uuid = require("node-uuid");

const messageSchema = mongoose.Schema(
  {
    _id: { type: String, default: uuid.v1 },
    sender: { type: String, default: uuid.v1, ref: "User" },
    content: { type: String, trim: true },
    chat: { type: String, default: uuid.v1, ref: "Chat" },
    readBy: [{ type: String, default: uuid.v1, ref: "User" }],
  },
  { timestamps: true }
);

const Message = mongoose.model("Message", messageSchema);
module.exports = Message;
