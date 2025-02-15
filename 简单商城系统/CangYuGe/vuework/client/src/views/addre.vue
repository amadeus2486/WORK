<template>  
    <div class="address-form-container">  
      <h1>添加新地址</h1>  
        <div class="form-group">  
          <label for="name">收件人:</label>  
          <input type="text" id="name" v-model="formData.name" required>  
        </div>  
        <div class="form-group">  
          <label for="telephone">电话:</label>  
          <input type="tel" id="telephone" v-model="formData.telephone" required>  
        </div>  
        <div class="form-group">  
          <label for="address">收件地址:</label>  
          <textarea id="address" v-model="formData.address" required rows="4"></textarea>  
        </div>  
        <div class="form-group">  
          <label for="tag">标签:</label>  
          <input type="text" id="tag" v-model="formData.tag">  
        </div>  
        <button @click="create" class="submit-btn">提交</button>
        <h3></h3>
        <button @click="ret" class="return-btn">返回购物车</button>   
    </div>  
  </template>  
    
  <script>
  import contactHttp from "@/api/contact"

  export default {  
    data() {  
      return {  
        formData: {  
          name: '',  
          telephone: '',  
          address: '',  
          tag: ''  ,
          userId:''
        }  
      }  
    },  
    methods: {  
     ret(){
        this.$router.push({ name: "buy" })
     },
     create(){
        this.formData.userId=this.$store.state.user.id;
        contactHttp.createAddress(this.formData)  
                .then(res => {  
                    if (res.code !== 200) {  
                        this.$message.error(res.message); 
                    } else {  
                        this.$message.success(res.message);    
                        this.$router.push({ name: 'buy' });
                    }  
                })  
                .catch(error => {  
                    console.error('Error create an address:', error);  
                    this.$message.error('Failed to create an address.');  
                }); 
     }
    }  
  }  
  </script>  
    
  <style scoped>  
  .address-form-container {  
    max-width: 600px;  
    margin: 50px auto;  
    padding: 20px;  
    border: 1px solid #ccc;  
    border-radius: 8px;  
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);  
  }  
    
  .form-group {  
    margin-bottom: 20px;  
  }  
    
  .form-group label {  
    display: block;  
    margin-bottom: 5px;  
    font-weight: bold;  
  }  
    
  .form-group input,  
  .form-group textarea {  
    width: 100%;  
    padding: 8px;  
    box-sizing: border-box;  
    border: 1px solid #ddd;  
    border-radius: 4px;  
  }  
    
  .submit-btn {  
    width: 100%;  
    padding: 10px;  
    background-color: #4CAF50;  
    color: white;  
    border: none;  
    border-radius: 4px;  
    cursor: pointer;  
    font-size: 16px;  
  }  
    
  .submit-btn:hover {  
    background-color: #45a049;  
  }

  .return-btn {  
    width: 100%;  
    padding: 10px;  
    background-color: #5a98ef;  
    color: white;  
    border: none;  
    border-radius: 4px;  
    cursor: pointer;  
    font-size: 16px;  
  }  
    
  .return-btn:hover {  
    background-color: #4695bc;  
  } 
  </style>