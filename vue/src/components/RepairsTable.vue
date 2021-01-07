<template>
  <div class="repair-table">
    <!-- <button v-on:click="getAllRepairs()">Open Repairs Table</button> -->
    <div class="scroll">
    <table>
      <tr>
        <th>Item Name</th>
        <th>Projected Cost</th>
        <th>Total Cost</th>
        <th>Date of Last Repair</th>
        <th>Expected Life of Repair in Years</th>
        <th>Potential Replacement Date</th>
        <th>Description</th>
        <th>Delete Repair</th>
        <th>Edit Repair</th>
        <th>Request Service</th>
      </tr>
      <!-- <router-link class="button" :to="{ name: 'map', params: { id: 'a' + appliance.applianceId } }" v-bind:item="this.item" id="replace">Replace</router-link> -->
      <tr
        v-bind:repair="repair"
        v-for="repair in listofRepairs"
        v-bind:key="repair.repairId"
        :class="{editing: repair == editedRepair}" v-cloak
      >
        <td><div class="view">{{ repair.name }}</div><div class="edit"><input type="text" v-model="repair.name"/></div></td>
        <td><div class="view">{{ repair.projectedCost }}</div><div class="edit"><input type="text" v-model="repair.projectedCost"/></div></td>
        <td><div class="view">{{ repair.cost }}</div><div class="edit"><input type="text" v-model="repair.cost"/></div></td>
        <td><div class="view">{{ repair.lastRepairDate }}</div><div class="edit"><input type="text" v-model="repair.lastRepairDate"/></div></td>
        <td><div class="view">{{ repair.expectedLife }}</div><div class="edit"><input type="text" v-model="repair.expectedLife"/></div></td>
        <td><div class="view">{{ repair.potentialReplacementDate }}</div><div class="edit"><input type="text" v-model="repair.potentialReplacementDate"/></div></td>
        <td><div class="view">{{ repair.description }}</div><div class="edit"><input type="text" v-model="repair.description"/></div></td>
        <!-- <td><button v-on:click="deleteRepair">Delete Repair</button></td> -->
        <td><input type="checkbox" name="chk" v-bind:id="repair.repairId" v-bind:value="repair.repairId" v-model="selectedRepairIds" /></td>
        <td>
              <div class="view">
                <button @click="editRepair(repair)">edit</button>
              </div>
              <div class="edit">
                <button @click="saveRepair(repair)">save</button>
              </div>
            </td>
        <td><router-link
          class="button"
          :to="{ name: 'map', params: { id: 'r' + repair.repairId } }"
          id="replace"
          >Replace</router-link
        ></td>
      </tr>
      <!-- @click="deleteRepair(this.repair.repairId)"" -->
      <!-- <input type="button" id="deleterecords" value="Delete Records" v-on:click.prevent="deleteRepairs" v-model="deleteRepairs"> -->
      
      
      <!-- <div class="repair-buttons"> -->
        
        <!-- <button class="button" v-on:click="editRepair(repair.repairId)">
          Edit Repair
        </button> -->
      <!--check this-->
      <!-- </div> -->
      <!-- <button v-on:click="getAddRepairForm()" class="Form-Button">Open To Add New Repair</button> -->
      <!-- <repairs/ > -->
    </table>
    </div>
        <div class="delete-button">
         <button class="button" @click="deleteRepairs" >
          Delete Checked Repairs
        </button> 
        </div>
  </div>
</template>

<script>
import UserService from "../services/UserService.js";
// import Repairs from "../views/Repairs.vue";
export default {
  // components: { Repairs },
  name: "RepairsTable",
  props: {
    repair: Object,
  },
  data() {
    return {
      editMode: false,
      listofRepairs: [],
      selectedRepairIds: [],
      editedRepair: {},
      showForm: false,
      homeId: 0,
      repairs: {
        homeId: 0,
        userId: 0,
        name: "",
        projectedCost: "",
        cost: "",
        lastRepairDate: "",
        expectedLife: "",
        potentialReplacementDate: "",
        description: "",
      },
    };
  },
  methods: {
  
    getRepair() {
      UserService.getRepair(this.homeId).then((response) => {
        return response.data;
      });
    },
    editRepair (repair) {
      this.editedRepair = repair
    },
    saveRepair () {
      UserService.updateRepair(this.editedRepair).then((response) => {
         if (response.status === 200) {
          alert(`Message ${this.editedRepair.name} was updated.`);
        }
      })
      window.location.reload(); 

    },
    deleteRepairs() {
      this.selectedRepairIds.forEach((id) => {
        UserService.deleteRepair(id)
        });
        this.getAllRepairs;
        this.selectedRepairIds = [];
        window.location.reload(); 
    },
    getAllRepairs() {
      UserService.getRepairs(this.homeId).then((response) => {
        this.listofRepairs = response.data;
      });
    },
    updateRepair() {
      UserService.updateRepair(this.newRepair).then((response) => {
        if (response.status === 200) {
          alert(`Message ${this.newRepair.name} was updated.`);
          this.showForm = false;
        }
      });
    },
  },
  created() {
    this.homeId = parseInt(this.$route.params.id);
    // this.newRepair.userId = parseInt(this.$store.state.user.userId);
    this.getAllRepairs();

    // UserService.getRepairs().then((response) => {
    //   this.listofRepairs = response.data;
    // });
  },
};
</script>

<style>

.delete-button {
  margin-left: 120px;
  padding-top: 30px;
} 

[v-cloak] {
display: none;
    }
.edit {
display: none;
    }
.editing .edit {
display: block
}
.editing .view {
display: none;
}

table,
th,
td {
  border: 1px solid rgb(111, 113, 114);
  text-align: center;
}

th {
  height: 70px;
  background-color: rgba(119, 173, 173, 0.767);
  color: white;
}

td {
  text-align: center;
  height: 50px;
}

th,
td {
  padding: 15px;
  text-align: center;
}
table {
  border-collapse: collapse;
  width: 80%;
  margin-left: 270px;
  margin-right: auto;
  /* display: block;
margin: 10px auto;
border-radius: 10px;
width: 1400px;
height: auto;
margin: 20px; */
  border: 1px solid rgb(111, 113, 114);
  border-radius: 10px;
  /* width: 700px;  */
  /* height: 250px; */
  /* margin: 20px; */
  /* margin-top: 30px; */
  background-color: rgb(222, 231, 231);
  /* display: flex;
flex-direction: column; */
  /* justify-content: center;
justify-content: space-between;  */
  /* padding: 15px; */
}

#button-row {
  border-bottom: 1px solid rgb(111, 113, 114);
  border-right:  1px solid rgb(111, 113, 114); 


}
.button {
  display: block;
  margin: 10px auto;
  padding: 10px;
  width: 200px;


}

</style>