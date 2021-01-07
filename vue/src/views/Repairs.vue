<template>
  <div>
    <div class="sidenavigation">
      <a><router-link :to="{ name: 'profile' }"
        >My Profile</router-link
      ></a>
      <a><router-link :to="{ name: 'myhomes' }"
        >My Homes</router-link
      ></a>
      <!-- <a><router-link :to="{ name: 'addhome' }"
        >Add Home</router-link
      ></a> -->
      <!-- <a><router-link :to="{ name: 'repairs' }"
        >My Repairs</router-link
      ></a> -->
      <a><router-link :to="{ name: 'appliances' }"
        >My Appliances</router-link
      ></a>
      <a><router-link :to="{ name: 'homedetail' } ">Current Home</router-link></a>
      <!-- <div class="nav-vertical-line"><hr /></div> -->
    </div>
    <Main>
      <div>
        <h1>Repairs & Maintenance Record</h1>
        <repairs-table />

        <!-- v-bind:repair="repair"
        v-for="repair in listOfRepairs"
        v-bind:key="repair.repairId" -->

        <!-- <div class="repair-table">
        <div class="repairMaintenanceRecord">       
        <div>Item Name: {{newRepair.name}}</div>
        <br>
        <div>Projected Cost: {{newRepair.projectedCost}}</div>
        <br>
        <div>Total Cost: {{newRepair.cost}}</div>
        <br>
        <div>Date of Repair or Maintenance: {{newRepair.lastRepairDate}}</div> 
        <br>    
        <div>Description: {{newRepair.description}}</div>
        <br>
      </div> -->
      </div>
      <!-- CHANGE BUTTON TO TOGGLE between Showing and Hiding Repairs Add form -->
      <!-- v-on:click="getAddRepairForm()" -->
      <div class="add-repair">
        <!-- <button id="showHide" href="#" v-on:click.prevent="showForm = true" v-show="!showForm" >Add A New Repair</button> -->
        <div class="add-repair-button">
        <button
          v-on:click.prevent="showForm = true"
          v-show="!showForm"
          class="Form-Button"
        >
          Click To Add New Repair
        </button>
        </div>
        <div id="form-div">
        <form
          class="form-repairs"
          v-show="showForm"
        >
          <h2>Add New Repair Form</h2>
          <label for="name">Item Name: </label>
          <input
            type="text"
            id="name"
            class="form-repairs"
            placeholder="Item in need of repair"
            v-model="newRepair.name"
            required
           
          />
          <br><br>
          <label for="projectedCost">Projected Cost: </label>
          <input
            type="number"
            id="projectedCost"
            value="1000"
            min="0" 
            step="any"
            data-number-to-fixed="2" 
            data-number-stepfactor="100"
            data-type="currency"
            class="form-repairs"
            placeholder="0.00"
            v-model="newRepair.projectedCost"
            required
          />
          <br><br>
          <label for="cost">Total Cost: </label>
          <input
            type="number"
            id="cost"
            value="1000"
            min="0" 
            step= "any"
            data-number-to-fixed="2" 
            data-number-stepfactor="100"
            data-type="currency"
            class="form-repairs"
            placeholder="0.00"
            v-model="newRepair.cost"
            required
          />
          <br><br>
          <label for="lastRepairDate">Date of Last Repair: </label>
          <input
            type="date"
            id="lastRepairDate"
            class="form-repairs"
            placeholder="mm/dd/yyyy"
            v-model="newRepair.lastRepairDate"
          />
          <br><br>
          <label for="expectedLife">Expected Life of Repair in Years: </label>
          <input
            type="number"
            id="expectedLife"
            class="form-repairs"
            placeholder="Enter year number here"
            v-model="newRepair.expectedLife"
            required
          />
          <br><br>
          <label for="potentialReplacementDate"
            >Potential Replacement Date:
          </label>
          <input
            type="date"
            id="potentialReplacementDate"
            class="form-repairs"
            placeholder="mm/dd/yyyy"
            v-model="newRepair.potentialReplacementDate"
          />
          <br><br>

          <label for="description">Description: </label>
          <textarea
            id="description"
            class="form-repairs"
            placeholder="Add any pertinent information about the repair/maintenance here."
            v-model="newRepair.description"
            required
          />
          <br><br>

          <button
            class="btn btn-lg btn-primary btn-block"
            type="submit"
            @click="addNewRepair(newRepair)"
            @submit.prevent="addNewRepair"
          >Add New Repair</button>
          <button type="button" @click="clearForm">Cancel</button>
        </form>
        </div>
      </div>
    </Main>
  </div>
</template>

<script>
import UserService from "../services/UserService.js";
import RepairsTable from "@/components/RepairsTable.vue";

export default {
  name: "Repairs",
  components: { RepairsTable },
  data() {
    return {
      // listofRepairs: [],
      showForm: false,
      // homeId: 0,
      newRepair: {
        homeId: 0,
        userId: 0,
        name: "",
        projectedCost: 0.00,
        cost: 0.00,
        lastRepairDate: "",
        expectedLife: "",
        potentialReplacementDate: "",
        description: "",
      },
    }
  },

  created() {
      this.newRepair.homeId = parseInt(this.$route.params.id);
      this.newRepair.userId = parseInt(this.$store.state.user.userId);
    },
    
  methods: {
    addNewRepair() {
      UserService.addRepair(this.newRepair).then((response) => {
        if (response.status === 201) {

          // this.$router.push(`/repairs/${this.newRepair.homeId}`)
          this.clearForm();
        }
      });
    },
    clearForm() {
      this.newRepair = [];
      this.showForm = false;
    },
    // getRepair() {
    //   UserService.getRepair(this.homeId).then((response) => {
    //     return response.data;
    //   });
    // },
    
    getAllHomeRepairs() {
      UserService.getRepair().then((response) => {
        this.newRepair = response.data;
      });
    },
    // deleteRepair(id) {
    //   UserService.deleteRepair(id).then((response) => {
    //     if (response.status === 200) {
    //       alert(`Repair was deleted`);
    //       this.getAllHomeRepairs();
    //     }
    //   });
    // },
  },
};
</script>

<style scoped>
#form-div {
padding-left: 130px;
}

.add-repair-button {
  margin-left: 576px;
  padding-top: 10px;
}

h1 {
  text-align: center;
  text-emphasis: none;
  font-size: 60px;
  padding-bottom: 30px;
  padding-left: 140px;
  padding-top: 20px;
  /* text-decoration: underline;
  text-decoration-style: dotted; */
  /* border-bottom: 5px dotted rgb(195, 145, 45); */
}
h2 {
  text-align: center;
  padding: 0px 15px 10px 0;
}

.repair-table {
  text-align: center;
}

.Form-Button {
  display: block;
  margin-left: 270px;;
  margin-right: auto;
  margin-top: 20px;
  /* margin-top:22%; */
  /* margin-bottom:0% */
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
  /* padding: 0px 10px; */
}

/* On smaller screens, where height is less than 450px, change the style of the sidebar (less padding and a smaller font size) */
@media screen and (max-height: 450px) {
  .sidenavigation {padding-top: 15px;}
  .sidenavigation a {font-size: 18px;}
}


/* .nav-vertical-line {
    /* width: 959px; */
/* height: 3px;  */
/* transform: rotate(-90deg); */
/* border-color: #aaaaaa; */
/* border-width: 2px; */
/* border-style: solid; */

/* display: block;
  height: auto;
  border: 0;
  border-top: 3px solid rgb(175, 122, 15);
  margin: 10px;
  padding: 0; */
/* border-left: 3px solid rgb(175, 122, 15);
  height: 500px;
  position: absolute;
  left: 50%;
  margin-left: 30px;
  top: 0;
} */
</style>