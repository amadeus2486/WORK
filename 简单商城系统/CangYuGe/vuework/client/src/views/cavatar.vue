<template>  
  <div class="avatar-container">  
    <input type="file" @change="previewImage" accept="image/*" class="file-input" />  
    <button @click="uploadImage" class="upload-btn">上传头像</button>  
    <div v-if="imageUrl" class="preview-container">  
      <img :src="imageUrl" alt="头像预览" class="preview-img" />  
    </div>  
    <button @click="reg" class="back-btn">返回</button>  
    <h3 class="info-text"><strong>请先确保你的图片放在了指定的位置</strong></h3>  
  </div>  
</template>
  
<script>
import userHttp from "@/api/user"

export default {  
  data() {  
    return {  
      imageUrl: null,
      URL:''  
    };  
  },  
  methods: {  
    previewImage(event) {  
      const file = event.target.files[0];  
      if (file) {  
        const reader = new FileReader();  
        reader.onload = (e) => {  
          this.imageUrl = e.target.result; 
        };  
        reader.readAsDataURL(file);
        this.URL='http://127.0.0.1:3000/public/images/'+file.name;  
      }  
    },  
    uploadImage() {  
      if (this.imageUrl) {  
       const avatar=this.URL;
       const userId=this.$store.state.user.id;
       userHttp.changeAvatar({avatar, userId})  
                .then(res => {  
                    if (res.code !== 200) {  
                        this.$message.error(res.message); 
                    } else {  
                        this.$message.success(res.message);  
                        this.modalVisible = false;
                        this.$router.push({ name: 'profile' });
                    }  
                })  
                .catch(error => {  
                    console.error('Error changing avatar:', error);  
                    this.$message.error('Failed to change avatar.');  
                });  
      } else {  
        alert('请先选择图片！');  
      }  
    },
    reg(){
      this.$router.push({ name: 'profile' });
    }  
  }  
};  
</script>  
  
<style scoped>  
.avatar-container {  
  display: flex;  
  flex-direction: column;  
  align-items: center;  
  padding: 40px;   
  border: 1px solid #ccc;  
  border-radius: 12px;  
  box-shadow: 0 6px 12px rgba(0,0,0,0.1);  
  max-width: 800px;   
  margin: 50px auto;  
}  
  
.file-input {  
  margin-bottom: 30px;  
}  
  
.upload-btn, .back-btn {  
  padding: 14px 28px; 
  font-size: 20px; 
  border-radius: 8px;  
  margin-top: 30px;  
}  
  
.preview-container {  
  margin-top: 40px;  
}  
  
.preview-img {  
  max-width: 500px;   
  height: auto; 
  border-radius: 12px;   
  box-shadow: 0 6px 12px rgba(0,0,0,0.1);   
}  
  
.info-text {  
  text-align: center;  
  color: #666;  
  margin-top: 40px;   
} 
</style>