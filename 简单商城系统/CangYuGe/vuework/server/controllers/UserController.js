let db = require("../commons/db")
let JSONResponse = require("../commons/JSONResponse")
let settings = require("../commons/settings")

/**
 * 注册
 * @param req 
 * @param resp 
 */
exports.register = (req, resp) => {
    let username = req.body.username
    let password = req.body.password
    let email = req.body.email
    // 验证账号密码
    if ( !username ) {
        resp.json(JSONResponse.fail("用户名不能为空", 400))
        return
    }
    if ( !password ) {
        resp.json(JSONResponse.fail("密码不能为空", 400))
        return
    }
    if ( !email ) {
        resp.json(JSONResponse.fail("邮箱地址不能为空", 400))
        return
    }
    // 看下数据库有没有这个账号
    db.queryOne("select count(*) as count from user where username = ? or email = ?", username, email)
        .then(res => {
            //  不为0则有
            if ( res.count ) {
                resp.json(JSONResponse.fail("用户名或者邮箱已经被使用啦", 400))
                return
            }
            db.update("insert into user(username, password, email, avatar) values(?, ?, ?, ?)", username, password, email, settings.DEFAULT_AVATAR)
                .then(res => {
                    console.log(res)
                    // 是否插入成功，affectedRows是受影响的行数，为0则失败
                    if ( res.affectedRows ) resp.json(JSONResponse.success(null, 200,"注册成功, 赶紧登录吧"))
                    else resp.json(JSONResponse.fail("注册失败", 500))
                })
                .catch(err => {
                    console.log(err)
                    resp.json(JSONResponse.fail("注册失败", 500))
                })
        })
}

/**
 * 登录
 * @param req 
 * @param resp 
 */
exports.login = (req, resp) => {
    let username = req.body.username
    let password = req.body.password
     // 验证账号密码
     if ( !username ) {
        resp.json(JSONResponse.fail("用户名不能为空", 400))
        return
    }
    if ( !password ) {
        resp.json(JSONResponse.fail("密码不能为空", 400))
        return
    }

    db.queryOne("select * from user where username = ? and password = ?", username, password)
        .then(res => {
            if ( res ) {
                req.session.user = res
                resp.json(JSONResponse.success(null, 200, "登录成功"))
            }
            else resp.json(JSONResponse.fail("用户名或密码错误"))
        })
}

/**
 * 获取登录用户信息
 * @param req 
 * @param resp 
 */
exports.profile = (req, resp) => {
    let sessionUser = {}
    Object.assign(sessionUser, req.session.user)
    delete sessionUser.password
    resp.json(JSONResponse.success(sessionUser))
}

/**  
 * 修改密码  
 * @param req   
 * @param resp   
 */  
exports.changePassword = (req, resp) => {  
    let username = req.body.username;   
    let oldPassword = req.body.oldPassword;  
    let newPassword = req.body.newPassword;  
    // 验证旧密码  
    db.queryOne("select * from user where username = ? and password = ?", username, oldPassword)  
        .then(user => {  
            if (!user) {  
                resp.json(JSONResponse.fail("旧密码错误", 400));  
                return;  
            }  
  
            // 更新密码  
            db.update("update user set password = ? where username = ?", newPassword, username)  
                .then(result => {  
                    if (result.affectedRows) {  
                        resp.json(JSONResponse.success(null, 200, "密码修改成功"));  
                    } else {  
                        resp.json(JSONResponse.fail("密码修改失败", 500));  
                    }  
                })  
                .catch(err => {  
                    console.log(err);  
                    resp.json(JSONResponse.fail("密码修改失败", 500));  
                });  
        })  
        .catch(err => {  
            console.log(err);  
            resp.json(JSONResponse.fail("旧密码验证失败", 500));  
        });  
};

/**  
 * 修改头像  
 * @param req  
 * @param resp  
 */  
exports.changeAvatar = (req, resp) => {  
     
    let avatar = req.body.avatar;   
    let userId = req.body.userId; 

    // 验证userId  
    db.queryOne("select * from user where id = ?", userId)  
        .then(user => {  
            if (!user) {  
                resp.json(JSONResponse.fail("用户不存在", 404));  
                return;  
            }  
  
            // 更新头像  
            db.update("update user set avatar = ? where id = ?", avatar, userId)  
                .then(result => {  
                    if (result.affectedRows) {  
                        resp.json(JSONResponse.success(null, 200, "头像修改成功"));  
                    } else {  
                        resp.json(JSONResponse.fail("头像修改失败", 500));  
                    }  
                })  
                .catch(err => {  
                    console.log(err);  
                    resp.json(JSONResponse.fail("头像修改失败", 500));  
                });  
        })  
        .catch(err => {  
            console.log(err);  
            resp.json(JSONResponse.fail("用户验证失败", 500));  
        });  
};
