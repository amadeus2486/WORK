<%@ page contentType="text/html;charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>注册与反馈</title>
</head>
<body>
    <h1>账户注册</h1>
    <form action="RegisterServlet" method="post">
        <label for="name">姓名:</label>
        <input type="text" id="name" name="name" required>
        <br>
        <label for="gender">性别:</label>
        <select id="gender" name="gender">
            <option value="男">男</option>
            <option value="女">女</option>
        </select>
        <br>
        <label for="dob">出生年月:</label>
        <input type="date" id="dob" name="dob" required>
        <br>
        <label for="ethnicity">民族:</label>
        <input type="text" id="ethnicity" name="ethnicity">
        <br>
        <label for="intro">个人简介:</label>
        <textarea id="intro" name="intro"></textarea>
        <br>
        <button type="submit">注册</button>
    </form>
</body>
</html>