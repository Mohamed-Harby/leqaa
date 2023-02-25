const jwt = require("jsonwebtoken"); // npm i jsonwebtoken      to install packages of jwt
const { model } = require("mongoose");

const generateToken = (id) => {
  return jwt.sign({ id }, process.env.JWT_SECRET, { expiresIn: "30d" });
};

module.exports = generateToken;
