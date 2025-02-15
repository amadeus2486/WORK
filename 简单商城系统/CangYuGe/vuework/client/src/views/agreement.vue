<template>  
    <div class="user-agreement">  
      <h1>用户协议</h1>  
        
      <p class="agreement-content">以下是我们的用户协议。请在使用我们的服务之前仔细阅读并理解以下内容：</p>  
      <p class="agreement-content">1. 您必须遵守所有适用的法律和规定。</p>  
      <p class="agreement-content">2. 您不得使用我们的服务进行任何非法或有害的活动。</p>  
        
      <h2>接受协议</h2>  
      <p>通过继续使用我们的服务，您表示已阅读、理解并接受本协议的所有条款和条件。</p>  
        
      <router-link :to="{name: 'index'}">返回主页</router-link>  
      <p>如果您已阅读并理解了用户协议，请点击以下链接返回主页：</p>  
        
      <button @click="goToLogin">返回登录页</button>  
  </div>  
</template>  
    
<script>  
export default {  
  name: 'UserAgreement',  
    methods: {  
      goToLogin() 
      {  
        if (this.$route.path !== '/log') 
        {
            this.$router.push('/log')
        }  
      },  
    },  
  };  
</script>  

<style scoped>  
.user-agreement {  
  display: flex;  
  flex-direction: column;  
  justify-content: center;  
  align-items: center;  
  min-height: 100vh;  
  margin: 0;  
  text-align: center;  
  font-family: Arial, sans-serif;  
  background-color: #bac1c5;  
  width:100%
}   
.agreement-content {  
  font-size: 18px;  
  font-weight: bold;  
  margin: 10px 0;
}
h1, p, a {  
    margin: 10px 0;  
}
</style>