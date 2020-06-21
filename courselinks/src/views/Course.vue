r =<template>
    <div>
        <b-container>
            <b-row >
                <b-col>
                    <b-card
                        no-body
                        style="max-width: 40rem;"
                        :img-src="require(`../assets/${course.category}.png`)"
                        img-alt="Image"
                        img-top
                    >
                        <b-card-header>
                            <h4 class="mb-0">{{course.title}}</h4>
                        </b-card-header>

                        <b-card-body>
                            <b-card-title>Description</b-card-title>
                            <b-card-text>
                                {{course.description}}
                            </b-card-text>
                        </b-card-body>


                        <b-card-body>
                            <a :href="course.link" class="card-link">Open Course</a>
                        </b-card-body>

                        <b-card-footer v-if="logged_in">
                            <b-button class="ml-5 mr-5" size="lg" :to="{name: 'edit', params: {id: this.$route.params.id}}"  variant="dark">Edit</b-button>
                            <b-button class="ml-5 mr-5" size="lg" variant="dark" v-b-modal.deletecourse>Delete</b-button>
                            <b-modal id="deletecourse" title="Delete Course" @ok="DeleteCourse">
                                <p>Are you sure you want to delete this course?</p>
                            </b-modal>
                        </b-card-footer>
                    </b-card>
                </b-col>
            </b-row>
        </b-container>
    </div>    
</template>

<script>
  import axios from 'axios';

  export default {
      props: ['logged_in'],
      data () {
          return {
              course: null,
          }
      },
      mounted () {
          axios.get('https://localhost:5001/api/Courses/' + this.$route.params.id )
          .then(response => (this.course = response.data))
          .catch(error => console.log(error))
      },
      methods: {
          DeleteCourse() {
              axios.delete('https://localhost:5001/api/Courses/' + this.$route.params.id)
              .then(response => response)
              .catch(error => console.log(error))
              this.$router.push('/')
              this.$router.go()
          }
      }
  }
</script>

<style scoped> </style>