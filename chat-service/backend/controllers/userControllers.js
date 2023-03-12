// const asyncHandler = require("express-async-handler");
// const User = require("../models/userModel"); // import user schema in user controller to do some operation like validation and authentcation using email for example
// const generateToken = require("../config/generateToken");

// //@description     Get or Search all users
// //@route           GET /api/user?search=
// //@access          Public
// const allUsers = asyncHandler(async (req, res) => {
//   const keyword = req.query.search
//     ? {
//         $or: [
//           { name: { $regex: req.query.search, $options: "i" } },
//           { email: { $regex: req.query.search, $options: "i" } },
//         ],
//       }
//     : {};

//   const users = await User.find(keyword).find({ _id: { $ne: req.user._id } });
//   res.send(users);
// });



// // this function needs async handler  so we run command npm i express-async-handler
// const registerUser = asyncHandler(async (req, res) => {
//   const { name, email, password, pic } = req.body;

//   if (!name || !email || !password) {
//     res.status(400);
//     throw new Error("Please Enter all the Feilds");
//   }

//   //  Do some quires on database
//   const userExists = await User.findOne({ email });

//   if (userExists) {
//     // if user exists create an error that the user already exists
//     res.status(400);
//     throw new Error("User already exists ❌");
//   }
//   // else if ===> user doesn't exist in database create it and add it to database
//   const user = await User.create({
//     name,
//     email,
//     password,
//     pic,
//   });

//   //   if user has successfully added to database
//   if (user) {
//     res.status(201).json({
//       // status 201 ==> means success
//       _id: user._id,
//       name: user.name,
//       email: user.email,
//       isAdmin: user.isAdmin,
//       pic: user.pic,
//       token: generateToken(user._id), //    when it registers a new user i wanted to create a new JWT token and send it to our user (when registerion is being sent we want token to be sent with registeration ) so we create function for it called generateToken()
//     });
//   } else {
//     res.status(400);
//     throw new Error("Failed to Create the User");
//   }
// });

// const authUser = asyncHandler(async (req, res) => {
//   const { email, password } = req.body; // we take two things from req ===> email and passward to auth

//   const user = await User.findOne({ email }); // get user from database using his email
//   if (user && (await user.matchPassword(password))) {
//     res.json({
//       _id: user._id,
//       name: user.name,
//       email: user.email,
//       pic: user.pic,
//       token: generateToken(user._id),
//     });
//   } else {
//     res.status(401);
//     throw new Error("Invalid Email and password");
//   }
// });

// module.exports = { allUsers, registerUser, authUser };






// --------------------------------------------------------





const asyncHandler = require("express-async-handler");
const User = require("../models/userModel");
const generateToken = require("../config/generateToken");
var uuid = require("node-uuid");


//@description     Get or Search all users
//@route           GET /api/user?search=
//@access          Public
const allUsers = asyncHandler(async (req, res) => {
  const keyword = req.query.search
    ? {
        $or: [
          { name: { $regex: req.query.search, $options: "i" } },
          { email: { $regex: req.query.search, $options: "i" } },
        ],
      }
    : {};

  const users = await User.find(keyword).find({ _id: { $ne: req.user._id } });
  res.send(users);
});

//@description     Register new user
//@route           POST /api/user/
//@access          Public
const registerUser = asyncHandler(async (req, res) => {
  const { name, email, password, pic } = req.body;

  if (!name || !email || !password) {
    res.status(400);
    throw new Error("Please Enter all the Feilds");
  }

  const userExists = await User.findOne({ email });

  if (userExists) {
    res.status(400);
    throw new Error("User already exists");
  }

  const user = await User.create({
    _id: uuid.v1(),
    name,
    email,
    password,
    pic,
  });

  if (user) {
    res.status(201).json({
      _id: user._id,
      name: user.name,
      email: user.email,
      isAdmin: user.isAdmin,
      pic: user.pic,
      token: generateToken(user._id),
    });
  } else {
    res.status(400);
    throw new Error("User not found");
  }
});

//@description     Auth the user
//@route           POST /api/users/login
//@access          Public
const authUser = asyncHandler(async (req, res) => {
  const { email, password } = req.body;

  const user = await User.findOne({ email });

  if (user && (await user.matchPassword(password))) {
    res.json({
      _id: user._id,
      name: user.name,
      email: user.email,
      isAdmin: user.isAdmin,
      pic: user.pic,
      token: generateToken(user._id),
    });
  } else {
    res.status(401);
    throw new Error("Invalid Email or Password");
  }
});

module.exports = { allUsers, registerUser, authUser };
