<template>  
    <div class="feedback-container">  
      <form class="form-container">  
        <div class="form-group">  
          <label for="type">问题类型:</label>  
          <select v-model="feedback.type" id="type" class="form-contorl">  
            <option value="bug">Bug</option>  
            <option value="feature">功能建议</option>  
            <option value="other">其他</option>  
          </select>  
        </div>  
        <div class="form-group">  
          <label for="description">具体问题描述:</label>  
          <textarea v-model="feedback.description" id="description" required></textarea>  
        </div>  
        <div class="form-group">  
            <label>上传图片:</label>  
            <input type="file" @change="handleFileChange" ref="fileInput" style="display: none;">  
            <button @click="openFileInput" class="btn btn-secondary">添加图片</button>  
            <img v-if="feedback.image" :src="feedback.image" alt="Feedback Image" class="image-preview">
        </div>
        <div class="submit-btn-container"> 
        <button type="button" class="submit-btn btn btn-primary" @click="handleSubmit">提交反馈</button>  
      </div> 
    </form>
    </div>
      
  </template>  
    
  <script>  
  export default {  
    data() {  
      return {  
        feedback: {  
          type: '',  
          description: '',  
          image: null,  
        }, 
      };  
    },  
    methods: {  
        openFileInput() {   
      this.$refs.fileInput.click();  
    },  
    handleFileChange(event) {  
      const file = event.target.files[0];
      if (file) {   
        this.feedback.image = URL.createObjectURL(file);
      }  
    },    
      handleSubmit() {  
        if (!this.feedback.description) {  
          alert('请填写问题描述！');  
          return;  
        }   
        alert('提交成功！');  
        // 没有完成后端相关功能的部署，就先做个反馈  
        this.feedback = { type: '', description: '', image: null };  
      },
      beforeDestroy() {  
    if (this.feedback.image) {  
      URL.revokeObjectURL(this.feedback.image);  
    }  
  },    
    },  
  };  
  </script>  
    
  <style scoped>  
  .feedback-container {  
  display: flex;  
  flex-direction: column;  
  align-items: center;  
  justify-content: center;  
  height: 100vh;  
  padding: 20px;  
  box-sizing: border-box;  
  background-color: #f8f9fa; 
}  
  
.form-container { 
   
  width: 100%;  
  max-width: 600px;  
  padding: 20px;  
  border: 1px solid #ced4da;  
  border-radius: 8px;  
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);  
}  
  
.form-group {  
  margin-bottom: 20px;  
  display: flex;  
  flex-direction: column;  
}  
  
.form-group label {  
  margin-bottom: 5px;  
}  
  
.form-control {  
  width: 100%;  
  padding: 10px;  
  font-size: 16px;  
  border: 1px solid #ced4da;  
  border-radius: 4px;  
  box-sizing: border-box; 
}  
  
.form-control:focus {  
  border-color: #80bdff;  
  outline: none;
  box-shadow: 0 0 0 0.2rem rgba(0, 123, 255, 0.25);   
}  
  
.btn {  
  padding: 10px 20px;  
  font-size: 16px;  
  border: none;  
  border-radius: 4px;  
  cursor: pointer;  
  transition: background-color 0.3s ease;  
}  
  
.btn-primary {  
  background-color: #007bff;  
  color: white;  
  &:hover {  
    background-color: #0056b3; 
  }  
}  
  
.btn-secondary {  
  background-color: #6c757d;  
  color: white;  
  &:hover {  
    background-color: #5a6268; 
  }  
}  
  
.image-preview {  
  max-width: 100%;  
  height: auto;  
  margin-top: 10px;  
  border-radius: 4px;  
  display: block;   
}

.submit-btn-container {  
  display: flex;  
  justify-content: center; 
  margin-top: 20px; 
  width: 100%; 
}  
  </style>