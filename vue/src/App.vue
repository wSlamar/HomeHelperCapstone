<template>
  <div id="app">
    <head>
      <link rel="preconnect" href="https://fonts.gstatic.com" />
      <link
        href="https://fonts.googleapis.com/css2?family=Julius+Sans+One&display=swap"
        rel="stylesheet"
      />
      <link
        rel="stylesheet"
        href="https://use.fontawesome.com/releases/v5.4.1/css/all.css"
        integrity="sha384-5sAR7xN1Nv6T6+dT2mhtzEpVJvfS3NScPQTrOxhwjIuvcA67KV2R5Jz6kr4abQsz"
        crossorigin="anonymous"
      />
    </head>
    <header id="banner">
      <div id="nav-bar">
        <div id="nav-group">
          <router-link
            v-bind:to="{ name: 'profile' }"
            style="text-decoration: none"
            >Home |</router-link
          >
          <a href="#" style="text-decoration: none"> About Us |</a>
          <a href="#" style="text-decoration: none"> Contact |</a>
          <a href="#" style="text-decoration: none"> Help</a>
        </div>

        <div id="nav">
          <router-link
            :to="{ name: 'profile' }"
            style="text-decoration: none"
            id="Username"
            v-if="$store.state.userid != ''"
            >{{ $store.state.user.username }} <i class="fas fa-user"></i>
          </router-link>
          <router-link
            v-bind:to="{ name: 'logout' }"
            v-if="$store.state.token !== ''"
            ><button class="Logout-Button" >Logout</button></router-link
          >
        </div>
      </div>
      <hr class="Horizontal-Line-Banner" />
      <img src="../src/Pics/HomeHelperLogo.jpg" alt="Home Helper Logo" />
      <!-- <hr class="Horizontal-Line-1" /> -->
      <!-- <h2 id="Slogan">
        We keep track of your home's needs, so you can just relax
      </h2> -->
      <hr class="Horizontal-Line-2" />
    </header>

    <div class="flex-container">
    <router-view />
    <footer>
      <!-- <div>
        <a href="#">About Us |</a>
        <a href="#"> Contact |</a>
        <a href="#"> Help</a>
      </div> -->
      <div id="container">
        <a href="http://www.twitter.com">
          <i class="social_media icon brands alt fab fa-twitter fa-2x"></i>
        </a>
        <a href="http://www.facebook.com">
          <i class="social_media icon brands alt fab fa-facebook-f fa-2x"></i>
        </a>
        <a href="http://www.linkedin.com">
          <i class="social_media icon brands alt fab fa-linkedin-in fa-2x"></i>
        </a>
      </div>
      <p class="copyright">&copy; Tech Elevator Cohort #15 Team Tilde, 2020</p>
    </footer>
    </div>
  </div>
</template>

<style>
html {
  font-size: 16px;
}

#nav {
  padding: 0 30px 0 0;
}

.Logout-Button {
  width: 120px;
  height: 32px;
  padding: 0px 10px 0px 10px;
  opacity: 90%;
  background: #c9f1fd;
  color: #232323;
  border-color: #232323;
  border-width: 1px;
  border-style: solid;
  border-radius: 35px 35px 35px 35px;
  font-family: "Julius Sans One";
  font-weight: bold;
  font-size: 14px;
  text-align: center;
  margin: -5px -100px 0px 20px;
  float: right;
  
}

#banner {
  /* grid-area: banner-grid; */
  height: 70%;
  margin: 0 auto;
  flex-basis: 30%;
  display: flex;
  flex-direction: column;
  justify-content: space-around;
}

header img {
  height: auto;
  width: 700px;
  display: block;
  margin-left: 65px;
  margin-right: auto;
  border: solid 5px rgb(195, 145, 45);
  /* display: flex;
  flex-direction: column; */
  /* padding: 10px 10px 10px 60px; */
  /* justify-content: flex-end; */
  /* margin-top: 30px;
  margin-bottom: 30px; */
  /* color: #559079; */
  /* border-color: #65c0c8;
	border-width: 1px;
	border-style: solid; */
}

#Slogan {
  padding: 0px 0px 0px 70px;
  color:  rgb(195, 145, 45);
  font-size: 2em;
  text-align: left;
}

.Horizontal-Line-1 {
  display: block;
  /* height: px; */
  width: 1200px;
  border: 0;
  border-top: 4px solid rgb(195, 145, 45);
  margin: 10px;
  padding: 0;
}

.Horizontal-Line-2 {
  display: block;
  height: 1px;
  border: 0;
  border-top: 4px solid rgb(195, 145, 45);
  margin: 0;
  margin-top: 15px;
  margin-bottom: 1px;
  padding: 0;
}

.Horizontal-Line-Banner {
  display: block;
  height: 1px;
  border: 0;
  border-top: 4px solid rgb(195, 145, 45);
  margin: 1em;
  padding: 0;
}

body {
  /* background-color: #ffe3ae; */
  background-image: linear-gradient(to right, #C9F1FD, rgb(230, 179, 78));
}
 
/* #app {
  /* background-image: linear-gradient(to right, #373B44, #73C8A9);  */


/* #grad {
} */

#nav-bar {
  font-weight: bold;
  font-size: 22px;
  color: rgb(175, 122, 15);
  padding: 20px 80px 10px 80px;
  align-items: baseline;
}

#nav-bar h3 {
  color: rgb(175, 122, 15);
  font-family: "Julius Sans One";
  font-weight: bold;
  font-size: 22px;
  /* text-align: justify; */
  /* display: flex; */
}

a {
  color: rgb(175, 122, 15);
}

a:visited {
  text-decoration: none;
  color: rgb(175, 122, 15);
}
a:hover {
  text-decoration: none;
  color: rgb(92, 89, 81);
}

* {
  font-family: "Julius Sans One", sans-serif;
  color: rgb(175, 122, 15);
  font-weight: bold;

}

header {
  height: 70px;
}

/* ul.no-bullets {
  list-style-type: none; 
  padding: 0; 
  margin: 0; 
} */

.social_media {
  padding: 15px;
  margin-right: 10px;
  display: block;
  font-size: 16px;
  color:  rgb(195, 145, 45);
}
 #nav-bar{
   display: flex;
   justify-content: space-between;
 }

 #nav{
   display: flex;
   
 }

 .copyright {
   font-weight: bold;
 }

.flex-container {
  display: flex;
  min-height: 100vh;
  flex-direction: column;
  justify-content: space-between;
}

/* router-view {
  min-height: 400px;
} */
</style>
