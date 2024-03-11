<template>
    <div class="card-header delete">
        <button type="button" class="btn-close" data-toggle="tooltip" data-placement="top" title="Delete note"
            aria-label="Delete" :key="noteId" @click="onDeleteClick"></button>
    </div>
</template>

<script lang="ts">
import { defineComponent, type PropType } from 'vue'
import { NotesApiService } from "../../api_services/NotesApiService"

export default defineComponent({
    name: 'DeleteNote',
    props: {
        noteId: {
            required: true,
            type: Number as PropType<Number>
        }
    },
    setup(props) {

        const onDeleteClick = () => {
            console.log(props.noteId);

            new NotesApiService()
                .deleteNote(props.noteId)
                .then((response: any) => {
                    console.log(response.data);

                    if (response.data != null && response.data > 0) {
                        alert('notes deleted successfully');
                        location.reload();
                    }
                });
        }

        return { onDeleteClick }
    },
})
</script>

<style>
.delete {
    padding-left: 304px
}
</style>
