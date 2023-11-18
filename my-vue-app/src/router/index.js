import { createRouter, createWebHistory } from "vue-router";

const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: "/", component: () => import("../views/HelloWorld.vue") },
    { path: "/register", component: () => import("../views/Register.vue") },
    { path: "/login", component: () => import("../views/Login.vue") },
  ],
});
export default router;
