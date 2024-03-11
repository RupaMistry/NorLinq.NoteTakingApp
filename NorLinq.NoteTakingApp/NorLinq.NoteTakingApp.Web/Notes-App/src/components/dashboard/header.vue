<template>
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <h4 class="text-center white">
                Welcome to Notes Taking App!
            </h4>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue'
import { Modal } from 'bootstrap'

export default defineComponent({
    name: 'DashboardHeader',
    setup() {

    }
})
</script>

<style scoped>
.white {
    color: white
}
</style>
