<template>
  <div>
    <div class="sidenavigation" id="side_nav">
      <a><router-link :to="{ name: 'profile' }">My Profile</router-link></a>
      <a
        ><router-link
          :to="{
            name: 'myhomes',
            params: { id: this.$store.state.user.userId },
          }"
          >My Homes</router-link
        ></a
      >
      <a
        ><router-link :to="{ name: 'homedetail' }"
          >Current Home</router-link
        ></a
      >
      <a
        ><router-link :to="{ name: 'repairs', params: { id: homeId }  }"
          >My Repairs</router-link
        ></a
      >
      <a
        ><router-link :to="{ name: 'appliances', params: { id: homeId }}"
          >My Appliances</router-link
        ></a
      >
    </div>
    <div id="map">
    <h1>Shopping/Service Map</h1>
    <h2>
      Here are the results for
      {{
        this.$route.params.id.includes("a")
          ? `a new ${urlItem}`
          : `a new ${urlItem} project`
      }}
    </h2>
    <iframe
      width="600"
      height="450"
      frameborder="0"
      style="border: 0"
      :src="url"
    >
    </iframe>

    <div id="list">
      <div id="title">
        {{
          this.$route.params.id.includes("a")
            ? "Preferred Store"
            : "Preferred Vendor"
        }}
      </div><br>
      <div id="box" v-for="item in items" v-bind:key="item.vendorId">
        <div>Name: {{ item.vendorName }}</div>
        <div>Phone Number: {{ item.phone }}</div>
        <div v-show="item.vendoremail">Email: {{ item.vendoremail }}</div>
        <br>
      </div>
    </div>
    </div>
  </div>
</template>

<script>
import UserService from "../services/UserService";
export default {
  name: "shoppingmap",
  data() {
    return {
      itemId: "",
      items: [],
      urlItem: "",
      urlZip: "",
      url: "",
      homeId:"",
    };
  },
  created() {
    this.itemId = this.$route.params.id;
    if (this.$route.params.id.includes("a")) {
      UserService.getAppliance(this.itemId).then((response) => {
        this.items = response.data;
        this.urlZip = this.items[0].zip;
        this.urlItem = this.items[0].name;
        this.homeId = this.items[0].homeId;
        this.url = `https://www.google.com/maps/embed/v1/search?key=AIzaSyD0Jhpoz8tC4fHqUxYGmf61Jxg84T62_2s&q=appliance+store+${this.urlItem},${this.urlZip}`;
      });
    } else {
      UserService.getAppliance(this.itemId).then((response) => {
        this.items = response.data;
        this.urlZip = this.items[0].zip;
        this.urlItem = this.items[0].name;
        this.homeId = this.items[0].homeId;
        this.url = `https://www.google.com/maps/embed/v1/search?key=AIzaSyD0Jhpoz8tC4fHqUxYGmf61Jxg84T62_2s&q=${this.urlItem}+servie,${this.urlZip}`;
      });
    }
    
  },
};
</script>

<style>
#title {
  font-size: 32px;
  padding: 14px;
}
#map {
  padding-left: 270px;
}
h1 {
  text-align: center;
  text-emphasis: none;
  font-size: 60px;
  padding-bottom: 20px;
  padding-top: 20px;
  /* /* text-decoration: underline; */
  /* text-decoration-style: dotted; */ 
  /* border-bottom: 5px dotted rgb(195, 145, 45); */
}

iframe {
  display: flex;
  justify-content: left;
  margin: auto;
}
body {
  height: 100%;
}
h1,
h2 {
  text-align: center;
}
#list {
  margin: auto; 
  text-align: center;
  width: 300px;
  margin-top: 30px;
}
#box{
  border: solid;
  border-radius: 20px;
  padding-top: 15px;  
  margin-bottom: 15px;
}

.sidenavigation {
  height: auto; /* Full-height: remove this if you want "auto" height */
  width: 300px; /* Set the width of the sidebar */
  position: fixed; /*Fixed Sidebar (stay in place on scroll)*/
  z-index: 1; /* Stay on top */
  top: 380px; /* Stay at the top */
  left: 73px;
  background-color: rgba(112, 109, 109, 0.287); /* Black */
  overflow-x: hidden; /* Disable horizontal scroll */
  padding-top: 20px;
  padding-bottom: 20px;
}

/* The navigation menu links */
.sidenavigation a {
  padding: 10px 8px 8px 35px;
  text-decoration: none;
  font-size: 25px;
  color: rgb(195, 145, 45);
  display: block;
}

/* When you mouse over the navigation links, change their color */
.sidenavigation a:hover {
  color: #f1f1f1;
}
</style>