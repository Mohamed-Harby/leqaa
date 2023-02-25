const mongoose = require("mongoose");

const connectDB = async () => {
  try {
    mongoose.set("strictQuery", true);
    const conn = await mongoose.connect(process.env.MONGO_URI, {
    //   userNewUrlParser: true,
      useUnifiedTopology: true,
      // useFindAndModify: true,
    });

    console.log(`MongoDB Connected ${conn.connection.host}`);
  } catch (error) {
    console.log("ERROR: ", error.message);
    process.exit();
  }
};

module.exports = connectDB;
