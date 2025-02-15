let express = require('express')
let router = express.Router()
let contaceController = require("../controllers/ContactController")

router.get("/list", contaceController.listByUserId)
router.post("/createAddress", contaceController.createAddress)

module.exports = router
