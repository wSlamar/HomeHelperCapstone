import Vue from 'vue'
import Router from 'vue-router'
import Profile from '../views/Profile.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import store from '../store/index'
import Welcome from '../views/Welcome.vue'
import AddHome from '../views/AddHome.vue'
import MyHomes from '../views/MyHomes.vue'
import HomeDetail from '../views/SingleHome.vue'
import Appliances from '../views/Appliances.vue'
import Repairs from '../views/Repairs.vue'
import Map from '../views/ShoppingMap.vue'
import StoreList from '../views/StoreList.vue'
import ServiceList from '../views/ServiceList.vue'
import EachStore from '../views/EachStore.vue'

Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'welcome',
      component: Welcome,
      meta: {
        requiresAuth: false
      }
    },
    { 
      path: '/profile',
      name: 'profile',
      component: Profile,
      meta: {
        requiresAuth: true
      }
    },
    { 
      path: '/myhomes',
      name: 'myhomes',
      component: MyHomes,
      meta: {
        requiresAuth: true
      }
    },
    { 
      path: '/addhome',
      name: 'addhome',
      component: AddHome,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: '/homedetail/:id',
      name: 'homedetail',
      component: HomeDetail,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/appliances/:id',
      name: 'appliances',
      component:Appliances,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/repairs/:id",
      name: "repairs",
      component: Repairs,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/map/:id",
      name: "map",
      component: Map,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/stores/:homeId',
      name: 'storelist',
      component: StoreList,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/services/:homeId',
      name: 'servicelist',
      component: ServiceList,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/eachstore/:homeId',
      name: 'eachstore',
      component: EachStore,
      meta: {
        requiresAuth: true
      }
    },
  ],
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
