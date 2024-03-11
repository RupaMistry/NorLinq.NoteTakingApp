<template>
  <header>
    <div class="container">
      Hi
      <ListNotes :notes="notes" />
    </div>
  </header>
</template>

<script lang="ts">

import { defineComponent, ref } from "vue";
import type Note from "./models/Note";
import ListNotes from './components/notes/list.vue'

export default defineComponent({
  name: 'App',
  components: { ListNotes },
  setup() {
    const notes = ref<Note[]>([]);

    return { notes }
  }
})

</script>
