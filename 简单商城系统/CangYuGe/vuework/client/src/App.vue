<template>
  <div id="app">
    <tan-site-header v-if="!$route.meta.hideHeader"></tan-site-header>
<el-container style="height: 500px; border: 1px solid #eee" >
  <el-aside width="200px" style="background-color: rgb(238, 241, 246)" v-if="!$route.meta.hideNav">
    <el-menu :default-openeds="['1', '3']">
      
      <el-submenu index="2">
        <template slot="title"><i class="el-icon-menu"></i>商品分类</template>
        <el-menu-item-group>
          <template slot="title">电子设备</template>
          <el-menu-item index="2-1"><router-link :to="{ name: 'category', params: {id: 1, name: 手机} }">
                        手机
                    </router-link></el-menu-item>
          <el-menu-item index="2-2"><router-link :to="{ name: 'category', params: {id: 3, name: 平板电脑} }">
                        平板电脑
                    </router-link></el-menu-item>
        </el-menu-item-group>
        <el-menu-item-group title="日常用品">
          <el-menu-item index="2-3"><router-link :to="{ name: 'category', params: {id: 2, name: 手表} }">
                        手表
                    </router-link></el-menu-item>
        </el-menu-item-group>
        <el-submenu index="2-4">
          <template slot="title"><router-link :to="{ name: 'category', params: {id: 4, name: 衣服} }">
                        衣服
                    </router-link></template>
          <el-menu-item index="2-4-1">帽子</el-menu-item>
          <el-menu-item index="2-4-2">上衣</el-menu-item>
          <el-menu-item index="2-4-3">裤子</el-menu-item>
          <el-menu-item index="2-4-4">内衣</el-menu-item>
        </el-submenu>
      </el-submenu>
      <el-submenu index="1">
        <template slot="title"><i class="el-icon-message"></i>站内信</template>
        <el-menu-item-group>
          <el-menu-item index="1-1"><router-link :to="{ name: 'feedback' }">
                    问题反馈</router-link></el-menu-item>
          <el-menu-item index="1-2"><router-link :to="{ name: 'coupons' }">
                    优惠券领取</router-link></el-menu-item>
        </el-menu-item-group>
      </el-submenu>
      <el-submenu index="3">
        <template slot="title"><i class="el-icon-setting"></i>相关内容</template>
        <el-menu-item-group>
          <el-menu-item index="3-1"><router-link :to="{ name: 'aboutus' }">
            关于我们</router-link></el-menu-item>
          <el-menu-item index="3-2"><router-link :to="{ name: 'helppage' }">
            帮助文档</router-link></el-menu-item>
        </el-menu-item-group> 
      </el-submenu>
    </el-menu>
  </el-aside>
  <el-container>
  <el-main>
        <transition name="app-fade">
            <router-view />
        </transition>
        
    </el-main>

</el-container>

</el-container>

</div>
  </template>
  
  <script>
import siteHeader from "@/components/site-header"

export default {
    name: "App",
    components: { "tan-site-header": siteHeader, }
}
  </script>
  
<style>
.app-fade-enter-active {
    transition: all .3s ease;
}

.app-fade-leave-active {
    transition: all .3s ease;
}

.app-fade-enter, 
.app-fade-leave-to {
    transform: translateX(100vw);
    opacity: 0;
}

body {
    background-color: #F5F5F5;
}

ul {
    list-style: none;
}

.container {
    width: 1226px;
    margin: 0 auto;
}

.line {
    margin-top: 12px;
    border-bottom: 1px solid #e0e0e0;
}

em, i {
    font-style: normal;
}

a {
    text-decoration-line: none;
}

input {
    outline: none;
}
.el-aside {
  color: #333;
  height:90vh
}

.el-main {
        background-color: #E9EEF3;
        color: #333;

        height: 90vh;
}
.el-container {   
    height: 100%;    
  }
</style>
