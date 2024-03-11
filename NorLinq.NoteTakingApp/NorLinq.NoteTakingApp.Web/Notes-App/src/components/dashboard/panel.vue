<template>
    <div class="container center">
        <br>
        <dashboard-header />
        <div class="row">
            <CreateNote />
        </div>
    </div>
</template>

<script lang="ts">

import { defineComponent } from "vue";
import dashboardHeader from './header.vue';
import CreateNote from '../notes/create.vue'

export default defineComponent({
    name: 'DashboardPanel',
    components: { dashboardHeader, CreateNote },
    setup() {
    }
})

</script>