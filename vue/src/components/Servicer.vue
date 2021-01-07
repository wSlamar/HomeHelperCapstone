<template>
  <div id="servicer_card">
    <!-- <router-link :to="{ name: 'eachstore', params: { homeId: store.homeId } }"> -->
    <div>{{ servicer.vendorName }}</div>
    <div>{{ servicer.phone }}</div>
    <div>{{ servicer.email }}</div>
    <div>{{ servicer.specialty }}</div>
    <div>{{ servicer.notes }}</div>
    <div class="buttons">
      <button @click="showEditForm">Edit</button>
      <button @click="DeleteThisServicer">Delete</button>
    </div>
    <div id="show_hide" v-show="showForm">
      <form>
        <div class="form-element">
          <label for="servicername">Servicer Name: </label>
          <input
            type="text"
            id="servicername"
            class="form-control"
            placeholder="Servicer Name #xxxx"
            v-model="editServicer.Vendorname"
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
            v-model="editServicer.Phone"
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
            v-model="editServicer.Email"
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
            v-model="editServicer.Specialty"
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
            v-model="editServicer.Notes"
            required
          />
        </div>
        <br />

        <button
          class="button"
          type="submit"
          @click="UpdateThisServicer"
          @submit.prevent="UpdateThisServicer"
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
  name: "servicer",
  props: {
    servicer: Object,
  },
  data() {
    return {
      editServicer: {
        vendorId: 0,
      },
      showForm: false,
    };
  },

  created() {
    this.editServicer.vendorId = this.servicer.vendorId;
  },

  methods: {
    showEditForm() {
      if (this.showForm == false) {
        this.showForm = true;
      } else {
        this.showForm = false;
      }
    },

    UpdateThisServicer() {
      this.editServicer.homeId = this.servicer.homeId;
      UserService.updateServicer(this.editServicer).then((response) => {
        if (response.status === 200) {
          alert("You have updated this Servicer.");
          this.showForm = false;
          this.$router.push(`/myhomes/${this.servicer.homeId}`);
        }
      });
    },

    DeleteThisServicer() {
       if (!confirm("Are you sure you want to delete this Servicer?")) {
          return;
        }
      UserService.deleteServicer(this.editServicer.vendorId).then((response) => {
        if (response.status === 200) {
          alert("You have deleted this Servicer.");
          this.showForm = false;          
          location.reload();
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
  margin-bottom: 0;
  display: flex;
  justify-content: space-around;
}

button {
  width: 160px;
  height: 36px;
  margin: auto;
  margin-top: 20px;
  color: black;
}
#servicer_card {
  border: solid;
  border-radius: 20px;
  text-align: center;
  margin: auto;
  width: 400px;
  padding: 20px;
  margin-top: 20px;
  margin-bottom: 20px;
  margin-left: 160px;
}
</style>