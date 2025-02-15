<template>  
    <div id="app">  
      <h1>优惠卷领取页面</h1>  
      <div v-for="coupon in coupons" :key="coupon.id" class="coupon-item">  
        <div class="coupon-content center-content">
        <p>{{ coupon.name }} - 剩余数量：{{ coupon.remaining }}</p>  
        <button class="claim-button" @click="claimCoupon(coupon)">领取</button>  
      </div> 
      </div> 
      <div v-if="showSuccessMessage" class="success-message center-text">领取成功！</div>  
    </div>  
  </template>  
    
  <script>  
  export default {  
    name: 'App',  
    data() {  
      return {  
        coupons: [  
          { id: 1, name: '满20减3', remaining: 10 },  
          { id: 2, name: '满50减10', remaining: 10 },  
          { id: 3, name: '满100减20', remaining: 10 },
          { id: 4, name: '满200减50', remaining: 10 },
          { id: 5, name: '满400减100', remaining: 10 },
          { id: 6, name: '无门槛5', remaining: 10 },
          { id: 7, name: '无门槛10', remaining: 10 },
          { id: 8, name: '无门槛20', remaining: 10 }
        ],  
        showSuccessMessage: false,  
      };  
    },  
    methods: {  
      claimCoupon(coupon) {  
        if (coupon.remaining > 0) {  
          coupon.remaining--;   
          this.showSuccessMessage = true;   
    
          setTimeout(() => {  
            this.showSuccessMessage = false; 
          }, 2000);  
        } else {    
          alert('优惠卷已领完！');
        }  
      },  
    },  
  };  
  </script>  
    
  <style>  
  #app {  
    text-align: center;  
    margin-top: 50px;  
    min-height: 100vh;   
  background-color: #f8f9fa;  
  }  
    
  .coupon-item {  
    margin: 10px;  
    padding: 10px;  
    border: 1px solid #ccc;  
    display: inline-block;  
    width: 300px;  
    text-align: left;
    background-color: #fff;    
  } 
  .center-text {  
  text-align: center;  
}  
  
.claim-button {  
  margin-top: 10px; 
}   
    
  .success-message {  
    color: green;  
    margin-top: 20px;  
  }  
  </style>