import {RouteRecordRaw, createRouter, createWebHistory} from 'vue-router'
import Home from '@/components/Home.vue'

const routes: RouteRecordRaw[] = [
    {
        name: 'default',
        path: '/',
        component: Home
    },
    {
        name: 'Home',
        path: '/home',
        component: Home
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes: routes
});

export default router;