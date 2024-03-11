<template>
    <div>
        <br>
        <div class="text-center">
            <button type="button" class="btn btn-primary" @click="showModal()">
                Create New Note
            </button>
        </div>
        <!-- Modal -->
        <div class="modal fade" id="addNoteModal" tabindex="-1" aria-labelledby="addNoteModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="addNoteModalLabel">Create Note</h1>
                        <div class="dropdown" style="padding-left: 259px;">
                        </div>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"
                            id="btnClose"></button>
                    </div>
                    <div class="modal-body">
                        <div class="card text-center">
                            <div class="card-body">
                                <h5 class="card-title">
                                    <input class="title" type='text' maxlength="30" v-model="note.title"
                                        placeholder="Note Title" required />
                                </h5>
                                <textarea class="comment" maxlength="200" type='text' v-model="note.comment"
                                    placeholder="Note Comments" required />
                                <div class="btn-group" role="group" aria-label="Basic mixed styles example">
                                    <button type="button" class="btn"
                                        v-bind:style="{ 'background-color': ColorCode.Green }"
                                        @click="setColor(ColorCode.Green)">Green</button>
                                    <button type="button" class="btn"
                                        v-bind:style="{ 'background-color': ColorCode.Blue }"
                                        @click="setColor(ColorCode.Blue)">Blue</button>
                                    <button type="button" class="btn"
                                        v-bind:style="{ 'background-color': ColorCode.Red }"
                                        @click="setColor(ColorCode.Red)">Red</button>
                                </div>
                            </div>
                            <div class="card-footer text-body-secondary">
                                {{ new Date().toDateString() }}
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal"
                            id="close">Close</button>
                        <button type="button" class="btn btn-primary" @click="onCreateClick()">Create
                            Note</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue'
import { NotesApiService } from "../../api_services/NotesApiService"
import { Modal } from 'bootstrap'
import ColorCode from '@/models/ColorCode';

export default defineComponent({
    components: {},
    name: 'CreateNote',
    setup() {

        const note = ref<Note>({ title: '', comment: '', colorCode: ColorCode.Green });

        let addNoteModal = null;

        const showModal = () => {
            addNoteModal = new Modal(document.getElementById('addNoteModal'), {})
            addNoteModal.show();
        }

        const onCreateClick = () => {
            new NotesApiService()
                .addNote(note.value.title, note.value.comment, note.value.colorCode)
                .then((response: any) => {
                    console.log(response.data);

                    if (response.data != null && response.data.id > 0) {
                        alert('notes created successfully');
                        addNoteModal.hide();
                        location.reload();
                    }
                });
        }

        const setColor = (color: ColorCode) => {
            note.value.colorCode = color;
        }

        return { note, showModal, onCreateClick, ColorCode, setColor }
    }
})
</script>

<style scoped>
.title {
    width: 300px !important
}

.comment {
    height: 100px;
    width: 350px !important
}
</style>