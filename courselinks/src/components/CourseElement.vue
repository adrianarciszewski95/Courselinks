<template>
    <div>
        <b-col>
            <b-card
                :header="course.category"
                header-bg-variant="dark"
                header-text-variant="light"
                :title="course.title"
                :img-src="require(`../assets/${course.category}.png`)"
                img-alt="Image"
                img-top
                tag="article"
                style="max-width: 20rem;"
                class="mb-5">
                <b-button :to="{name: 'course', params: {id: course.id}}" 
                variant="dark">Open</b-button>
            </b-card>
        </b-col>
    </div>
</template>

<script>
export default {
    props: ['course']
}
</script>

<style scoped> 

</style>
