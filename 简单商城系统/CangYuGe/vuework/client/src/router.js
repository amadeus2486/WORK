import Vue from 'vue';
import VueRouter from 'vue-router';
import store from "@/store";
 
Vue.use(VueRouter);
 
// 定义路由
const routes = [
  {  
    path: "/",
    name: "index",
    component: () => import(/* webpackChunkName: "index" */ "@/views/index.vue")
  },
  {
    path: "/category/:id",
    name: "category",
    component: () => import(/* webpackChunkName: "product" */ "@/views/category.vue")
},
{
  path: "/product/:id",
  name: "productDetail",
  component: () => import(/* webpackChunkName: "product" */ "@/views/product-detail")
},
{
  path: "/cart",
  name: "cart",
  meta: { requiresLogin: true },
  component: () => import(/* webpackChunkName: "cart" */ "@/views/cart")
},
{
  path: "/buy",
  name: "buy",
  meta: { requiresLogin: true },
  component: () => import(/* webpackChunkName: "buy" */ "@/views/buy")
},
{
  path: "/orderList",
  name: "orderList",
  meta: { requiresLogin: true },
  component: () => import(/* webpackChunkName: "orderList" */ "@/views/order-list")
},
{
  path: "/feedback",
  name: "feedback",
  meta: { requiresLogin: true },
  component: () => import(/* webpackChunkName: "feedback" */ "@/views/feedback")
},
{
  path: "/coupons",
  name: "coupons",
  meta: { requiresLogin: true },
  component: () => import(/* webpackChunkName: "coupons" */ "@/views/coupons")
},
{
  path: "/aboutus",
  name: "aboutus",
  meta: { requiresLogin: true },
  component: () => import(/* webpackChunkName: "aboutus" */ "@/views/aboutus")
},
{
  path: "/helppage",
  name: "helppage",
  meta: { requiresLogin: true},
  component: () => import(/* webpackChunkName: "helppage" */ "@/views/helppage")
},
{
  path: "/profile",
  name: "profile",
  meta: { requiresLogin: true },
  component: () => import(/* webpackChunkName: "profile" */ "@/views/profile")
},
{
  path: "/cpassword",
  name: "cpassword",
  meta: { requiresLogin: true },
  component: () => import(/* webpackChunkName: "cpassword" */ "@/views/cpassword")
},
{
  path: "/log",
  name: "log",
  meta: { requiresLogin: true ,hideHeader:true , hideNav:true},
  component: () => import(/* webpackChunkName: "log" */ "@/views/log")
},
{
  path: "/reg",
  name: "reg",
  meta: { requiresLogin: true ,hideHeader:true , hideNav:true},
  component: () => import(/* webpackChunkName: "reg" */ "@/views/reg")
},
{
  path: "/agreement",
  name: "agreement",
  meta: { requiresLogin: true ,hideHeader:true , hideNav:true},
  component: () => import(/* webpackChunkName: "agreement" */ "@/views/agreement")
},
{
  path: "/addre",
  name: "addre",
  meta: { requiresLogin: true },
  component: () => import(/* webpackChunkName: "addre" */ "@/views/addre")
},
{
  path: "/cavatar",
  name: "cavatar",
  meta: { requiresLogin: true },
  component: () => import(/* webpackChunkName: "cavatar" */ "@/views/cavatar")
},
];
 
// 创建路由实例
const router = new VueRouter({
  routes // (缩写) 相当于 routes: routes
});

export default router