<template>
  <div>
    <header class="header">      
      
    </header>

    <div id="login" class="text-center">
      <form class="form-signin" @submit.prevent="login">
        <h1 class="SignIn">Please Sign In</h1>
        <div class="alert-danger" role="alert" v-if="invalidCredentials">
          Invalid username and password!
        </div>
        <div
          class="alert alert-success"
          role="alert"
          v-if="this.$route.query.registration"
        >
          Thank you for registering, please sign in.
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
        <br>
        <label for="password" class="sr-only">Password</label>
        <input
          type="password"
          id="password"
          class="form-control"
          placeholder="Password"
          v-model="user.password"
          required
        />
        <br>
        <button type="submit">Sign in</button>
        <br>
        <router-link :to="{ name: 'register' }">Need an account?</router-link>
      </form>
    </div>

    
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/profile");
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>

<style>
/* h1 {
  text-align: center;
} */

.alert-danger {
  text-align: center;
  color:rgb(138, 48, 48)
}

form {
  /* width: 100%; */
  padding: 12px 20px;
  /* margin: 30px 0 0 60px; */
  display: inline-block;
  /* border: 1px solid #ccc;
  border-radius: 4px; */
  box-sizing: border-box;
  margin: 0 auto;
  max-width: 320px;
}

button {
  /* width: 10%;
  background-color: ;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  border-radius: 4px;
  cursor: pointer; */
    width: 127px;
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
}

#login {
    padding: 60px 0;
  }

  .Login form {
    margin: 0 auto;
    max-width: 320px;
    display: inline-block;
    padding: 10px;
  }
</style>