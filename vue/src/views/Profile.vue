<template>
  <div class="content">
    <header class="header"></header>
    <div class="sidenavigation">
      <!-- <a
        ><router-link :to="{ name: 'profile' }">Edit My Profile</router-link></a
      > -->
      <!-- ADD Edit my profile LATER -->
      <a><router-link :to="{ name: 'myhomes' }">My Homes</router-link></a>
      <a><router-link v-bind:to="{ name: 'addhome' }">Add Home</router-link></a>
      <!-- <router-link :to="{ name: 'repairs' } "><button>View Repairs</button></router-link> -->
      <!-- <router-link :to="{ name: 'appliances' } "><button>My Appliances</button></router-link> -->
      <!-- <button v-on:click="getUserInfo()">Show My Profile</button> -->
    </div>

    <Main>
      <h1>My Profile</h1>
      <!-- <p class="alert-danger">You must be authenticated to see this</p> -->
      <div class="user_profile">
        <div>User Id: {{ user.userId }}</div>
        <br />
        <div>Username: {{ user.username }}</div>
        <br />
        <div>Name: {{ user.firstName }} {{ user.lastName }}</div>
        <br />
        <div>Email: {{ user.email }}</div>
        <br />
        <div>Phone: {{ user.phoneNumber }}</div>
        <br />
        <h3>Billing Address:</h3>
        <br />
        <div>Street Address: {{ user.billingStreetAddress }}</div>
        <br />
        <div>City: {{ user.billingCity }}</div>
        <br />
        <div>State: {{ user.billingState }}</div>
        <br />
        <div>Zipcode: {{ user.billingZip }}</div>
        <br />

        <div id="edit">
          <button id="cancel" @click="showEditForm">
            {{ showEdit ? "Cancel Edit" : "Edit Profile" }}
          </button>

          <form
            v-show="showEdit"
            class="form-register"
            @submit.prevent="update"
          >
            <h2 class="h3 mb-3 font-weight-normal">Edit Below</h2>

            <div>
              <label for="email" class="sr-only">Email</label>
              <input
                type="email"
                id="email"
                class="form-control"
                placeholder="Email"
                v-model="user.email"
              />
              <br /><br />
              <label for="phoneNumber" class="sr-only">Phone Number</label>
              <input
                type="tel"
                pattern="[0-9]{3}-[0-9]{3}-[0-9]{4}"
                minlength="12"
                maxlength="12"
                id="phoneNumber"
                class="form-control"
                placeholder="xxx-xxx-xxxx"
                v-model="user.phoneNumber"
              />
              <br /><br />
              <p id="billing">Billing Address</p>
              <label for="streetAddress" class="sr-only">Street Address</label>
              <input
                type="text"
                id="streetAddress"
                class="form-control"
                placeholder="Street Address"
                v-model="user.billingStreetAddress"
              />
              <br /><br />
              <label for="city" class="sr-only">City</label>
              <input
                type="text"
                id="city"
                class="form-control"
                placeholder="city"
                v-model="user.billingCity"
              />
              <br /><br />
              <label for="state" class="sr-only">State</label>
              <select
                name="state"
                id="state"
                placeholder="State"
                v-model="user.billingState"
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
              <br /><br />
              <label for="zip" class="sr-only">Zip</label>
              <input
                type="text"
                inputmode="numeric"
                pattern="\d{5,5}(-\d{4,4})?"
                max="99999"
                id="zip"
                class="form-control"
                placeholder="xxxxx(-xxxx)"
                v-model="user.billingZip"
              />
              <br /><br />
            </div>

            <button  id="submit" class="btn btn-lg btn-primary btn-block" type="submit">
              Update Profile
            </button>
          </form>
        </div>
      </div>
    </Main>
  </div>
</template>

<script>
import UserService from "@/services/UserService.js";

export default {
  name: "profile",
  data() {
    return {
      user: {},
      propertyList: [],
      showEdit: false,
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    getUserInfo() {
      UserService.getUser().then((response) => {
        this.user = response.data;
      });
    },
    showEditForm() {
      if (this.showEdit == false) {
        this.showEdit = true;
      } else {
        this.showEdit = false;
      }
      this.getUserInfo();
    },
    update() {
      UserService.updateUser(this.user).then((response) => {
        if (response.status === 200) {
          alert("Your profile information has been updated.");
          this.showEdit = false;
          this.$emit("updated");
        }
      });
    },
  },

  created() {
    this.getUserInfo();
    // UserService.getUser()
    //   .then( response => {
    //       this.user = response.data;
    //   });
  },
};
</script>

<style scoped>
#cancel{
  margin: auto;
  margin-bottom: 10px;
}
#submit{
  margin: auto;
  margin-bottom: 10px;
}
h1 {
  text-align: center;
  text-emphasis: none;
  font-size: 60px;
  padding-bottom: 20px;
  /* /* text-decoration: underline; */
  /* text-decoration-style: dotted; */ 
  /* border-bottom: 5px dotted rgb(195, 145, 45); */
}

h2 {
  font-size: 28px;
  text-decoration: underline;
}

h3 {
  font-size: 20px;
  text-decoration: underline;
}

#billing {
  font-size: 20px;
  text-decoration: underline;
}
main {
  /* display: flex; */
  display: inline-block;
  position: relative;
  justify-self: center;
  display: flex;
  flex-basis: 100%;
  flex-direction: column;
  text-align: center;
  /* justify-self: center; */
}
.alert-danger {
  text-align: center;
  color: rgb(138, 48, 48);
}

.user_profile {
  /* width: 100%; */
  padding: 12px 20px;
  /* margin: 30px 0 0 60px; */
  display: inline-block;
  border: 2px solid;
  border-radius: 20px;
  box-sizing: border-box;
  margin: 0 auto;
  max-width: 320px;
  padding-top: 20px;
  /* margin: 0 auto;
    max-width: 320px;
    display: inline-block; */
    /* padding: 10px; */
  position: relative;
  justify-self: center;
  display: flex;
  flex-basis: 100%;
  flex-direction: column;
  /* justify-content: space-between; */
  background: rgb(206, 228, 226);

}

.form-control {
  width: 200px;
}

#state {
  width: 208px;
}

button {
  width: 160px;
  height: 36px;
  margin: auto;
  margin-top: 20px;
  color: black;
}

/* .sidenav {
  /* height: 75%; Full-height: remove this if you want "auto" height */
/* width: 250px; /* Set the width of the sidebar */
/*position: fixed; /* Fixed Sidebar (stay in place on scroll) */
/* z-index: 10; Stay on top */
/* top: .4px; /* Stay at the top .4px  */
/* left: 0; */
/* padding: 0; */
/* padding-top: 40px;
  margin: 0;
  overflow: hidden;
  background-color: #ffe3ae;
  /* overflow-x: hidden; Disable horizontal scroll */
/* padding-top: 80px; */
/* border-right-color: rgb(175, 122, 15);
  border-right-width: 3px;
  height: 100vh;

  position: fixed;
  right: 0;
  top: 50%;
  width: 8em;
  margin-top: -2.5em; }*/

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
  /* padding-left: 10px;
  padding-right: 10px; */
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

body {
  overflow: hidden;
}

/* On smaller screens, where height is less than 450px, change the style of the sidebar (less padding and a smaller font size) */
@media screen and (max-height: 450px) {
  .sidenavigation {
    padding-top: 15px;
  }
  .sidenavigation a {
    font-size: 18px;
  }
}

/* button {
  /* width: 10%;
  background-color: ;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  border-radius: 4px;
  cursor: pointer; */
/* width: 127px;
    height: 32px;
    padding: 0px 10px 0px 10px;
    background: #ebebeb;
    color: #aaaaaa;
    border-color: #aaaaaa;
    border-width: 1px;
    border-style: solid;
    border-radius: 3px 3px 3px 3px;
    font-family: "Julius Sans One";
    font-weight: bold;
    font-size: 14px;
    text-align: center; }*/

/* #login {
    padding: 60px 0;
  }

  .Login form {
    /* margin: 0 auto;
    max-width: 320px;
    display: inline-block;
    padding: 10px; */
/* position: relative;
    justify-self: center;
    display: flex;
    flex-basis: 100%;
    flex-direction: column;
    justify-content: space-between;
  } */
</style>
