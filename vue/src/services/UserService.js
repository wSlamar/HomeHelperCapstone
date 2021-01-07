import axios from 'axios';

// const http = axios.create({
//     baseURL: 'https://localhost:44315'
// });

export default {
    getUser() {
        return axios.get('/profile')
    },
    updateUser(user) {
        return axios.put('/profile', user)
    },
    getUsernames() {
        return axios.get('/register')
    },


    addHome(home) {
        return axios.post('/addhome', home)
    },
    getHomes() {
        return axios.get('/myhomes')
    },
    getHome(homeId) {
        return axios.get(`/homedetail/${homeId}`)
    },
    updateHome(home) {
        return axios.put(`/homedetail/${home.homeId}`, home)
    },
    deleteHome(home) {
        return axios.delete(`/homedetail/${home.homeId}`)
    },

    addRepair(repair) {
        return axios.post(`/repairs/${repair.homeId}`, repair)
    },
    getRepairs(homeId) {
        return axios.get(`/repairs/${homeId}`)
    },
    getRepair(id) {
        console.log("Hello!");
        return axios.get((`map/${id}`))
    },
    deleteRepair(repairId) {
        return axios.delete(`/repairs/${repairId}`)
    },
    updateRepair(repair) {
        return axios.put(`/repairs/${repair.homeId}`, repair)
    },
    addAppliance(appliance) {
        return axios.post(`/appliances/${appliance.homeId}`, appliance)
    },
    getAppliance(id) {
        console.log("Hello!");
        return axios.get(`map/${id}`)
    },
    getAppliances(homeId) {
        return axios.get(`/appliances/${homeId}`)
    },
    updateAppliance(appliance) {
        return axios.put(`/appliances/${appliance.homeId}`, appliance)
    },
    deleteAppliance(applianceId) {
        return axios.delete(`/appliances/${applianceId}`)
    },

    getStores(homeId) {
        return axios.get(`/stores/${homeId}`);
    },
    addStore(store) {
        return axios.post(`/stores/${store.homeId}`, store)
    },
    updateStore(store) {
        return axios.put(`/stores/${store.homeId}`, store)
    },
    deleteStore(storeId) {
        return axios.delete(`/stores/${storeId}`);
    },


    getServicers(homeId) {
        return axios.get(`/services/${homeId}`);
    },
    addServicer(servicer) {
        return axios.post(`/services/${servicer.homeId}`, servicer)
    },
    updateServicer(servicer) {
        return axios.put(`/services/${servicer.homeId}`, servicer)
    },
    deleteServicer(servicerId) {
        return axios.delete(`/services/${servicerId}`);
    },
}  
