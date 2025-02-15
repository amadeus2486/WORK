import axios from "./axios"

const register = ({ username, password, email }) => {
    return axios.request({
        url: "/user/register",
        method: "post",
        data: { username, password, email }
    })
}

const login = ({username, password}) => {
    return axios.request({
        url: "/user/login",
        method: "post",
        data: { username, password }
    })
}

const userProfile = () => {
    return axios.request({
        url: "/user/profile"
    })
}

const changePassword = ({ username, oldPassword, newPassword }) => {  
    return axios.request({  
        url: "/user/changePassword",  
        method: "post",  
        data: { username, oldPassword, newPassword }  
    });  
}

const changeAvatar = ({ avatar,userId }) => {  
    return axios.request({  
        url: "/user/changeAvatar", 
        method: "post",  
        data: { avatar,userId} 
    });  
};

export default {
    register,
    login,
    userProfile,
    changePassword,
    changeAvatar
}

