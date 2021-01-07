<template>
  
  <div>
    <header id="banner">      
      <router-link :to="{ name: 'login' }" v-if="$store.state.token == ''"><button class="Button-1" style="float:right">Log In</button></router-link>
      <router-link :to="{ name: 'register'  }" v-if="$store.state.token == ''"><button class="Button-2" style="float:right">Sign Up</button></router-link>
    </header>
    <main class="main">
      <div id="container">
      <img
        src="https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/brewster-mcleod-architects-1486154143.jpg"
        alt="A Picture of the home of our valued customer" class="HomePhoto" 
      />
      <img src="" alt="" />
      <div class="slogan">
        <p>We Keep Track Of Your Home's Needs,</p>
        <p>So You Can Just Relax . . .</p>
      </div>
      </div>
    </main>
</div>
   
</template>

<script>
export default {
  name: "welcome",
};
</script>

<style>
#banner {
  height: 70%;
  flex-basis: 30%;
  display: flex;
  flex-direction: column;
  position: relative;
  /* justify-content: right; */
}
/* #banner .Button-1 {
  display: flex;
  flex-direction: column;
  margin: 20px 20px;
  justify-content: flex-end;
} */
Main {
  margin-left: 200px;
  padding-left: 20px;
  padding-right: 20px;
  margin: 0;
  padding: 0;
  min-height: 100vh;
  display: flex;
}
.HomePhoto {
  width: 100%;
  height: 100%;
  display: block;
  margin: 0 auto;
  opacity: 30%;
  background-position: right;
  background-size: cover;
  background-repeat: no-repeat;
  /* border-color: #000000; */
  /* border-style: solid; */
}

.container {
  position: relative;
  text-align: center;
  color: white;
}

.slogan {
  position: absolute;
  top: 22%;
  left: 62%;
  transform: translate(-50%, -50%);
  font-size: 2.25em;
  text-align: center;
  /* color:  rgb(195, 145, 45); */
}

/* #grad {
  background-image: linear-gradient(#C9F1FD, rgb(175, 122, 15));

} */
.Button-1{
    width: 120px;
    height: 32px;
    padding: 0px 10px 0px 10px;
    opacity: 90%;
    background: #C9F1FD;
    color: #232323;
    border-color: #232323;
    border-width: 1px;
    border-style: solid;
    border-radius: 35px 35px 35px 35px;
    font-family: "Julius Sans One";
    font-weight: bold;
    font-size: 14px;
    text-align: center;
    /* position: absolute;
    left: 0px;
    right: 0px;
    top: 0px; */
    /* margin: auto; */
    /* bottom: 0px; */
    /* float: left; */
}
.Button-2{
    width: 120px;
    height: 32px;
    padding: 0px 10px 0px 10px;
    opacity: 90%;
    background: #C9F1FD;
    color: #232323;
    border-color: #232323;
    border-width: 1px;
    border-style: solid;
    border-radius: 35px 35px 35px 35px;
    font-family: "Julius Sans One";
    font-weight: bold;
    font-size: 14px;
    text-align: center;
    /* position: absolute;
    left: 0px;
    right: 0px;
    top: 0px;
    margin: auto;
    bottom: 0px;
    float: left; */
}

</style>