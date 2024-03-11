<template>
  <header>
    <div class="container">
      <DashboardPanel />
      <ListNotes :notes="notes" />
    </div>
  </header>
</template>

<script lang="ts">

import { defineComponent, ref } from "vue";
import type Note from "./models/Note";
import ListNotes from './components/notes/list.vue'
import { NotesApiService } from "./api_services/NotesApiService";
import DashboardPanel from './components/dashboard/panel.vue'

export default defineComponent({
  name: 'App',
  components: { ListNotes, DashboardPanel },
  setup() {
    const notes = ref<Note[]>([]);

    return { notes }
  },
  async created() {
    this.notes = await new NotesApiService().getAllNotes();
  }
})

</script>
