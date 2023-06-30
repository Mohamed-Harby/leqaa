const mongoose = require("mongoose");
// const bcrypt = require("bcryptjs");
var uuid = require("node-uuid");

// const crypto = require("node:crypto");

const userSchema = mongoose.Schema(
  {
    _id: { type: String, default: uuid.v1 },
    name: { type: "String", required: true },
    email: { type: "String", unique: true, required: true },
    password: { type: "String" },
    pic: {
      type: "String",
      required: true,
      default:
        "https://icon-library.com/images/anonymous-avatar-icon/anonymous-avatar-icon-25.jpg",
    },
    isAdmin: {
      type: Boolean,
      required: true,
      default: false,
    },
    // gender: {
    //   enum: {
    //     values: ["Male", "Female"],
    //     message: "Gender is either: Male or Female",
    //   },
    // },
  },
  { timestamps: true }
);

// userSchema.methods.matchPassword = async function (enteredPassword) {
//   return await bcrypt.compare(enteredPassword, this.password);
// };

// userSchema.pre("save", async function (next) {
//   if (!this.isModified) {
//     next();
//   }

//   // const salt = await bcrypt.genSalt(10);
//   // this.password = await bcrypt.hash(this.password, salt);

//   this.password = crypto
//     .createHmac("sha256", process.env.JWT_SECRET)
//     .update(this.password)
//     .digest("hex");
// });

const User = mongoose.model("User", userSchema);

module.exports = User;
