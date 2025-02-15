# 购物商场（藏雨阁）

## 功能介绍

 本项目提供一个功能相对完善的网上购物系统，同时提供一定的用户服务。 

## 模块介绍

1.商品模块

    ①商品分类；

    ②商品展示；

    ③商品详情；

    ④商品购买。

2.用户模块

    ①用户登录；

    ②个人页面；

    ③信息修改。

3.关联模块

    ①购物车；

    ②订单页。

4.补全模块

    ①用户反馈；

    ②优惠券领取；

    ③FAQ；

    ④网页详情。

## 项目部署

### 环境准备

前端：node.js

后端及数据库：MYSQL及JS。（有MYSQL就行）

### 项目准备

第一步：把项目全盘下载下来，所放的路径自己记得，后面要用到的。

第二步：分别进入：**存储路径\CangYuGe\client**和**存储路径\CangYuGe\server**，使用**npm install**下载依赖。（PS：下载过慢可以换成淘宝的国内镜像源）

第三步：检查**存储路径\CangYuGe\server\commons\settings.js**里的后端信息：

```js
    DB_HOST: "127.0.0.1",
    DB_PORT: "3306",//根据自己的端情况来
    DB_USER: "root",//用户名和密码同理
    DB_PASSWORD: "root",
    DB_DATABASE: "mall",//根据自己意愿设置数据库名并在此处修改
```

（PS：端口在本项目中为300，若有占用，前往**存储路径\CangYuGe\server\bin\app.js**进行修改）

第四步：找到**存储路径\CangYuGe\mall**文件，创建数据库后，运行该mall脚本，实现后端数据库信息的导入。

### 启动准备

1.后端

    ①管理员cd到**存储路径\CangYuGe\server\bin**；

    ②**node app**，正常启动会反馈并显示端口号。

2.前端

    ①管理员cd到**存储路径\CangYuGe\client**；

    ②**npm run serve**，等待vue启动并完成构建；

    ③网页输入：http://127.0.0.1:8080。

## 展示及提醒

未登录时：

![](C:\Users\lenovo\Desktop\文件类\subject%20selection\程序设计（前端和数据库）\图片\整体图.png)

（PS：图中红框均为可点击项，具体每个点击项对应的页面我就不在这里介绍了，留给大家自己去玩）

登录后：

![](C:\Users\lenovo\Desktop\文件类\subject%20selection\程序设计（前端和数据库）\图片\整体图（登录后）.png)

（区别在右上角的用户名显示和功能显示，和原版一样）

按照购物顺序来展示：

点击商品后查看详情：

![](C:\Users\lenovo\Desktop\文件类\subject%20selection\程序设计（前端和数据库）\图片\购买1.png)

点击“立即购买”后跳转：

![](C:\Users\lenovo\Desktop\文件类\subject%20selection\程序设计（前端和数据库）\图片\购买2.png)

点击“添加地址”后跳转：

![](C:\Users\lenovo\Desktop\文件类\subject%20selection\程序设计（前端和数据库）\图片\添加地址.png)

（PS：预留地址上显示的修改与删除目前还没有实现）

点击“立即下单”后确认之后跳转到订单页面：

![](C:\Users\lenovo\Desktop\文件类\subject%20selection\程序设计（前端和数据库）\图片\购买3.png)

（PS：在确认支付的弹窗选择中，确认为“已支付”，取消为“未支付”）

如果当初在选择“加入购物车”或者没有支付时，商品会存在购物车：

![](C:\Users\lenovo\Desktop\文件类\subject%20selection\程序设计（前端和数据库）\图片\购物车.png)

（PS：商品加入购物车后也会消耗库存）

购物结束，前往个人主页查看：

点击右上角用户名：

![](C:\Users\lenovo\Desktop\文件类\subject%20selection\程序设计（前端和数据库）\图片\个人主页.png)

点击“修改头像”后跳转：

![](C:\Users\lenovo\Desktop\文件类\subject%20selection\程序设计（前端和数据库）\图片\换头像.png)

（由于技术原因，要更换的头像要**手动存到存储路径\CangYuGe\server\public\images**中才能实现头像更换）

下面就是密码修改与退出登录：

![](C:\Users\lenovo\Desktop\文件类\subject%20selection\程序设计（前端和数据库）\图片\改密码和退出登录.png)

（PS：退出登录没啥好PS的）

![](C:\Users\lenovo\Desktop\文件类\subject%20selection\程序设计（前端和数据库）\图片\修改密码.png)

（PS：修改密码后会自动返回首页）

顺势展示一下与登录注册有关的页面：

![](C:\Users\lenovo\Desktop\文件类\subject%20selection\程序设计（前端和数据库）\图片\登录.png)

![](C:\Users\lenovo\Desktop\文件类\subject%20selection\程序设计（前端和数据库）\图片\注册.png)

**注意：优惠券领取页面目前没有实现后端交互，发现刷新后数量还原是正常现象，不然它怎么只能算是“补全模块”呢（bushi）。**
