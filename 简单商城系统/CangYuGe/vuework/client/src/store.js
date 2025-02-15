import Vue from 'vue'
import Vuex from 'vuex'

import http from "@/api/user"

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        modalStatus: {
            visible: false,
            componentName: "register",
        },
        user: null,
    },
    mutations: {
        changeModalStatus(state, { componentName, visible }) {
            if ( componentName !== undefined ) state.modalStatus.componentName = componentName
            if ( visible !== undefined ) state.modalStatus.visible = visible
        },
        setUser(state, user) {
            state.user = user;
        },
        clearUser(state) {  
            state.user = null;  
        },
    },
    actions: {
        getUser({ commit }) {
            http.userProfile()
                .then(res => {
                    if ( res.code == 200 ) commit("setUser", res.data)
                })
        },
        logout({ commit }) {  
            // 清除用户状态  
            commit('clearUser');  
        },
    },
    modules: {
    }
})