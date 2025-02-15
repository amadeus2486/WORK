<template>  
    <div class="help-page">  
      <h1 class="title">帮助文档</h1>  
    
      <div class="section" id="faq">  
        <h2 class="section-title">常见问题解答(FAQ)</h2>  
        <div class="faq-list">  
          <div class="faq-item" v-for="(question, index) in faqQuestions" :key="index">  
            <h3 class="question">{{ question.title }}</h3>  
            <p class="answer">{{ question.answer }}</p>  
          </div>  
        </div>  
      </div>  
     
      <div class="section" id="guide">  
        <h2 class="section-title">使用指南</h2>  
        <p class="guide-content">第一步：用户注册</p> 
        <p class="guide-content">点击页面右上角注册后，跳转页面，按照注册指示完成注册。</p>
        <p class="guide-content">第二步：用户登录</p>
        <p class="guide-content">点击页面右上角登录后，跳转页面，根据注册信息填写完成登录。</p>
        <p class="guide-content">第三步：挑选商品</p>
        <p class="guide-content">浏览商品，看到心仪商品后点击进入详情页。</p>
        <p class="guide-content">第四步：加入购物车</p>
        <p class="guide-content">选择商品类型并点击加入购物车。</p>
        <p class="guide-content">第五步：填写收货地址和选择付款方式</p>
        <p class="guide-content">选择预留的收获地址，选择需要的付款方式进行支付。</p>
        <p class="guide-content">第六步：提交订单</p>
        <p class="guide-content">完成支付后，检查订单信息，无误后提交订单，等待商家发货即可。</p>
      </div>  
    
      <div class="section" id="contact">  
        <h2 class="section-title">联系我们</h2>  
        <ul class="contact-list">  
          <li><strong>邮箱：</strong>Yoshimura@fake.com</li>  
          <li><strong>电话：</strong>xxx-xxxx-xxx</li>  

        </ul>  
      </div>  
    </div>  
  </template>  
    
  <script>  
  export default {  
    data() {  
      return {  
        faqQuestions: [  
          { title: '1)如何使用网站？', answer: '网址的大部分功能都要在登录之后才能正常运行，详细使用方法见下面使用指南。' },  
          { title: '2)产品是否为正品？', answer: '藏雨阁诚信经营，与众多知名品牌厂商、渠道商合作，对产品的进货渠道要求很高，一定确保所有产品为正品。创立之初就建立了严格的采购管理体系，所有商品都经过了严格的质量检测，以确保您能够得到称心满意的商品。同时，为最大限度的确保您的利益，我们还提供了15天无条件退换货服务，真正做到无风险购物。综上所述，敬请放心购物。' },  
          { title: '3)不注册可以购买吗？', answer: '对不起，不注册无法购买，原因是这样的：如果您不注册，在系统中就无法保存您的订单，如果出现售后问题，将会给您造成非常大的麻烦，并且您的购物积分也无法保存，有些会员特惠商品您也无法选购，因此我们建议您注册后再购买。' }, 
          { title: '4)什么是15天无条件退换货啊，不满意真的可以退吗？', answer: '可以的，15天无条件退换货是我们对您的承诺。只要您保持商品、配件及外包装为出售时的原状，即不影响二次销售的情况下，均享受15天无条件退换货服务。但是如果您损坏了商品的外包装、配件，或是由于使用不当，而非质量问题造成商品损坏的，恕不享受该服务，敬请谅解。退换双程邮费自理，不接收到付件。' },
          { title: '5)我拿到的商品发错了，该怎么换啊？', answer: '商品错发请第一时间提供照片，待我们核实后，我们提供换货商品寄回地址，退回邮费请顾客先垫付，不接收到付件，收到换货后，我们将换货和您垫付的邮费一起寄给您，具体事宜请拨打我们的客户服务热线：xxx-xxxx-xxx ,我们将提供令您满意的解决方案。' },
          { title: '6)怎么我订的货，到现在还没到？', answer: '有可能您的订货在物流过程中，相信很快就能送达到您手中。如果超过1周没有收到货物，我们将与物流部门进行联系，帮助您协商解决此类问题。您对订单有任何疑问，请联系客服进行咨询。' },  
        ]  
      };  
    }  
  }  
  </script>  
    
  <style scoped>  
  .help-page {  
    padding: 20px;  
    max-width: 800px;  
    margin: 40px auto;  
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);  
    border-radius: 8px;  
    background-color: #fff;  
  }  
    
  .title {  
    color: #333;  
    text-align: center;  
  }  
    
  .section {  
    margin-top: 20px;  
    padding: 10px;  
    border-top: 1px solid #eee;  
  }  
    
  .section:first-child {  
    border-top: none;  
  }  
    
  .section-title {  
    color: #007bff;  
    font-size: 1.25em;  
    margin-bottom: 10px;  
  }  
    
  .faq-list {  
    list-style-type: none;  
    padding: 0;  
  }  
    
  .faq-item {  
    margin-bottom: 15px;  
  }  
    
  .question {  
    font-weight: bold;  
    cursor: pointer; 
  }  
    
  .answer {  
    margin-top: 5px;  
    color: #666;  
  }  
    
  .guide-content {  
    line-height: 1.6;  
    color: #555;  
  }  
    
  .contact-list {  
    list-style-type: none;  
    padding: 0;  
  }  
    
  .contact-list li {  
    margin-bottom: 5px;  
  }  
    
  .contact-list strong {  
    color: #333;  
  }  
  </style>