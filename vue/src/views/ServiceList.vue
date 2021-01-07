<template>
  <div id="service_list">
    <div class="sidenavigation" id="side_nav">
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
        ><router-link :to="{ name: 'repairs', params: { id: homeId } }"
          >My Repairs</router-link
        ></a
      >
      <a
        ><router-link :to="{ name: 'appliances', params: { id: homeId } }"
          >My Appliances</router-link
        ></a
      >
       <a
        ><router-link :to="{ name: 'homedetail', params: { id: homeId } }"
          >Current Home</router-link
        ></a
      >
    </div>

    <div id="empty"></div>  

    <div id="content">
      <h1>List of Servicers</h1>
      <servicer
        v-bind:servicer="servicer"
        v-for="servicer in listOfServicers"
        v-bind:key="servicer.vendorId"
      />
    </div>

    <div class="button-container">
      <button @click="showAddForm">
        {{ showForm ? "Cancel" : "Add Servicer" }}
      </button>
    </div>

    <div id="show_hide" v-show="showForm">
      <form @submit.prevent="AddThisServicer">
        <div class="form-element">
          <label for="servicername">Servicer Name: </label>
          <input
            type="text"
            id="servicername"
            class="form-control"
            placeholder="Servicer Name #xxxx"
            v-model="newServicer.VendorName"
            required
          />
        </div>
        <div class="form-element">
          <label for="servicerphone">Servicer Phone: </label>
          <input
            type="text"
            id="servicerphone"
            class="form-control"
            placeholder="xxx-xxx-xxxx"
            v-model="newServicer.Phone"
            required
          />
        </div>
          <div class="form-element">
          <label for="serviceremail">Servicer Email: </label>
          <input
            type="text"
            id="serviceremail"
            class="form-control"
            placeholder="joefixit@homedepot.com"
            v-model="newServicer.Email"
            required
          />
        </div>
          <div class="form-element">
          <label for="servicerspecialty">Servicer Specialty: </label>
          <input
            type="text"
            id="servicerspecialty"
            class="form-control"
            placeholder="Plummer"
            v-model="newServicer.Specialty"
            required
          />
        </div>
        <div class="form-element">
          <label for="servicernotes">Servicer Notes: </label>
          <input
            type="text"
            id="servicernotes"
            class="form-control"
            placeholder="Servicer Notes"
            v-model="newServicer.Notes"
            required
          />
        </div>
        <br />

        <button class="btn btn-lg btn-primary btn-block" type="submit">
          Add This Servicer
        </button>
      </form>
    </div>
  </div>
</template>

<script>
import Servicer from "../components/Servicer.vue";
import UserService from "../services/UserService";
export default {
  components: { Servicer },
  name: "servicerlist",
  data() {
    return {
      homeId: 0,
      listOfServicers: [],
      showForm: false,
      newServicer: {
        homeId: 0,
      },
    };
  },

  methods: {
    showAddForm() {
      if (this.showForm == false) {
        this.showForm = true;
      } else {
        this.showForm = false;
      }
    },

    AddThisServicer() {      
      UserService.addServicer(this.newServicer).then((response) => {
        if (response.status === 201) {
          alert("Congratulations! You have added a new Servicer.");
          this.startUp();
          this.showForm = false;
          this.startUp()
        }
      });     
    },

    startUp() {      
      this.homeId = parseInt(this.$route.params.homeId);
      this.newServicer.homeId = this.homeId;
      UserService.getServicers(this.homeId).then((response) => {
        this.listOfServicers = response.data;
      });
    },
  },
  created() {
    this.startUp();
  },
};
</script>

<style scoped>
button {
  width: 160px;
  height: 36px;
  margin: auto;
  margin-top: 20px;
  color: black;
}

.button-container {
  /* margin-left: 120px; */
  margin-left: 927px;
}

h1 {
  text-align: center;
  text-emphasis: none;
  font-size: 60px;
  padding-bottom: 20px;
  padding-left: 120px;
  /* text-decoration: underline; */
}

#service_list{
  display: flex;
  flex-direction: column
}
#content{
  margin: auto;
}
#empty{
  min-height: 150px;
}

#show_hide {
margin-left: 100px;
}

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
  /* padding-left: -5px; */
  /* padding-right: 10px; */
}
</style>