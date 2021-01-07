<template>
  <div id="store_card">
    <!-- <router-link :to="{ name: 'eachstore', params: { homeId: store.homeId } }"> -->
    <div>{{ store.vendorName }}</div>
    <div>{{ store.phone }}</div>
    <div>{{ store.notes }}</div>
    <div class="buttons">
      <button @click="showEditForm">Edit</button>
      <button @click="DeleteThisStore">Delete</button>
    </div>
    <div id="show_hide" v-show="showForm">
      <form>
        <div class="form-element">
          <label for="storename">Store Name: </label>
          <input
            type="text"
            id="storename"
            class="form-control"
            placeholder="Store Name #xxxx"
            v-model="editStore.Vendorname"
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
            v-model="editStore.Phone"
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
            v-model="editStore.Notes"
            required
          />
        </div>
        <br />

        <button
          class="button"
          type="submit"
          @click="UpdateThisStore"
          @submit.prevent="UpdateThisStore"
        >
          Submit Edit
        </button>
      </form>
    </div>
  </div>

  <!-- </router-link> -->
</template>

<script>
import UserService from "@/services/UserService.js";
export default {
  name: "store",
  props: {
    store: Object,
  },
  data() {
    return {
      editStore: {
        vendorId: 0,
        homeId: 0,
      },
      showForm: false,
    };
  },

  created() {
    this.editStore.vendorId = this.store.vendorId;
    this.editStore.homeId = parseInt(this.$route.params.homeId);
  },

  methods: {
    showEditForm() {
      if (this.showForm == false) {
        this.showForm = true;
      } else {
        this.showForm = false;
      }
    },

    UpdateThisStore() {
      this.editStore.homeId = this.store.homeId;
      UserService.updateStore(this.editStore).then((response) => {
        if (response.status === 200) {
          alert("You have updated this store.");
          this.showForm = false;
          location.reload();
        }
      });
    },

    DeleteThisStore() {
       if (!confirm("Are you sure you want to delete this store?")) {
          return;
        }
      UserService.deleteStore(this.editStore.vendorId).then((response) => {
        if (response.status === 200) {
          alert("You have deleted this store.");
          this.showForm = false;
          location.reload();
          // this.$router.push(`/stores/${this.store.homeId}`);
        }
      });
    },
  },
};
</script>

<style>
#show_hide {
  /* margin:auto; */
}
.buttons {
  margin-top: 10px;
  /* margin-bottom: 0; */
  display: flex;
  justify-content: space-around;
}
#store_card {
  border: solid;
  border-radius: 20px;
  text-align: center;
  margin: auto;
  width: 400px;
  padding: 20px;
  margin-top: 20px;
  margin-bottom: 20px;
  margin-left: 140px;
}
</style>