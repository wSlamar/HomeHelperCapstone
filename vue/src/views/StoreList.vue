<template>
  <div id="store_list">
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

    <!-- <div id="empty"></div>   -->
  
    <div id="content">
      <h1>List of Stores</h1>
      <store
        v-bind:store="store"
        v-for="store in listOfStores"
        v-bind:key="store.vendorId"
      />
    </div>

    <div class="button-container">
      <button @click="showAddForm">
        {{ showForm ? "Cancel" : "Add Store" }}
      </button>
    </div>

    <div id="show_hide" v-show="showForm">
      <form @submit.prevent="AddThisStore">
        <div class="form-element">
          <label for="storename">Store Name: </label>
          <input
            type="text"
            id="storename"
            class="form-control"
            placeholder="Store Name #xxxx"
            v-model="newStore.VendorName"
            required
          />
        </div>
        <div class="form-element">
          <label for="storephone">Store Phone: </label>
          <input
            type="text"
            id="storephone"
            class="form-control"
            placeholder="xxx-xxx-xxxx"
            v-model="newStore.Phone"
            required
          />
        </div>
        <div class="form-element">
          <label for="storenotes">Store Notes: </label>
          <input
            type="text"
            id="storenotes"
            class="form-control"
            placeholder="Store Notes"
            v-model="newStore.Notes"
            required
          />
        </div>
        <br />

        <button class="btn-add" type="submit">
          Add This Store
        </button>
      </form>
    </div>
  </div>
</template>

<script>
import Store from "../components/Store.vue";
import UserService from "../services/UserService";
export default {
  components: { Store },
  name: "storelist",
  data() {
    return {
      homeId: 0,
      listOfStores: [],
      showForm: false,
      newStore: {
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

    AddThisStore() {      
      UserService.addStore(this.newStore).then((response) => {
        if (response.status === 201) {
          alert("Congratulations! You have added a new store.");
          this.startUp();
          this.showForm = false;
        }
      });     
    },

    startUp() {      
      this.homeId = parseInt(this.$route.params.homeId);
      this.newStore.homeId = this.homeId;
      UserService.getStores(this.homeId).then((response) => {
        this.listOfStores = response.data;
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
  margin-left: 933px;
  padding-top: 20px;
}

h1 {
  text-align: center;
  text-emphasis: none;
  font-size: 60px;
  padding-bottom: 20px;
  padding-left: 120px;
  /* text-decoration: underline; */
}

#show_hide {
margin-left: 100px;

}
.btn-add {
  margin-left: 74px;
}
#store_list{
  display: flex;
  flex-direction: column
}
button {
  margin: auto;
}
#content{
  padding-top: 60px;
  margin: auto;
}
/* #empty{
  min-height: 1500px;
} */
</style>