<template>
  <div class="content">
    <router-link :to="{ name: 'homedetail', params: { id: home.homeId } }">
      <div class="home_card">
        <img
          :src="home.picUrl"
          alt=""
          class="homeImage"
        />

        <div class="house_info">
          <div>Street Address: <br>{{ home.streetAddress }}</div>
          <div>City: {{ home.city }}</div>
          <div>State: {{ home.state }}</div>
          <div>Zipcode: {{ home.zip }}</div>
        </div>
      </div>
    </router-link>
  </div>
</template>

<script>
// import UserService from "../services/UserService";
export default {
  name: "each-home",
  props: {
    home: Object,
  },
  data() {
    return {
      // home: [],
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    //     getSingleHome() {
    //     UserService.getHome()
    //     .then(response => {
    //         this.home = response.data;
    //     })
    // }
  },
};
</script>
    
<style>
img{
  margin-right: 20px;
}
.home_card {
  display: flex;
  flex-direction: rows;
  align-items: center;
  /* text-align: right; */
  margin: auto;
  border: solid;  
  border-radius: 15px;
  width: 500px;
  padding: 20px; 
  background: rgb(206, 228, 226);
  font-size: 16px;
  
}

.content {
  padding: 20px;
}
.house_info {
  /* display: block; */
  /* align-items: center; */
  margin: auto;
  /* line-height: 1.5; */
  }

.homeImage {
  /* display: block; */
  
  /* flex-grow: 1; */
  width: 50%;
}
</style>