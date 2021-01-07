<template>
  <div>
    <header class="header">
      <!-- <router-link :to="{ name: 'profile' }"><button>Back to My Homes</button></router-link> -->
    </header>
    <div class="sidenavigation">
      <!-- <button v-on:click="getUserInfo()">Show My Profile</button> -->
      <a><router-link :to="{ name: 'profile' }">My Profile</router-link></a>
      <a><router-link :to="{ name: 'myhomes' }">My Homes</router-link></a>
      <a><router-link v-bind:to="{ name: 'addhome' }">Add Home</router-link></a>
      <!-- <a><router-link :to="{ name: 'repairs' }">My Repairs</router-link></a>
      <a><router-link :to="{ name: 'appliances' }">My Appliances</router-link></a> -->
    </div>

    <Main>
      <h1>Please Add Your Home Here</h1>
      <!-- <p class="alert-danger">You must be authenticated to see this</p> -->
      <div class="add-home">
        <form  @submit.prevent="AddNewHome">
          <div
            class="alert alert-danger"
            role="alert"
            v-if="registrationErrors"
          >
            {{ registrationErrorMsg }}
          </div>
          <div id="basic_info">
            <div class="form-element">
              <label for="nickname">Home Name: </label>
              <input
                type="text"
                id="nickname"
                class="form-control"
                placeholder="Home Nickname"
                v-model="newHome.nickname"
                required
                autofocus
              />
            </div>
            <!-- <br /><br /> -->
            <div class="form-element">
              <label for="streetAddress">Street Address: </label>
              <input
                type="text"
                id="streetAddress"
                class="form-control"
                placeholder="Street Address"
                v-model="newHome.streetAddress"
                required
                autofocus
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
                v-model="newHome.city"
                required
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
                v-model="newHome.state"
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
                v-model="newHome.zip"
                required
              />
            </div>
            <!-- <br /><br /> -->
            <div class="form-element">
              <label for="typeOfHome">Choose your home type: </label>
              <select
                name="typeOfHome"
                id="typeOfHome"
                class="form-control"
                v-model="newHome.typeOfHome"
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
            <!-- <br /><br /> -->
            <div class="form-element">
              <label for="homeDescription">Description: </label>
              <textarea
                id="homeDescription"
                class="form-control"
                placeholder="Description of your home.  If you put OTHER as the type of your home, please specify here."
                v-model="newHome.description"
                required
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
                v-model="newHome.buildYear"
                required
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
                v-model="newHome.purchaseYear"
                required
              />
            </div><br><br>
            <div>Optional: Add Prefered Vendor and Service Provider</div><br>
            <button type="button" @click="showForm" @submit.prevent="showForm">{{needAddMoreInfo ? 'Cancel' : 'Vender/Service Provider' }}</button>
            <div id="show_hide" v-show="needAddMoreInfo">
              <div class="form-element">
                <label for="vendorname">Vendor Name: </label>
                <input
                  type="text"
                  id="vendorname"
                  class="form-control"
                  placeholder="Vendor Name"
                  v-model="newHome.vendorname"
                  required
                />
              </div>
              <div class="form-element">
                <label for="vendorspecialty">Vendor Specialty: </label>
                <input
                  type="text"
                  id="vendorspecialty"
                  class="form-control"
                  placeholder="Vendor Specialty"
                  v-model="newHome.vendorspecialty"
                  required
                />
              </div>
              <div class="form-element">
                <label for="vendorphone">Vendor Phone: </label>
                <input
                  type="text"
                  id="vendorphone"
                  class="form-control"
                  placeholder="xxx-xxx-xxxx"
                  v-model="newHome.vendorphone"
                  required
                />
              </div>
              <div class="form-element">
                <label for="vendoremail">Vendor Email: </label>
                <input
                  type="text"
                  id="vendoremail"
                  class="form-control"
                  placeholder="Vendor Email"
                  v-model="newHome.vendoremail"
                  required
                />
              </div>
              <div class="form-element">
                <label for="vendornotes">Vendor Notes: </label>
                <input
                  type="text"
                  id="vendornotes"
                  class="form-control"
                  placeholder="Vendor Notes"
                  v-model="newHome.vendornotes"
                  required
                />
              </div>
              <div class="form-element">
                <label for="storename">Store Name: </label>
                <input
                  type="text"
                  id="storename"
                  class="form-control"
                  placeholder="Store Name #xxxx"
                  v-model="newHome.storename"
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
                  v-model="newHome.storephone"
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
                  v-model="newHome.storenotes"
                  required
                />
              </div>
              <br />
            </div>
            <!-- <upload-photo/> -->
            <div><br>
              Upload Home Picture
              <vue-dropzone
                id="dropzone"
                class="mt-3"
                v-bind:options="dropzoneOptions"
                v-on:vdropzone-sending="addFormData"
                v-on:vdropzone-success="getSuccess"
                :useCustomDropzoneOptions="true"
              ></vue-dropzone>
            </div>
          </div>
          <br /><br />
          <button class="btn btn-lg btn-primary btn-block" type="submit">
            Add This Home
          </button>
          <button @click="clearForm">Cancel</button>
        </form>
      </div>
    </Main>
  </div>
</template>

<script>
import vue2Dropzone from "vue2-dropzone";
import "vue2-dropzone/dist/vue2Dropzone.min.css";

// import UploadPhoto from '../components/UploadPhoto.vue';
import UserService from "../services/UserService.js";
export default {
  components: {
    //  UploadPhoto,
    vueDropzone: vue2Dropzone,
  },
  name: "addhome",
  data() {
    return {
      dropzoneOptions: {
        url: "https://api.cloudinary.com/v1_1/deanzhangtech/image/upload",
        thumbnailWidth: 250,
        thumbnailHeight: 250,
        maxFilesize: 2.0,
        acceptedFiles: ".jpg, .jpeg, .png, .gif",
        uploadMultiple: false,
        addRemoveLinks: true,
        dictDefaultMessage:
          "Drop files here to upload. </br> Alternatively, click to select a file for upload.",
      },
      needAddMoreInfo: false,
      isBuiltByOwner: false,
      newHome: {
        nickname: "",
        streetAddress: "",
        city: "",
        state: "",
        zip: "",
        typeOfHome: "",
        description: "",
        buildYear: 0,
        purchaseYear: 0,
        picurl: "https://images.pexels.com/photos/106399/pexels-photo-106399.jpeg?cs=srgb&dl=pexels-binyamin-mellish-106399.jpg&fm=jpg",
        vendorname: "Recommoneded by HOME HELPER",
        vendoremail: "Home Helper",
        vendorphone: "Home Helper",
        vendornotes: "Please check with HOME HELPER",
        vendorspecialty: "Please check with HOME HELPER",
        storename: "Home Depot",
        storenotes: "The largest home improvement retailer in your neighborhood",
        storephone: "xxx-xxx-xxxx",
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },

  computed: {},

  methods: {
    showForm (){
      if (this.needAddMoreInfo == false){
        this.needAddMoreInfo = true;
      }
      else{
        this.needAddMoreInfo = false;
      }
    },
    AddNewHome() {
      UserService.addHome(this.newHome).then((response) => {
        if (response.status === 201) {
          alert("Congratulations! You have added a new home.");
          this.$router.push("/myhomes");
        }
      });
      // .catch((error) => {

      // })
    },
    clearForm() {
      this.newHome = [];
    },

    fillPurchaseYear(event) {
      if (event.target.value === "true") {
        this.newHome.purchaseYear = this.newHome.buildYear;
      }
    },
    addFormData(file, xhr, formData) {
      formData.append("api_key", "261873488686254"); // substitute your api key
      formData.append("upload_preset", "qesu1qfw "); // substitute your upload preset
      formData.append("timestamp", (Date.now() / 1000) | 0);
      formData.append("tags", "vue-app");
    },
    /******************************************************************************************
     * The getSuccess method is called when vdropzone-success event is fired
     ******************************************************************************************/
    getSuccess(file, response) {
      const imgUrl = response.secure_url; // store the url for the uploaded image
      this.newHome.picurl = imgUrl;
      this.$emit("image-upload", imgUrl); // fire custom event with image url in case someone cares
    },
  },
};
</script>

<style scoped>
dropzone{
  width: 1000px;
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
  color: rgb(138, 48, 48);
}
button {
  display: block;
  margin-bottom: 20px;
  justify-items: center;
}

textarea {
  height: 150px;
  width: 300px;
}

form {
  position: relative;
  justify-self: center;
  display: flex;
  flex-basis: 100%;
  flex-direction: column;
  justify-content: space-between;
}

.sidenavigation {
  height: auto; 
  width: 300px; 
  position: fixed; 
  z-index: 1; 
  top: 380px; 
  left: 73px;
  background-color: rgba(112, 109, 109, 0.287); 
  overflow-x: hidden; 
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

/* On smaller screens, where height is less than 450px, change the style of the sidebar (less padding and a smaller font size) */
@media screen and (max-height: 450px) {
  .sidenavigation {
    padding-top: 15px;
  }
  .sidenavigation a {
    font-size: 18px;
  }
}
#state,
#typeOfHome,
#isBuiltByOwner {
  height: 38px;
  width: 308px;
}

/* .sidenav {
  /* height: 75%; Full-height: remove this if you want "auto" height */
/* width: 250px; Set the width of the sidebar */
/* position: relative; /* Fixed Sidebar (stay in place on scroll) */
/* z-index: 10; Stay on top */
/* top: 0.4px; Stay at the top .4px  */
/* left: 0; */
/* padding: 0; */
/* margin: 0;
  overflow: hidden;
  background-color: #ffe3ae; */
/* overflow-x: hidden; Disable horizontal scroll */
/* padding-top: 80px; */
/* border-right-color: rgb(175, 122, 15);
  border-right-width: 3px;
} */
</style>