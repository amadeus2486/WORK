let db = require("../commons/db")
let JSONResponse = require("../commons/JSONResponse")

exports.listByUserId = (req, reps) => {
    let userId = req.session.user.id
    if ( !userId ) {
        reps.json(JSONResponse.fail("必须要有用户id"))
        return
    }
    db.query("select * from contact where user_id = ?", userId)
        .then(contants => {
            reps.json(JSONResponse.success(contants))
        })
}

exports.createAddress = (req, res) => {  
    let { name, telephone, address, tag, userId } = req.body;  
   
    if (!userId || !name || !telephone || !address || !tag) {  
        res.json(JSONResponse.fail("所有字段都是必填的，包括用户ID、姓名、电话、地址和标签"));  
        return;  
    }  
  
 
    db.update("insert into contact(user_id, name, telephone, address, tag) values(?, ?, ?, ?,?)", userId, name, telephone, address, tag)  
        .then(() => {  
            res.json(JSONResponse.success(null, 200,"地址信息创建成功！"));  
        })  
        .catch(err => {  
            console.error("创建地址时发生错误:", err);  
            res.json(JSONResponse.fail("创建地址失败，请稍后再试"));  
        }); 
        
};
