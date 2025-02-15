import axios from "./axios"

const list = () => {
    return axios.request({
        url: "/contact/list"
    })
}
const createAddress = ({ name, telephone, address, tag, userId }) => {
    return axios.request({
        url: "/contact/createAddress",
        method: "post",
        data: { name, telephone, address, tag, userId }
    })
}

export default {
    list,
    createAddress,
}
