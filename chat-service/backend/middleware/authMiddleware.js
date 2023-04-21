const jwt = require("jsonwebtoken");
const User = require("../models/userModel.js");
const asyncHandler = require("express-async-handler");

const protect = asyncHandler(async (req, res, next) => {
  let token;

  if (
    req.headers.authorization &&
    req.headers.authorization.startsWith("Bearer")
  ) {
    try {
      // token =
      //   "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Implc2luZTY5NjRAcHJvZXhib2wuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiamVzaW5lNjk2NEBwcm9leGJvbC5jb20iLCJleHAiOjE2ODEwNjE5MDd9.pIBcMTONaSuo5jOcalgrXR35YE5IAH7pkt5eXzHamE8";

      //                                                    0       1
      token = req.headers.authorization.split(" ")[1]; // Bearer kdjfasjkj ==>token

      //decodes token id
      // const decoded = jwt.verify(token, process.env.JWT_SECRET);
      // console.log(decoded);


      const decoded =jwt.verify(token, process.env.JWT_SECRET, (err, decoded) => {
        if (err) {
          console.error("Invalid token:", err.message);
        } else {
          console.log("Decoded token:", decoded);
        }
      });


      req.user = await User.findById(decoded.id).select("-password");

      next();
    } catch (error) {
      res.status(401);
     throw error;
      // throw new Error("Not authorized, token failed");
    }
  }

  if (!token) {
    res.status(401);
    throw new Error("Not authorized, no token");
  }
});

module.exports = { protect };
