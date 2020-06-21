<template>
    <div>
        <b-container>
            <b-row align-h="center" class="mt-5">
                <b-col cols="7">
                    <b-card class="p-3" style="max-width: 40rem;">
                        <b-form-group
                            v-if="this.$route.params.id"
                            label="Edit course"
                            label-align="center"
                            label-size="lg"
                            label-class="font-weight-bold pt-0"
                            class="mb-0">
                        </b-form-group>
                        <b-form-group
                            v-else
                            label="Create course"
                            label-align="center"
                            label-size="lg"
                            label-class="font-weight-bold pt-0"
                            class="mb-0">
                        </b-form-group>
                         <b-form-group
                            label="Title:"
                            label-align="left"
                            label-for="title">
                            <b-form-input
                                id="title"
                                v-model.trim="$v.title.$model"
                                :class="{'is-invalid':$v.title.$error, 'is-valid':!$v.title.$invalid}"
                                placeholder="title">
                            </b-form-input>
                            <div class="invalid-feedback">
                                <b-text-form v-if="!$v.title.required">Title is required</b-text-form>
                            </div>
                        </b-form-group>
                        <b-form-group 
                            label-align="left"
                            label="Category:"
                            label-for="category">
                            <b-form-select 
                                v-model.trim="$v.category.$model"
                                :class="{'is-invalid':$v.category.$error, 'is-valid':!$v.category.$invalid}"
                                :options="categories"
                                placeholder="category">
                            </b-form-select>
                            <div class="invalid-feedback">
                                <b-form-text v-if="!$v.category.required">Category is required</b-form-text>
                            </div>
                        </b-form-group>
                        <b-form-group
                            label-align="left"
                            label="Link:"
                            label-for="link">
                            <b-form-input
                                id="link"
                                v-model.trim="$v.link.$model"
                                :class="{'is-invalid':$v.link.$error, 'is-valid':!$v.link.$invalid}"
                                placeholder="link">
                            </b-form-input>
                            <div class="invalid-feedback">
                                <b-form-text v-if="!$v.link.required">Link is required</b-form-text>
                                <b-form-text v-if="!$v.link.url">Link must be in url type</b-form-text>
                            </div>
                        </b-form-group>
                        <b-form-group 
                            label-align="left"
                            label="Description:" 
                            label-for="description">
                            <b-form-textarea
                                id="description"
                                v-model="description"
                                placeholder="decription"
                                rows="3"
                                max-rows="3">
                            </b-form-textarea>
                        </b-form-group>
                        <b-form-group>
                            <b-button v-if="this.$route.params.id" @click="editCourse" type="submit" variant="dark">Edit</b-button>
                            <b-button v-else @click="createCourse" type="submit" variant="dark">Create</b-button>
                        </b-form-group>
                    </b-card>
                </b-col>
            </b-row>
        </b-container>
    </div>
</template>
<script>
  import axios from 'axios';
  import { required, url} from 'vuelidate/lib/validators'

  export default {
      data() {
          return {
              id: this.$route.params.id,
              title: '',
              category: '',
              link: '',
              description: '',
              categories: [
                  {value: 'Biology', text: 'Biology'},
                  {value: 'Economy', text: 'Economy'},
                  {value: 'History', text: 'History'},
                  {value: 'IT', text: 'IT'},
                  {value: 'Languages', text: 'Languages'},
                  {value: 'Maths', text: 'Maths'},
                  {value: 'Science', text: 'Science'},
                  {value: 'Other', text: 'Other'}
              ]
          }        
      },
      validations: {
          title: {
              required
          },
          category: {
              required
          },
          link: {
              required,
              url
          }
      },
      mounted () {
          if (this.$route.params.id) {
              axios.get('https://localhost:5001/api/Courses/' + this.$route.params.id )
              .then(response => (this.title = response.data.title, 
                                this.category = response.data.category,
                                this.link = response.data.link,
                                this.description = response.data.link))
          }
      },
      methods: {          
          createCourse() {
              axios.post('https://localhost:5001/api/Courses', {
                  title: this.title,
                  category: this.category,
                  link: this.link,
                  description: this.description
                  }).then(response => response.data)
                  this.title = ''
                  this.category = ''
                  this.link = ''
                  this.description = ''
                  },              
          editCourse() {
              axios.put('https://localhost:5001/api/Courses/' + this.$route.params.id, {
                  id: this.id,
                  title: this.title,
                  category: this.category,
                  link: this.link,
                  description: this.description
              }).then(response => response.data)
              this.$router.push({name: 'course', params: {id: this.$route.params.id}})
              this.$router.go()
              }, 
      }        

      }
</script>

<style scoped> </style>