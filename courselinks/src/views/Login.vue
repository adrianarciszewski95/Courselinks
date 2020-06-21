<template>
    <div>
        <b-container>
            <b-row align-h="center" class="mt-5">
                <b-col cols="7">
                    <b-card class="p-3" style="max-width: 40rem;">
                        <b-form-group
                            label="Login"
                            label-align="center"
                            label-size="lg"
                            label-class="font-weight-bold pt-0"
                            class="mb-0">
                        </b-form-group>
                         <b-form-group
                            label="Username:"
                            label-align="left"
                            label-for="username">
                            <b-form-input
                                id="username"
                                v-model.trim="$v.username.$model"
                                :class="{'is-invalid':$v.username.$error, 'is-valid':!$v.username.$invalid}"
                                placeholder="username">
                            </b-form-input>
                            <div class="invalid-feedback">
                                <b-form-text v-if="!$v.username.required">Username is required</b-form-text>
                            </div>
                         </b-form-group>
                        <b-form-group
                            label="Password:"
                            label-align="left"
                            label-for="password">
                            <b-form-input
                                id="password"
                                type="password"
                                v-model.trim="$v.password.$model"
                                :class="{'is-invalid':$v.password.$error, 'is-valid':!$v.password.$invalid}"
                                placeholder="password">
                            </b-form-input>
                            <div class="invalid-feedback">
                                <b-form-text v-if="!$v.username.required">Username is required</b-form-text>
                            </div>
                        </b-form-group>
                        <b-form-group
                            label="Confirm Password:"
                            label-align="left"
                            label-for="confirm-password">
                            <b-form-input
                                id="confirom-password"
                                type="password"
                                v-model.trim="$v.confirmpassword.$model"
                                :class="{'is-invalid':$v.confirmpassword.$error, 'is-valid':!$v.confirmpassword.$invalid}"
                                placeholder="confirm password">
                            </b-form-input>
                            <div class="invalid-feedback">
                                <b-form-text v-if="!$v.confirmpassword.required">Password is required</b-form-text>
                                <b-form-text v-if="!$v.confirmpassword.sameAsPassword">Password are not the same</b-form-text>
                            </div>
                        </b-form-group>
                        <b-form-group>
                            <b-button @click="getToken" type="submit" variant="dark">Login</b-button>
                        </b-form-group>
                    </b-card>
                </b-col>
            </b-row>
        </b-container>
    </div>
</template>

<script>
import axios from 'axios';
import { required, sameAs} from 'vuelidate/lib/validators'

  export default {
      data() {
          return {
              username: '',
              password: '',
              confirmpassword: '',
              error: ''
          }
      },
      validations: {
          username: {
              required
          },
          password: {
              required
          },
          confirmpassword: {
              required,
              sameAsPassword: sameAs('password')
          }
      },
      methods: {
          getToken() {
              if (this.password == this.confirmpassword) {
                  axios.post('https://localhost:5001/api/User/Login', {
                  username: this.username,
                  password: this.password
              }).then(response => localStorage.setItem('user-token', response.data.token))
              .catch(error => console.log(error), this.error = "Username or password is incorrect")
              this.$router.push('/')
              this.$router.go()
              } else {
                  this.error = "Password are not the same"
              }
          }
      }
  }
</script>
