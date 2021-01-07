<template>
  <div>
    <header class="header"></header>
    <!-- <div class="sidenav">
      <router-link :to="{ name: 'profile' }"><button class="Buttons" style="float:right">User Profile</button></router-link>
      <router-link :to="{ name: 'myHomes' }"><button class="Buttons" style="float:right">My Properties</button></router-link>
      <router-link :to="{ name: 'addHome' }"><button class="Buttons" style="float:right">Add Home</button></router-link>
      <hr>    
    </div> -->
    <section class="form">
      <div id="register" class="text-center">
        <form class="form-register" @submit.prevent="register">
          <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
          <div
            class="alert alert-danger"
            role="alert"
            v-if="registrationErrors"
          >
            {{ registrationErrorMsg }}
          </div>
          <label for="username" class="sr-only">Username</label>
          <input
            type="text"
            id="username"
            class="form-control"
            placeholder="Username"
            v-model="user.username"
            required
            autofocus
          />
          <br />
          <button class="username-button" type="button" @click="verify">
            {{ usernameValid ? "Continue" : "Verify Username" }}
          </button>
          <br />
          <router-link :to="{ name: 'login' }">Have an account?</router-link>
          <br />

          <div v-show="showMoreField">
            <label for="password" class="sr-only">Password</label>
            <input
              type="password"
              id="password"
              class="form-control"
              placeholder="Password"
              v-model="user.password"
              required
            />
            <br /><br>
            <input
              type="password"
              id="confirmPassword"
              class="form-control"
              placeholder="Confirm Password"
              v-model="user.confirmPassword"
              required
            />
            <br /><br>

            <label for="firstName" class="sr-only">First Name</label>
            <input
              type="text"
              id="firstName"
              class="form-control"
              placeholder="First Name"
              v-model="user.firstName"
              required
            />
            <br /><br />
            <label for="lastName" class="sr-only">Last Name</label>
            <input
              type="text"
              id="lastName"
              class="form-control"
              placeholder="Last Name"
              v-model="user.lastName"
              required
            />
            <br /><br />
            <label for="email" class="sr-only">Email</label>
            <input
              type="email"
              id="email"
              class="form-control"
              placeholder="Email"
              v-model="user.Email"
              required
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
              required
            />
            <br /><br />
            <p>Billing Address</p>
            <label for="streetAddress" class="sr-only">Street Address</label>
            <input
              type="text"
              id="streetAddress"
              class="form-control"
              placeholder="Street Address"
              v-model="user.billingStreetAddress"
              required
            />
            <br /><br />
            <label for="city" class="sr-only">City</label>
            <input
              type="text"
              id="city"
              class="form-control"
              placeholder="city"
              v-model="user.billingCity"
              required
            />
            <br /><br />
            <label for="state" class="sr-only">State</label>
            <select
              name="state"
              id="state"
              placeholder="State"
              v-model="user.billingState"
              required
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
              required
            />
            <br /><br />
          </div>

          <button class="btn btn-lg btn-primary btn-block" type="submit">
            Create Account
          </button>
        </form>
      </div>
    </section>
  </div>
</template>

<script>
import authService from "../services/AuthService";
import UserService from "../services/UserService.js";
export default {
  name: "register",
  data() {
    return {
      usernames: [],
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        role: "user",
        firstName: "",
        lastName: "",
        Email: "",
        phoneNumber: "",
        billingStreetAddress: "",
        billingCity: "",
        billingState: "",
        billingZip: "",
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
      showMoreField: false,
      usernameValid: false,
    };
  },
  methods: {
    verify() {
      if (this.user.username) {
        UserService.getUsernames().then((response) => {
          if (response.status == 200) {
            this.usernames = response.data;
          }

          if (!this.usernames.includes(this.user.username.toLowerCase())) {
            this.usernameValid = true;
            this.showMoreField = true;
          } else {
            alert(
              "This username has been taken.  Please log in or try another username."
            );
          }
        });
      }
    },

    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
        windows.alert(this.registrationErrorMsg);
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/login",
                query: { registration: "success" },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    },
  },
};
</script>

<style>
/* button {
  display: block;
  margin-bottom: 20px;
  justify-items: center;
} */

.username-button {
  width: 160px;
  height: 36px;
  margin: auto;
  /* margin-top: 20px; */
  color: black;
}

/* .username-button {
  width: 150px;
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
  text-align: center;
} */

form {
  position: relative;
  justify-self: center;
  display: flex;
  flex-basis: 100%;
  flex-direction: column;
  justify-content: space-between;
}

button {
  width: 160px;
  height: 36px;
  margin: auto;
  margin-top: 20px;
  color: black;
}
</style>
