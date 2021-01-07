<template>
<div>
    

    
      <applianceCard class="appliance" v-on:updated="getHomeAppliances" v-bind:appliance="appliance" v-for="appliance in listOfAppliances" v-bind:key="appliance.id" />
      

    </div>
</template>

<script>

import ApplianceCard from "@/components/Appliance.vue";
import userService from "@/services/UserService.js";
// import ShoppingMap from "@/views/ShoppingMap.vue";

export default {
    name: "appliance-list",
    components: {
        ApplianceCard,
        // ShoppingMap
    },

    data() {
        return {
            newApplianceError: "",
            showForm: false,
            homeId: 0,
            listOfAppliances:[
                // {
                //     id: 1,
                //     name: "Refrigerator",
                //     make: "KitchenAid",
                //     purchaseDate: 2020,
                //     modelNumber: "eydb2220",
                //     serialNumber: "5wycb4463",
                //     warrantyExpiration: 2025,
                //     description: "First year limited warranty. Second through fifth year limited warranty(certain component parts only)",

                // },
                // {
                //     applianceid: 2,
                //     name: "Air Conditioner",
                //     make: "GE",
                //     purchaseDate: 2020,
                //     modelNumber: "eydb2220",
                //     serialNumber: "5wycb4463",
                //     warrantyExpiration: 2025,
                //     description: "First year limited warranty. Second through fifth year limited warranty(certain component parts only)",

                // },
                // {
                //     applianceid: 3,
                //     name: "Washer",
                //     make: "Kenmore",
                //     purchaseDate: 2020,
                //     modelNumber: "eydb2220",
                //     serialNumber: "5wycb4463",
                //     warrantyExpiration: 2025,
                //     description: "No warranty",

                // },
                // {
                //     applianceid: 4,
                //     name: "Dryer",
                //     make: "Kenmore",
                //     purchaseDate: 2020,
                //     modelNumber: "eydb2220",
                //     serialNumber: "5wycb4463",
                //     warrantyExpiration: 2025,
                //     description: "Bought service contract on this item. Account no-xxx7373",

                // }
            ],
            
            
        }

    },
    created() {
      this.homeId = parseInt(this.$route.params.id);
      this.getHomeAppliances();
    },
 

    methods: {
    getHomeAppliances() {
        userService.getAppliances(this.homeId)
        .then(response => {
            this.listOfAppliances = response.data;
        })
    },
   
     deleteAppliance(id){
         userService.deleteAppliance(id)
         .then(response => {
             if (response.status === 200){
                 alert(`Appliance was deleted`);
                 this.getHomeAppliances();
             }
         })
     },
}
}
</script>

<style>
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
  border-right-width: 3px;
}
.Homes-Button {
 display: block;
  margin-bottom: 20px;
  justify-items: center;
   position: relative;
  justify-self: center;
  display: flex;
  flex-basis: 100%;
  flex-direction: column;
  justify-content: space-between;
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
  color:rgb(138, 48, 48);
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
div.form-element {
  margin-top: 10px;
}
div.form-element > label {
  display: block;
}
div.form-element > input,
div.form-element > select {
  height: 30px;
  width: 300px;
}
div.form-element > textarea {
  height: 60px;
  width: 300px;
}
form > input[type="button"] {
  width: 150px;
}
form > input[type="submit"] {
  width: 150px;
  margin-right: 10px;
}
</style>