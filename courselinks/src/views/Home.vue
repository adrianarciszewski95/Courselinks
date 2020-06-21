<template>
  <div>
      <b-container>
        <b-row align-v="center">
            <CourseElement
            v-for="course in courses"
            :key="course.id"
            :course="course"/>
        </b-row>
      </b-container>
  </div>
</template>

<script>
  import CourseElement from '../components/CourseElement.vue';
  import axios from 'axios';

  export default {
      components: {
          CourseElement,
      },
      data () {
          return {
              courses: null,
              category:this.$route.params.category,
          }
      },
      mounted () {
          axios
          .get('https://localhost:5001/api/Courses')
          .then(response => (this.courses = response.data))
          .catch(error => console.log(error))
        }      
      }
</script>

<style scoped> </style>

