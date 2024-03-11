<template>
    <div class="container center">
        <br>
        <dashboard-header />
        <div class="row">
            create new note popup
        </div>
    </div>
</template>

<script lang="ts">

import { defineComponent } from "vue";
import dashboardHeader from './header.vue';

export default defineComponent({
    name: 'DashboardPanel',
    components: { dashboardHeader },
    setup() {
    }
})

</script>