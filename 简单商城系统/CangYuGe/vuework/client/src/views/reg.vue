<template>
    <div class="bg">
      <div id="register">
          <h2>注册页面</h2>
          <el-form ref="form" :model="form" label-width="20%">
          <el-form-item label="用户名:">
              <el-input v-model="form.username" placeholder="请输入用户名"></el-input>
          </el-form-item>
          <el-form-item label="密  码:">
              <el-input v-model="form.password" type="password" placeholder="请输入密码"></el-input>
          </el-form-item>
          <el-form-item label="再输入:">
              <el-input v-model="form.Dpassword" type="password" placeholder="再输入密码"></el-input>
          </el-form-item>
          <el-form-item label="邮箱:">
              <el-input v-model="form.email" type="text" placeholder="请输入邮箱"></el-input>
          </el-form-item>
          <el-form-item label="验证码:">
              <el-input v-model="Inputcaptcha" type="text" placeholder="请输入验证码"></el-input>
          </el-form-item>
          <p>验证码：{{ captcha }} <el-button type="primary" round @click="refreshCaptcha" >刷新</el-button></p>
          </el-form>
          <p>类型（可不选）：&nbsp;
            <input type="radio" name="type" id="up"><label for="up">商家 </label>
            <input type="radio" name="type" id="tour"><label for="tour">游客</label>
          </p>
          <el-button type="primary" round @click="register" class="btn">注册</el-button>
          <p class="smtxt">已有账户?<router-link :to="{name: 'log'}">前往登录</router-link> </p>
          <router-link :to="{ name: 'index' }">返回主页</router-link>
        </div>
    </div>
  </template>
  
  <script>
import userHttp from "@/api/user"

  export default {
    data () {
      return {
        form: {
          username: '',
          password: '',
          Dpassword:'' ,
          email:'',
        },
        captcha:'xxxx' ,
        Inputcaptcha:'',
        isnull: false
      };
    },
   
    methods: {
      register() {
        if(this.form.username == '') {
          this.$message.error('用户名不能为空');
        }else if(this.form.password == '') {
          this.$message.error('密码不能为空');
        }else if(this.form.email == '') {
          this.$message.error('邮箱不能为空');
        }else if(this.form.password!=this.form.Dpassword){
          this.$message.error('两次输入密码不同')
        }else if(this.captcha!=this.Inputcaptcha){
          this.$message.error('验证码输入错误')
        }
        else {
          const username=this.form.username;
          const password=this.form.password;
          const email=this.form.email;
            userHttp.register({username,password,email})
                .then(res => {
                    if ( res.code != 200 ) this.$warning(res.message)
                    else {
                        this.$success(res.message)
                        this.modalVisible = false
                        this.$router.push({ name: 'log' })
                    }
                })
        }
      },
      refreshCaptcha(){
        this.captcha = Math.floor(1000 + Math.random() * 9000).toString().padStart(4, '0');
      },
    }
  }
  </script>
  
  <style scoped>
  .bg {
      position: absolute;
      top: 0;
      bottom: 0;
      left: 0;
      right: 0;
      background: url('/src/assets/register.jpeg');
      background-size: 100% 100%;
  }
   #register {
      height: 650px;
      width: 500px;
      box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.25);
      background: #ffffff;
      opacity: 0.85;
      position: absolute;
      top: 10%;
      left: 35%;
      text-align: center;
      display: flex;
      flex-direction: column;
      padding: 30px;
    }
    #register h2 {
      padding-bottom: 30px;
    }
    .btn {
      width: 60%;
      margin: auto;
    }
    .blg{
      color:rgb(63, 63, 169)
    }
  </style>