<template>
    <div class="appliance-list">
        <div class="sidenavigation">
            <a><router-link :to="{ name: 'profile'} ">My Profile</router-link></a>
            <a><router-link :to="{ name: 'myhomes' } ">My Homes</router-link></a>
            <!-- <a><router-link :to="{ name: 'addhome' } ">Add Home</router-link></a> -->
            <a><router-link :to="{ name: 'repairs' } ">My Repairs</router-link></a>
            <!-- <a><router-link :to="{ name: 'appliances' } ">My Appliances</router-link></a> -->
            <a><router-link :to="{ name: 'homedetail' } ">Current Home</router-link></a>
        </div>
        <main class="main">
    <div id="add-button">
    <button id="showHide" class="button" v-on:click.prevent="showAddForm" v-show="!showForm" >Add another appliance</button>
    </div>
    <form v-if="showForm" >
      <div class="form-element">
            <label for="appliance-name">Appliance Name:</label>
            <input type="text" id="appliance-name" v-model="newAppliance.name" />
      </div>
      <div class="form-element">
            <label for="appliance-make">Appliance Make:</label>
            <input type="text" id="appliance-make" v-model="newAppliance.make" />
      </div>
      <div class="form-element">
            <label for="purchase-date">Purchase Date:</label>
            <input type="date" id="purchase-date" placeholder="mm/dd/yyyy" v-model="newAppliance.purchaseDate" />
      </div>
      <div class="form-element">
            <label for="model-number" >Model Number:</label>
            <input type="text" id="modelNumber" v-model="newAppliance.modelNumber" />
      </div>
      <div class="form-element">
          <label for="serial-number" >Serial Number:</label>
          <input type="text" id="serialNumber" v-model="newAppliance.serialNumber" />
      </div>
      <div class="form-element">
      <label for="cost">Cost: </label>
          <input type="number" id="appliance-cost" value="1000" min="0" step="any" data-number-to-fixed="2" data-number-stepfactor="100"
            data-type="currency" class="form-element" placeholder="0.00" v-model="newAppliance.cost"
          />
      </div>
      <div class="form-element">
          <label for="warranty">Warranty Expiration:</label>
            <input type="date" id="warrantyExpiration" placeholder="mm/dd/yyyy" v-model="newAppliance.warrantyExpiration" />
      </div>
      <div class="form-element">
          <label for="warranty">Delivery Date:</label>
            <input type="date" id="deliveryDate"  placeholder="mm/dd/yyyy" v-model="newAppliance.deliveryDate" />
      </div>
      <div class="form-element">
          <label for="receiptUrl">This is where I store the receipt:</label>
            <input type="year" id="receiptUrl" v-model="newAppliance.receiptUrl" />
      </div> 
      <div class="form-element">
          <label for="description">Important Details:</label>
            <textarea id="description" v-model="newAppliance.description" />
      </div>
      
      <button type="button" @click.prevent="addAppliance" >Submit</button>
      <button type="button" value="Cancel" @click="resetAppliance" >Cancel</button>

    </form>

            <h1>Appliance List</h1>
            <appliance-list :key="componentKey"/>
        </main>
 
    </div>
</template>

<script>
import ApplianceList from '@/components/ApplianceList.vue';
import UserService from '@/services/UserService.js';
export default {
    name: "Appliances",
    components: {
        ApplianceList
    },
    
    data() {
        return {
            showForm: false,
            componentKey: 0,
            homeId: 0,
            userId: 0,
            newAppliance: {
            },
        }
    },
    created() {
      this.homeId = parseInt(this.$route.params.id);
      this.userId = parseInt(this.$store.state.user.userId);
    },
    methods: {
      showAddForm() {
        this.newAppliance = { 
              homeId: this.homeId,
              userId: this.userId,
              name: "",
              make: "",
              purchaseDate: "",
              modelNumber: "",
              serialNumber: "",
              warrantyExpiration: "",
              cost: 0.00,
              estimatedDelivery: "",
              deliveryDate: "",
              description: "",
              receiptUrl: "",
         };
        this.showForm = true;
        },
    addAppliance(){       
        UserService.addAppliance(this.newAppliance)
        .then( (response) => { 
          if (response.status === 201) {  
            alert(`Message ${this.newAppliance.name} was added.`);

            this.showForm = false;
            this.componentKey += 1;
            // this.newAppliance = {};
          }
        });             
    },
    resetAppliance(){
         this.newAppliance = {};
         this.showForm = false;
     }
  },

}
</script>

<style scoped>
#add-button {
  padding-top: 40px;
}

.appliance-list {
    display: flex;
    margin-left: 600px;
}
.sidenav {
  /* height: 75%; 
  width: 250px; /* Set the width of the sidebar */
  position: relative; 
  /* z-index: 10; Stay on top */
  top: .4px; /* Stay at the top .4px  */
  /* left: 0; */
  padding: 0;
  margin: 0;
  overflow: hidden;
  background-color: #ffe3ae;
  /* overflow-x: hidden; Disable horizontal scroll */
  /* padding-top: 80px; */
  border-right-color: rgb(175, 122, 15);
  border-right-width: 40px;
}

.right-side {
    
  /* height: 75%; 
  width: 250px; /* Set the width of the sidebar */
  position: relative; 
  /* z-index: 10; Stay on top */
  top: .4px; /* Stay at the top .4px  */
  /* left: 0; */
  padding: 0;
  margin: 0;
  overflow: hidden;
  background-color: #ffe3ae;
  /* overflow-x: hidden; Disable horizontal scroll */
  /* padding-top: 80px; */
  border-left-color: rgb(175, 122, 15);
  border-left-width: 3px;
}
.main {
    flex-basis: 65%;
}

.button {
  width: 200px;
  height: 40px;
  padding: 10px 10px 10px 10px;
  text-align: center;
}

#appliance-cost {
  width: 300px;
  height: 30px;
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
  padding: 0px 10px;
}

/* On smaller screens, where height is less than 450px, change the style of the sidebar (less padding and a smaller font size) */
@media screen and (max-height: 450px) {
  .sidenavigation {padding-top: 15px;}
  .sidenavigation a {font-size: 18px;}
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

</style>