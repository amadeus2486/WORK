<template>  
    <div class="taobao-profile">  
        <header>
        <h1>{{ $store.state.user.username }}的个人主页</h1>      
      <img :src="$store.state.user.avatar" alt="用户头像" class="avatar"> 
      <button @click="avaterChange" >修改头像</button>
    </header>  
  
    <main>  
      <section class="profile-info">  
        <h2>个人信息</h2>  
        <div class="info-item">  
          <span>用户名:</span>  
          <span>{{ $store.state.user.username }}</span>  
        </div>  
        <div class="info-item">  
          <span>会员号:</span>  
          <span>{{ $store.state.user.id }}</span>  
        </div>  
        <div class="info-item">  
          <span>邮箱:</span>  
          <span>{{ $store.state.user.email }}</span>  
        </div>  
      </section>
    
        <section class="orders">  
          <h2>订单历史</h2>  
          <ul>  
            <li>  
              <h3>订单号: 123456789</h3>  
              <p>商品: 这只是个静态例子</p>  
              <p>状态: 已完成</p>  
            </li>  
            <!-- 更多订单项要等之后完善了(Q.Q)... -->  
          </ul>  
        </section>  
    
        <section class="favorites">  
          <h2>我的收藏</h2>  
          <div class="favorites-grid">  
            <div class="favorite-item">  
              <img src="https://via.placeholder.com/100" alt="商品A">  
              <p>商品A</p>  
            </div>  
            <div class="favorite-item">  
              <img src="https://via.placeholder.com/100" alt="商品B">  
              <p>商品B</p>  
            </div>  
            <!-- 更多收藏项... -->  
          </div>  
        </section>  
        <div class="button-group">  
        <button @click="changePassword" class="button">修改密码</button>  
        <button @click="logout" class="button">退出登录</button>  
      </div>   

      </main>  
    
      <footer>  
        <p>版权所有 &copy; 2024 Yoshimura</p>  
      </footer>  
    </div>  
  </template>  
    
  <script>

  export default {  
    data() {  
    return {  
      userName: '',  
      userAvatar: 'https://via.placeholder.com/150', // 默认头像  
      userLevel: '',  
      registrationDate: ''  
    };  
  },
    methods: {  
    logout() {  
      this.$store.dispatch('logout').then(() => {  
        this.$router.push({ name: 'index' }); });  
    }, 
    changePassword()
    {
      this.$router.push({ name: 'cpassword' });
    } ,
    avaterChange(){
      this.$router.push({ name: 'cavatar' });
    }
  }, 
  mounted() {
        this.getUser()
    }, 

};  
  </script>  
    
  <style scoped>  
  .taobao-profile {  
    font-family: Arial, sans-serif;  
    max-width: 800px;  
    margin: 0 auto;  
    padding: 20px;  
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);  
    border-radius: 8px;  
    background-color: #fff;  
  }  
    
  header {  
    text-align: center;  
    margin-bottom: 20px;  
  }  
    
  .avatar {  
    width: 100px;  
    height: 100px;  
    border-radius: 50%;  
    margin: 0 auto 10px;  
    display: block;  
  }  
    
  main section {  
    margin-bottom: 30px;  
    border-bottom: 1px solid #eee;  
    padding-bottom: 20px;  
  }  
    
  main section:last-child {  
    border-bottom: none;  
    margin-bottom: 0;  
    padding-bottom: 0;  
  }  
    
  .profile-info {  
    display: flex;  
    flex-direction: column;  
  }  
    
  .info-item {  
    display: flex;  
    justify-content: space-between;  
    align-items: center;  
    margin-bottom: 10px;  
  }  
    
  .info-item span:first-child {  
    font-weight: bold;  
    min-width: 100px;  
  }  
    
  .orders ul {  
    list-style: none;  
    padding: 0;  
  }  
    
  .orders li {  
    padding: 10px;  
    border-bottom: 1px solid #eee;  
  }  
    
  .orders li:last-child {  
    border-bottom: none;  
  }  
    
  .favorites-grid {  
    display: flex;
    flex-wrap: wrap;
justify-content: space-around;
gap: 10px;
}

.favorite-item {
flex: 0 0 calc(33.333% - 10px); 
text-align: center;
border: 1px solid #eee;
border-radius: 4px;
padding: 10px;
box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
transition: transform 0.2s ease;
}

.favorite-item img {
width: 100%;
height: auto;
border-radius: 4px;
}

.favorite-item:hover {
transform: translateY(-4px);
box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}

footer {
text-align: center;
margin-top: 20px;
padding-top: 10px;
border-top: 1px solid #eee;
font-size: 0.875em;
color: #666;
}

/* Responsive adjustments */
@media (max-width: 600px) {
.favorites-grid {
flex-direction: column;
align-items: center;
}

.favorite-item {
flex: 0 0 calc(100% - 20px); 
margin-bottom: 10px;
}
} 
  .button-group {  
  display: flex; 
  justify-content: center;  
  align-items: center; 
  gap: 10px;  
}  
  
.button {  
  padding: 10px 20px;   
    font-size: 16px;  
    cursor: pointer;  
    border: none; 
    border-radius: 5px;  
    background-color: #007bff;   
    color: white; 
}
</style>