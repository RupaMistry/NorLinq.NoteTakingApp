<template>
    <div class="container">
        <ul class="list-group">
            <div class="row">
                <li v-for="note in  notes" :key="note.id" class="col-4">
                    <br>
                    <div>
                        <div class="card" v-bind:style="{ 'background-color': note.colorCode }">
                            <DeleteNote :noteId="note.id" />
                            <div class="card-body text-center">
                                <h5 class="card-title">{{ note.title }}</h5>
                                <p class="card-text">
                                    {{ note.comment }}
                                </p>
                                <a href="#" class="btn btn-primary" data-toggle="tooltip" data-placement="top"
                                    title="Edit">Edit Note</a>
                            </div>
                            <div class="card-footer text-center text-body-secondary">
                                {{ new Date(note.createdDate).toDateString() }}
                            </div>
                        </div>
                    </div>
                </li>
            </div>
        </ul>
    </div>
</template>

<script lang="ts">
import type Note from '@/models/Note';
import { defineComponent, type PropType } from 'vue'
import DeleteNote from './delete.vue'

export default defineComponent({
    name: 'ListNotes',
    components: { DeleteNote },
    props: {
        notes: {
            required: true,
            type: Array as PropType<Note[]>
        }
    },
    setup() {
    }
})
</script>

<style scoped></style>
