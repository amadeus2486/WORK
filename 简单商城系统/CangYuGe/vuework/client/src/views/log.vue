<template>
    <div class="bg">
      <div id="login">
          <h2>用户登录</h2>
          <el-form ref="form" :model="form" label-width="20%">
          <el-form-item label="用户名:">
              <el-input v-model="form.username" placeholder="请输入用户名"></el-input>
          </el-form-item>
          <el-form-item label="密  码:">
              <el-input v-model="form.password" type="password" placeholder="请输入密码"></el-input>
          </el-form-item>
          </el-form>
          <div class="left-align">
          <input id="remember" type="checkbox" /><label for="remember" class="smtxt">记住密码</label></div>
          <div class="left-align">
          <input id="agreeTerms" type="checkbox" v-model="isAgreed" />  
              <label for="agreeTerms" class="smtxt">我已阅读并承认<router-link :to="{name: 'agreement'}">《XX用户协议》</router-link> </label>
          </div>
          <el-button type="primary" round @click="login" class="btn">登录</el-button>
          <p class="smtxt">还没有账户? <router-link :to="{name: 'reg'}">前往注册</router-link></p>
          <router-link :to="{name: 'index'}">返回主页</router-link>
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
          password: ''  
        },
        isAgreed:false,
      };
    },
  
    methods: {
      login() {
        if(this.form.username == '') {
          this.$message.error('用户名不能为空');
        }else if(this.form.password == '') {
          this.$message.error('密码不能为空');
        }else if(!this.isAgreed){
          this.$message.error('请勾选《XX用户协议》')
        }

        else{
            userHttp.login(this.form)
                .then(res => {
                    if ( res.code / 100 != 2 ) this.$warning(res.message)
                    else {
                        // 获取用户信息
                        this.$success(res.message)
                        this.modalVisible = false
                        this.$router.push({ name: 'index' })
                    }
                })
        }
      },

    }
  }
  </script>
  
  <style scoped>
  .left-align {  
    text-align: left;  
    display: inline-block;
    flex-wrap: wrap;
    margin:5px 0;
  }
  .bg {
      position: absolute;
      top: 0;
      bottom: 0;
      left: 0;
      right: 0;
      background: url('/src/assets/background.jpg');
      background-size: 100% 100%;
  }
   #login {
      height: 400px;
      width: 500px;
      box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.25);
      background: #ffffff;
      opacity: 0.85;
      position: absolute;
      top: 20%;
      left: 35%;
      text-align: center;
      display: flex;
      flex-direction: column;/*横向*/
      padding: 30px;
    }
    #login h2 {
      padding-bottom: 30px;
    }
    .btn {
      width: 60%;
      margin: auto;
    }
    .reg {
      color: red;
      position: absolute;
      bottom: 10px;
      right: 10px;
      cursor:pointer;
    }
    .blg{
      color:rgb(63, 63, 169)
    }
  </style>