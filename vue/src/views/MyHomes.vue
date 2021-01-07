<template>
  <div>
    <div class="sidenavigation">
      <a><router-link :to="{ name: 'profile' }">My Profile</router-link></a>
      <!-- <router-link :to="{ name: 'myhomes' }"
        ><button>My Homes</button></router-link
      > -->
      <a><router-link :to="{ name: 'addhome' }">Add Home</router-link></a>
      <!-- <router-link :to="{ name: 'repairs' }"
        ><button>My Repairs</button></router-link
      > -->
      <!-- <router-link :to="{ name: 'appliances' }"
        ><button>My Appliances</button></router-link -->
      <!-- > -->
    </div>
    <Main>
      <!-- <h1>My Homes</h1> -->
      <div class="show_list">
        <each-home
          class="Homes-Button"
          v-bind:home="home"
          v-for="home in listOfProperties"
          v-bind:key="home.homeid"
        />
      </div>

      <!-- <img src="https://images.pexels.com/photos/106399/pexels-photo-106399.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500" alt="" v-bind:home="home" v-for="home in listOfProperties" v-bind:key="home.homeid">
     -->
      <!-- <button v-on:click="getAllHomes()" class="Homes-Button">
        Show My Homes
      </button> -->
      <!-- CHANGE BUTTON TO TOGGLE between Show My Homes and Hide My Homes -->
    </Main>
  </div>
</template>

<script>
import EachHome from "../components/EachHome.vue";
import UserService from "../services/UserService";
export default {
  components: { EachHome },
  name: "myhomes",
  data() {
    return {
      listOfProperties: [],
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    getAllHomes() {
      UserService.getHomes().then((response) => {
        this.listOfProperties = response.data;
      });
    },
  },

  created() {
    this.getAllHomes();
    // UserService.getHomes().then((response) => {
    //   this.listOfProperties = response.data;
    // });
  },
};
</script>

<style scoped>
.show_list{
  display: block;
  margin-top: 50px;
}
/* .sidenav {
  /* height: 75%; 
  width: 250px; /* Set the width of the sidebar */
  /* position: relative; */
  /* z-index: 10; Stay on top */
  /* top: 0.4px; Stay at the top .4px  */
  /* left: 0; */
  /* padding: 0;
  margin: 0;
  overflow: hidden;
  background-color: #ffe3ae; */
  /* overflow-x: hidden; Disable horizontal scroll */
  /* padding-top: 80px; */
  /* border-right-color: rgb(175, 122, 15);
  border-right-width: 3px;
} */ 
/* .Homes-Button { */
  /* display: block; */
  /* margin-bottom: 20px; */
  /* justify-items: center;
   position: relative;
  justify-self: center;
  display: flex;
  flex-basis: 100%;
  flex-direction: column;
  justify-content: space-between; */
  /* border: solid;
  height: 300px;
  width: 300px;
  /* border-radius: 15px; */

.sidenavigation {
  height: auto; /* Full-height: remove this if you want "auto" height */
  width: 300px; /* Set the width of the sidebar */
  position: fixed; /* Fixed Sidebar (stay in place on scroll) */
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

/* Style page content */
Main {
  margin-left: 160px; /* Same as the width of the sidebar */
  padding: 0px 10px;
}

/* On smaller screens, where height is less than 450px, change the style of the sidebar (less padding and a smaller font size) */
@media screen and (max-height: 450px) {
  .sidenavigation {padding-top: 15px;}
  .sidenavigation a {font-size: 18px;}
}

main {
  /* display: flex; */
  display: inline-block;
  position: relative;
  justify-self: center;
  display: flex;
  flex-basis: 100%;
  flex-direction: column;
  /* justify-self: center; */
}
.alert-danger {
  text-align: center;
  color: rgb(138, 48, 48);
}

.user_profile {
  /* width: 100%; */
  padding: 12px 20px;
  /* margin: 30px 0 0 60px; */
  display: inline-block;
  /* border: 1px solid #ccc;
  border-radius: 4px; */
  box-sizing: border-box;
  margin: 0 auto;
  max-width: 320px;
  /* margin: 0 auto;
    max-width: 320px;
    display: inline-block;
    padding: 10px; */
  position: relative;
  justify-self: center;
  display: flex;
  flex-basis: 100%;
  flex-direction: column;
  /* justify-content: space-between; */
}
</style>