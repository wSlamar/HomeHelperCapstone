<template>
  <div id="single_home">    
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
    </div>

    <div id="empty"></div>   
    <div id="content">
      <div class="home_detail" id="home_detail">
        <img :src="home.picUrl" alt="Picture of the Current Home">
        <div>Home Name: {{ home.nickname }}</div>
        <div>Type of Home: {{ home.typeOfHome }}</div>
        <div>Street Address: {{ home.streetAddress }}</div>
        <div>City: {{ home.city }}</div>
        <div>State: {{ home.state }}</div>
        <div>Zip: {{ home.zip }}</div>
        <div>Build Year: {{ home.buildYear }}</div>
        <div>Purchase Year: {{ home.purchaseYear }}</div>

        <div id="show_hide">
          <button id="edit_button" @click="showEditForm">
            {{ showEdit ? "Cancel" : "Edit Home" }}
          </button>
          <button id="delete_button" v-on:click="deleteThisHome" v-show="!showEdit">
            Delete Home
          </button>

          <form class="form-register" v-show="showEdit">
            <h2 class="h3 mb-3 font-weight-normal">Edit Below</h2>
            <div
              class="alert alert-danger"
              role="alert"
              v-if="registrationErrors"
            >
              {{ registrationErrorMsg }}
            </div>
            <!-- <div id="basic_info"> -->
            <div class="form-element">
              <label for="nickname">Home Name: </label>
              <input
                type="text"
                id="nickname"
                class="form-control"
                placeholder="Home Nickname"
                v-model="home.nickname"
              />
            </div>
            <!-- <br /><br /> -->
            <div class="form-element">
              <label for="typeOfHome">Choose your home type: </label>
              <select
                name="typeOfHome"
                id="typeOfHome"
                class="form-control"
                v-model="home.typeOfHome"
              >
                <option value="House">House</option>
                <option value="Manufactured">Manufactured</option>
                <option value="Condo/co-ops">Condo/co-ops</option>
                <option value="Multi-family">Multi-family</option>
                <option value="Apartment">Apartment</option>
                <option value="Lots/Land">Lots/Land</option>
                <option value="Townhomes">Townhomes</option>
                <option value="Other">Other</option>
              </select>
            </div>
            <div class="form-element">
              <label for="streetAddress">Street Address: </label>
              <input
                type="text"
                id="streetAddress"
                class="form-control"
                placeholder="Street Address"
                v-model="home.streetAddress"
              />
            </div>
            <!-- <br /><br /> -->
            <div class="form-element">
              <label for="city">City: </label>
              <input
                type="text"
                id="city"
                class="form-control"
                placeholder="City"
                v-model="home.city"
              />
            </div>
            <!-- <br /><br /> -->
            <div class="form-element" id="state-select">
              <label for="state">State: </label>
              <select
                name="state"
                id="state"
                class="form-control"
                placeholder="State"
                v-model="home.state"
              >
                <option value="" disabled selected hidden>State</option>
                <option value="AL">Alabama</option>
                <option value="AK">Alaska</option>
                <option value="AZ">Arizona</option>
                <option value="AR">Arkansas</option>
                <option value="CA">California</option>
                <option value="CO">Colorado</option>
                <option value="CT">Connecticut</option>
                <option value="DE">Delaware</option>
                <option value="DC">District of Columbia</option>
                <option value="FL">Florida</option>
                <option value="GA">Georgia</option>
                <option value="HI">Hawaii</option>
                <option value="ID">Idaho</option>
                <option value="IL">Illinois</option>
                <option value="IN">Indiana</option>
                <option value="IA">Iowa</option>
                <option value="KS">Kansas</option>
                <option value="KY">Kentucky</option>
                <option value="LA">Louisiana</option>
                <option value="ME">Maine</option>
                <option value="MD">Maryland</option>
                <option value="MA">Massachusetts</option>
                <option value="MI">Michigan</option>
                <option value="MN">Minnesota</option>
                <option value="MS">Mississippi</option>
                <option value="MO">Missouri</option>
                <option value="MT">Montana</option>
                <option value="NE">Nebraska</option>
                <option value="NV">Nevada</option>
                <option value="NH">New Hampshire</option>
                <option value="NJ">New Jersey</option>
                <option value="NM">New Mexico</option>
                <option value="NY">New York</option>
                <option value="NC">North Carolina</option>
                <option value="ND">North Dakota</option>
                <option value="OH">Ohio</option>
                <option value="OK">Oklahoma</option>
                <option value="OR">Oregon</option>
                <option value="PA">Pennsylvania</option>
                <option value="RI">Rhode Island</option>
                <option value="SC">South Carolina</option>
                <option value="SD">South Dakota</option>
                <option value="TN">Tennessee</option>
                <option value="TX">Texas</option>
                <option value="UT">Utah</option>
                <option value="VT">Vermont</option>
                <option value="VA">Virginia</option>
                <option value="WA">Washington</option>
                <option value="WV">West Virginia</option>
                <option value="WI">Wisconsin</option>
                <option value="WY">Wyoming</option>
              </select>
            </div>
            <!-- <input
              type="text"
              id="state"
              class="form-control"
              placeholder="State"
              v-model="newHome.state"
              required
            /> -->
            <!-- <br /><br /> -->
            <div class="form-element">
              <label for="zip">Zip: </label>
              <input
                type="tel"
                inputmode="numeric"
                pattern="\d{5,5}(-\d{4,4})?"
                max="99999"
                id="zip"
                class="form-control"
                placeholder="xxxxx(-xxxx)"
                v-model="home.zip"
              />
            </div>
            <!-- <br /><br /> -->

            <!-- <br /><br /> -->
            <div class="form-element">
              <label for="homeDescription">Description: </label>
              <textarea
                id="homeDescription"
                class="form-control"
                placeholder="Description of your home.  If you put OTHER as the type of your home, please specify here."
                v-model="home.description"
              />
            </div>
            <!-- <br /><br /> -->
            <div class="form-element">
              <label for="buildYear">Build Year: </label>
              <input
                type="number"
                min="1800"
                max="2099"
                step="1"
                value="2020"
                id="buildYear"
                class="form-control"
                placeholder="yyyy"
                v-model="home.buildYear"
              />
            </div>
            <!-- <br /><br /> -->
            <div class="form-element">
              <label for="isBuiltByOwner">Built by the current owner? </label>
              <select
                name="isBuiltByOwner"
                id="isBuiltByOwner"
                class="form-control"
                v-model="isBuiltByOwner"
                @change="fillPurchaseYear($event)"
              >
                <option value="true">Yes</option>
                <option value="false">No</option>
              </select>
            </div>
            <!-- <br /><br /> -->
            <div class="form-element">
              <label for="purchaseYear">Purchase Year: </label>
              <input
                type="number"
                min="1800"
                max="2099"
                step="1"
                value="2020"
                id="purchaseYear"
                class="form-control"
                placeholder="yyyy"
                v-model="home.purchaseYear"
              />
            </div>
            <button
              id="update_button"
              type="submit"
              @click="updateHome"
              @submit.prevent="updateHome"
            >
              Update Home Info
            </button>
          </form>
        </div>
      </div>

      <div id="buttons">
        <button>
          <router-link style="text-decoration: none" :to="{ name: 'storelist', params: { homeId: homeId } }"
            >Show Store List</router-link
          >
        </button>
        <button>
          <router-link style="text-decoration: none" :to="{ name: 'servicelist', params: { homeId: homeId } }"
            >Show Service List</router-link
          >
        </button>
      </div>

      <div id="reminders" v-show="reminders.length > 0">
        <!-- <table> -->
        <tr>
          <th>Reminder Type</th>
          <th>Name</th>
          <th>Due Date</th>
        </tr>
        <tr
         
          v-for="reminder in reminders"
          v-bind:key="reminder.homeid"
        >
          <td>{{ reminder.type }}</td>
          <td>{{ reminder.name }}</td>
          <td>{{ reminder.date}}</td>
        </tr>
        <!-- </table> -->
      </div>
    </div>
  </div>
</template>

<script>
import UserService from "../services/UserService";
export default {
  name: "homedetail",
  data() {
    return {
      home: [],
      homeId: 0,
      userId: this.$store.state.user.userId,
      reminders: [],
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
      showEdit: false,
      isBuiltByOwner: false,
    };
  },

  computed: {
    // home() {
    //   UserService.getHome(this.homeId).then((response) => {
    //     return response.data;
    //   });
    // },
  },

  methods: {
    getSingleHome() {
      UserService.getHome(this.homeId).then((response) => {
        this.home = response.data;
        this.reminders = this.home.reminders;
      });
    },

    showEditForm() {
      if (this.showEdit == false) {
        this.showEdit = true;
      } else {
        this.showEdit = false;
      }
    },
    fillPurchaseYear(event) {
      if (event.target.value === "true") {
        this.home.purchaseYear = this.home.buildYear;
      }
    },

    updateHome() {
      UserService.updateHome(this.home).then((response) => {
        if (response.status === 200) {
          alert("Your home information has been updated.");
          this.showEdit = false;
          this.$emit("updated");
        }
      });
    },

    deleteThisHome() {
      if (!confirm("Are you sure you want to delete this home?")) {
          return;
        }
      UserService.deleteHome(this.home).then((response) => {
        
        if (response.status === 204) {
          alert("Your home has been deleted.");
          this.showEdit = false;
          this.$router.push("/myhomes");
          this.$emit("updated");
        }
      });
    },
  },

  created() {
    this.homeId = parseInt(this.$route.params.id);

    this.getSingleHome();

    // UserService.getHome(this.homeId).then((response) => {
    //   this.home = response.data;
    // });
  },
};
</script>

<style scoped>

/* .form-control {
  width: 300px;
} */

h2 {
  font-size: 28px;
  text-decoration: underline;
}

img{
  max-width: 300px;
  margin: auto;
  margin-bottom: 30px;
}
#update_button {
  margin: auto;
  /* justify-content: space-around; */
  margin-top: 20px;
  width: 180px;
  color:black;
}
#delete_button {
  /* justify-content: space-around; */
  margin: auto;
  margin-top: 20px;
  color: black;
}
#buttons {
  display: flex;
  justify-content: space-around;
  color: black;
  padding: 10px;
}
#edit_button {
  margin: auto;
  margin-top: 20px;
  color: black;
}

button {
  width: 160px;
  height: 36px;
}

#single_home {
  display: flex;
  flex-direction: row;
  padding: 50px;
}

#empty {
  width: 300px;
}

#content {
  margin: auto;
  text-align: center;
  flex-direction: column;
}

.form-register {
  align-content: center;
  padding: 10px;
}
#home_detail {
  border: solid;
  border-radius: 20px;
  padding: 40px;
  margin: 20px;
  background: rgb(206, 228, 226);
}

#reminders {
  margin: auto;
  padding-left: 18px;
  padding-top: 30px;
}

.sidenavigation {
  height: auto; /* Full-height: remove this if you want "auto" height */
  width: 300px; /* Set the width of the sidebar */
  position: fixed; /*Fixed Sidebar (stay in place on scroll)*/
  z-index: 1; /* Stay on top */
  top: 380px; /* Stay at the top */
  left: 73px;
  background-color: rgba(112, 109, 109, 0.287); /* Black */
  overflow-x: hidden; /* Disable horizontal scroll */
  padding-top: 20px;
  padding-bottom: 20px;
  padding-left: 0px;
  padding-right: 10px;
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

tr {
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

/* tr th td {
  text-align: center;
  height: 40px;
} */

</style>