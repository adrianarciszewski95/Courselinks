<template>
    <div>
        <b-navbar toggleable="lg" type="dark" variant="dark">
            <b-navbar-brand to="/">COURSELINKS APP</b-navbar-brand>

            <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

            <b-collapse id="nav-collapse" is-nav>
                <b-navbar-nav> 
                    <b-nav-item class="ml-4" to="/">Home</b-nav-item>
                    <b-nav-item  class="ml-4" v-if="logged_in" to="/create">Create new course</b-nav-item>
                </b-navbar-nav>

                <b-navbar-nav class="ml-auto">
                    <b-nav-text class="mr-4" v-if="logged_in"><b-icon icon="person-fill"></b-icon> {{user.userName}}</b-nav-text>
                    <b-button class="mr-4" v-else to="/register">Register</b-button>
                    <b-button class="mr-4" v-if="logged_in" @click="Logout">Logout</b-button>
                    <b-button class="mr-4" v-else to="/login">Login</b-button>
                </b-navbar-nav>
            </b-collapse>
        </b-navbar>
    </div>   
</template>

<script>
export default {
    props: ['user', 'logged_in'],
    methods: {
        Logout() {
            localStorage.removeItem('user-token')
            this.$router.go()
        }
    }
}
</script>

<style scoped> </style>