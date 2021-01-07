<template>
  <div>
    <div class="card">
      <div class="top"></div>
      <h2 class="appliance-details">Appliance: {{ appliance.name }}</h2>
      <h2 class="appliance-details">Make: {{ appliance.make }}</h2>
      <h2 class="appliance-details">
        Purchase Date: {{ appliance.purchaseDate }}
      </h2>
      <h2 class="appliance-details">
        Model Number: {{ appliance.modelNumber }}
      </h2>
      <h2 class="appliance-details">
        Serial Number: {{ appliance.serialNumber }}
      </h2>
      <h2 class="appliance-details">Cost: {{ appliance.cost }}</h2>
      <h2 class="appliance-details">
        Warranty Expiration: {{ appliance.warrantyExpiration }}
      </h2>
      <h2 class="appliance-details">
        Delivery Date: {{ appliance.description }}
      </h2>
      <h2 class="appliance-details">
        Notes or description:
        <p class="notes">{{ appliance.description }}</p>
      </h2>
      <h2 class="appliance-details">
        Url or storage location of receipt: {{ appliance.receiptUrl }}
      </h2>

      <div class="buttons">
        <button
          id="showHide"
          class="button"
          v-on:click.prevent="showEditForm"
          v-show="!showForm"
        >
          Edit Appliance
        </button>
        <form v-if="showForm">
          <div class="form-element">
            <label for="appliance-name">Appliance Name:</label>
            <input
              type="text"
              id="appliance-name"
              v-model="editAppliance.name"
            />
          </div>
          <div class="form-element">
            <label for="appliance-make">Appliance Make:</label>
            <input
              type="text"
              id="appliance-make"
              v-model="editAppliance.make"
            />
          </div>
          <div class="form-element">
            <label for="purchase-date">Purchase Date:</label>
            <input
              type="date"
              id="purchase-date"
              placeholder="mm/dd/yyyy"
              v-model="editAppliance.purchaseDate"
            />
          </div>
          <div class="form-element">
            <label for="model-number">Model Number:</label>
            <input
              type="text"
              id="modelNumber"
              v-model="editAppliance.modelNumber"
            />
          </div>
          <div class="form-element">
            <label for="serial-number">Serial Number:</label>
            <input
              type="text"
              id="serialNumber"
              v-model="editAppliance.serialNumber"
            />
          </div>
          <label for="cost">Cost: </label>
          <input
            type="number"
            id="edit-appliance-cost"
            value="1000"
            min="0"
            step="any"
            data-number-to-fixed="2"
            data-number-stepfactor="100"
            data-type="currency"
            class="form-element"
            placeholder="0.00"
            v-model="editAppliance.cost"
          />
          <div class="form-element">
            <label for="warranty">Warranty Expiration:</label>
            <input
              type="date"
              id="warrantyExpiration"
              placeholder="mm/dd/yyyy"
              v-model="editAppliance.warrantyExpiration"
            />
          </div>
          <div class="form-element">
            <label for="warranty">Delivery Date:</label>
            <input
              type="date"
              id="deliveryDate"
              placeholder="mm/dd/yyyy"
              v-model="editAppliance.deliveryDate"
            />
          </div>
          <div class="form-element">
            <label for="receipt">Url or Location of Receipt:</label>
            <input
              type="year"
              id="receipt"
              v-model="editAppliance.receiptUrl"
            />
          </div>
          <div class="form-element">
            <label for="description">Important Details:</label>
            <textarea id="description" v-model="editAppliance.description" />
          </div>

          <button type="button" @click.prevent="updateAppliance">Submit</button>
          <button type="button" value="Cancel" @click="showForm = false">
            Cancel
          </button>
        </form>
        <span> </span>
        <button class="button" v-on:click.prevent="deleteAppliance">
          Delete Appliance
        </button>
        <button class="button">
          <router-link
            :to="{ name: 'map', params: { id: 'a' + appliance.applianceId } }"
            v-bind:item="this.item"
            id="replace"
            >Replace</router-link
          >
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import userService from "@/services/UserService.js";
export default {
  name: "ApplianceCard",
  // data(){
  //     return{
  //         item: [],
  //     }
  // },
  props: {
    appliance: Object,
  },
  created() {
    this.homeId = parseInt(this.$route.params.id);
    this.item = this.appliance;
  },
  //   this.getSingleHome();

  data() {
    return {
      item: [],
      showForm: false,
      editAppliance: {},
    };
  },

  methods: {
    showEditForm() {
      // this uses the Javascript spread operator
      this.editAppliance = { ...this.appliance };
      this.showForm = true;
    },
    updateAppliance() {
      userService.updateAppliance(this.editAppliance).then((response) => {
        if (response.status === 200) {
          alert(`Message ${this.editAppliance.name} was updated.`);
          this.showForm = false;
          this.$emit("updated");
        }
      });
    },
    deleteAppliance() {
      if (!confirm("Are you sure you want to delete")) {
        return;
      }
      userService
        .deleteAppliance(this.appliance.applianceId)
        .then((response) => {
          if (response.status === 204) {
            alert(`Message: Appliance was removed.`);
            this.$emit("updated");
          }
        });
    },
  },
};
</script>

<style>
.card {
  border: 2px solid rgb(195, 145, 45);
  border-radius: 10px;
  /* width: 700px;  */
  /* height: 250px; */
  /* margin: 20px; */
  /* margin-top: 30px; */
  background-color: rgb(222, 231, 231);
  display: flex;
  flex-direction: column;
  justify-content: center;
  justify-content: space-between;
  margin: 30px;
  padding: 20px;
}
.card .notes {
  font-size: 0.8rem;
}

/* .card.urgent {
    background-color: lightgray;
} */

.top {
  background-color: rgb(143, 200, 200);
  height: 20px;
}
.card .appliance-name {
  font-size: 1.5rem;
}

.card .appliance-details {
  font-size: 1rem;
}

.card .buttons {
  display: flex;
  justify-content: flex-end;
  /* margin:0 -5px; */
  gap: 10px;
}

.card .button {
  font-size: 0.75rem;
}

#replace {
  color: red;
}
#edit-appliance-cost {
  height: 30px;
  width: 300px;
}
</style>