const express = require("express");
const multer = require("multer");
const {
  allMessages,
  sendMessage,
} = require("../controllers/messageControllers");
const { protect } = require("../middleware/authMiddleware");
const messageController = require("../controllers/messageControllers");
const router = express.Router();

router.route("/:chatId").get(protect, allMessages);
router.route("/").post(protect, sendMessage);

const upload = multer({ storage: multer.memoryStorage() });

router.post(upload.single('file'),messageController.uploadFile);
module.exports = router;
