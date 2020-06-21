<template>
    <div>
        <b-container>
            <b-row align-h="center" class="mt-5">
                <b-col cols="7">
                    <b-card class="p-3" style="max-width: 40rem;">
                        <b-form-group
                            label="Register"
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
                                <div class="invalid-feedback">
                                    <span v-if="!$v.username.required">Username is required</span>
                                </div>
                            </b-form-input>
                         </b-form-group>
                        <b-form-group
                            label="E-mail:"
                            label-align="left"
                            label-for="username">
                            <b-form-input
                                id="email"
                                type="email"
                                v-model.trim="$v.email.$model"
                                :class="{'is-invalid':$v.email.$error, 'is-valid':!$v.email.$invalid}"
                                placeholder="email">
                                <div class="invalid-feedback">
                                    <span v-if="!$v.email.required">Email is required</span>
                                    <span v-if="!$v.email.email">Must be an email type </span>
                                </div>
                            </b-form-input>
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
                                <div class="invalid-feedback">
                                    <span v-if="!$v.password.required">Password is required</span>
                                    <span v-if="!$v.password.minLength">Password must contain at least 6 characters</span>
                                </div>
                            </b-form-input>
                        </b-form-group>
                        <b-form-group>
                            <b-button @click="registerUser" type="submit" variant="dark">Register</b-button>
                        </b-form-group>
                    </b-card>
                </b-col>
            </b-row>
        </b-container>
    </div>
</template>
<script>
import axios from 'axios';
import { required, email, minLength} from 'vuelidate/lib/validators'

  export default {
      data() {
          return {

              username: '',
              email: '',
              password: '',
          }
      },
      validations: {
          username: {
              required
          },
          email: {
              required,
              email
          },
          password: {
              required,
              minLength: minLength(6)
          }
      },
      methods: {
          registerUser() {
              axios.post('https://localhost:5001/api/User/Register', {
                  username: this.username,
                  email: this.email,
                  password: this.password
              }).then(response => response.data)
              .catch(error => console.log(error))
              this.$router.push('/')
          } 
      }
  }
</script>
