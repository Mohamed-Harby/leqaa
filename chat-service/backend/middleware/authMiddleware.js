const jwt = require("jsonwebtoken");
const { parse } = require("uuid");
const User = require("../models/userModel.js");
const asyncHandler = require("express-async-handler");
const {promisify}= require('util')

 exports.protect = asyncHandler(async (req, res, next) => {
  let token;
  let decodedUUID;

  if (
    req.headers.authorization &&
    req.headers.authorization.startsWith("Bearer")
  ) {
    try {
      //                                                    0       1
      token = req.headers.authorization.split(" ")[1]; // Bearer kdjfasjkj ==>token

      const decoded = jwt.verify(
        token,
        process.env.JWT_SECRET,
        (err, decoded) => {
          if (err) {
            console.error("Invalid token:", err.message);
            res.status(401).json({ message: err.message });
          } else {
            // console.log("Decoded token:", Object.keys(decoded));
            // global.mohmed="mohamed el-sayed"
            exports.decodedUUID =
              decoded[
                "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid"
              ]
           
            console.log("Decoded token:", decoded);
          }
        }
      );
      req.user = await User.findById(decodedUUID).select("-password");
      next();
      console.log('hellooooooooooooooooooo')
      // return 'mohamed'
    
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


// module.exports = { protect };


// const jwt = require("jsonwebtoken");
// const { parse } = require("uuid");
// const User = require("../models/userModel.js");
// const asyncHandler = require("express-async-handler");

// const protect = asyncHandler(async (req, res, next) => {
//   let token;

//   if (
//     req.headers.authorization &&
//     req.headers.authorization.startsWith("Bearer")
//   ) {
//     try {
//       token = req.headers.authorization.split(" ")[1];

//       const decoded = jwt.verify(
//         token,
//         process.env.JWT_SECRET,
//         (err, decoded) => {
//           if (err) {
//             console.error("Invalid token:", err.message);
//             res.status(401).json({ message: err.message });
//           } else {
//             req.decodedUUID = parse(
//               decoded[
//                 "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid"
//               ]
//             );
//             console.log("Decoded token:", decoded);
//           }
//         }
//       );

//       req.user = await User.findById(req.decodedUUID).select("-password");

//       next();
//     } catch (error) {
//       res.status(401);
//       throw error;
//     }
//   }

//   if (!token) {
//     res.status(401);
//     throw new Error("Not authorized, no token");
//   }
// });

// module.exports = { protect };
<<<<<<< HEAD
=======


const jwt = require("jsonwebtoken");
const { parse } = require("uuid");
const User = require("../models/userModel.js");
const asyncHandler = require("express-async-handler");
let decodedUUID;  
const protect = asyncHandler(async (req, res, next) => {
  let token;

  if (
    req.headers.authorization &&
    req.headers.authorization.startsWith("Bearer")
  ) {
    try {
      token = req.headers.authorization.split(" ")[1];

      const decoded = jwt.verify(
        token,
        process.env.JWT_SECRET,
        (err, decoded) => {
          if (err) {
            console.error("Invalid token:", err.message);
            res.status(401).json({ message: err.message });
          } else {
            decodedUUID = 
              decoded[
                "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid"
              ]
            ;
            console.log("Decoded token:", decoded);
          }
        }
      );

      req.user = await User.findById(decodedUUID).select("-password");
      x(decodedUUID)
      global.decodedUUID=decodedUUID;
      next();
    } catch (error) {
      res.status(401);
      throw error;
    }
  }

  if (!token) {
    res.status(401);
    throw new Error("Not authorized, no token");
  }
});
// i want a time out to be set here before exporting the decodedUUID  
// so that it can be used in the consumer.js file
// i want to export the decodedUUID and the protect function



function x(val){

  module.exports = { protect, val:val};
}
x();

>>>>>>> f5b03e00e33defcc726288dd37837b7a7d7ce393
