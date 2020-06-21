import Vue from 'vue'
import Router from 'vue-router'

import Home from './views/Home'
import Form from './views/Form'
import Course from './views/Course'
import Login from './views/Login'
import Register from './views/Register'

Vue.use(Router)

export default new Router({
    mode: 'history',
    routes: [
        {path: '/', component: Home},
        {path: '/course/:id', name: 'course', component: Course, props: true},
        {path: '/create',  component: Form},
        {path: '/edit/:id', name: 'edit', component: Form, props: true},
        {path: '/login',  component: Login},
        {path: '/register',  component: Register},
        {path: '/category/:category', component: Home, props: true}
    ]
})