<template>  
  <div class="password-update-page">    
    <h2>修改密码</h2>    
   
      <div class="form-group">    
        <label for="oldPassword">旧密码:</label>    
        <input type="password" id="oldPassword" v-model="oldPassword" required class="form-control">    
      </div>    
      <div class="form-group">    
        <label for="newPassword">新密码:</label>    
        <input type="password" id="newPassword" v-model="newPassword" required class="form-control">    
      </div>    
      <button @click="changePassword" class="btn btn-primary" style="margin-right: 415px;">提交</button> 
      <button @click="ret" class="btn ret-primary">返回</button>      
    <p v-if="errorMessage" class="error-message">{{ errorMessage }}</p>    
    <p v-if="successMessage" class="success-message">{{ successMessage }}</p>    
  </div>   
</template>  
  
<script>  
import userHttp from "@/api/user"

export default {  
  data() {  
    return {  
      oldPassword: '',  
      newPassword: '',  
      errorMessage: '',  
      successMessage: '',
    };  
  },  
  methods: {  
    changePassword() {   
            const username=this.$store.state.user.username;
            const oldPassword=this.oldPassword;
            const newPassword=this.newPassword;
            userHttp.changePassword({username, oldPassword, newPassword})  
                .then(res => {  
                    if (res.code !== 200) {  
                        this.$message.error(res.message); 
                    } else {  
                        this.$message.success(res.message); 
                        this.modalVisible = false;
                        this.$store.dispatch('logout').then(() => {   
        this.$router.push({ name: 'index' })}); ;  
                    }  
                })  
                .catch(error => {  
                    console.error('Error changing password:', error);  
                    this.$message.error('Failed to change password.');  
                });  
        } , 
      ret(){
        this.$router.push({ name: 'profile' })
      }
  },  
};  
</script>  
  
<style scoped>  
.password-update-page {    
  max-width: 600px; 
  margin: 75px auto;  
  padding: 30px;
  border: 1px solid #ccc;    
  border-radius: 10px;  
  box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);   
}    
    
.form-group {    
  margin-bottom: 20px;  
}    
    
.form-control {    
  width: 100%;    
  padding: 12px; 
  border: 1px solid #ddd;    
  border-radius: 6px; 
  box-sizing: border-box;    
  font-size: 16px;  
}    
    
.btn-primary {    
  background-color: #007bff;    
  color: white;    
  padding: 14px 28px;   
  border: none;    
  border-radius: 6px;   
  cursor: pointer;    
  font-size: 18px; 
}    
    
.btn-primary:hover {    
  background-color: #0056b3;    
}

.ret-primary {    
  background-color: #ea5449;    
  color: white;    
  padding: 14px 28px;   
  border: none;    
  border-radius: 6px;   
  cursor: pointer;    
  font-size: 18px;  
}    
    
.ret-primary:hover {    
  background-color: #8e2816;    
}
    
.error-message, .success-message {    
  margin-top: 15px;   
  padding: 15px;  
  border-radius: 6px;   
  font-size: 16px;   
}    
    
.error-message {    
  background-color: #f8d7da;    
  color: #721c24;    
  border: 1px solid #f5c6cb;    
}    
    
.success-message {    
  background-color: #d4edda;    
  color: #155724;    
  border: 1px solid #c3e6cb;    
} 
</style>