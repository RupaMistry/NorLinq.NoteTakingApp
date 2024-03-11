namespace NorLinq.NoteTakingApp.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService<Note> _notesService;

        private readonly ILogger<NotesController> _logger;

        /// <summary>
        /// Initializes an instance of NotesController/>.
        /// </summary>
        public NotesController(INotesService<Note> service, ILogger<NotesController> logger)
        {
            this._notesService = service;
            this._logger = logger;
        }

        [Route("notes")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        /// <summary>
        /// Adds a new note to database
        /// </summary>
        public async Task<ActionResult<Note>> AddNote(Note note)
        {
            if (note == null)
            {
                this._logger.LogError("Supplied note param is null", nameof(note));
                return BadRequest();
            }

            int result = await this._notesService.Add(note);

            this._logger.LogInformation($"Note with ID:{note.ID} created successfully.");

            return CreatedAtAction(nameof(GetNote), new { id = note.ID }, note);
        }

        [HttpGet]
        [Route("notes")]
        [ProducesResponseType(typeof(IReadOnlyList<Note>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        /// <summary>
        /// Gets all the notes list
        /// </summary>
        public async Task<ActionResult<IReadOnlyList<Note>>> GetNotes()
        {
            var notes = await this._notesService.GetAll(); 

            if (notes == null)
            {
                this._logger.LogInformation("No Notes found in database", nameof(notes));
                return NotFound();
            }

            this._logger.LogInformation("Notes list returned successfully.");
            return Ok(notes);
        }

        [HttpGet]
        [Route("notes/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Note), (int)HttpStatusCode.OK)]
        /// <summary>
        /// Gets a note by ID
        /// </summary>
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            if (id <= 0)
            {
                this._logger.LogError("NoteID value is not correct", nameof(id));
                return BadRequest();
            }

            var note = await this._notesService.Get(id);

            if (note == null)
            {
                this._logger.LogError($"NoteID:{id} not found in database", nameof(note));
                return NotFound(new { Message = $"Note with id: {id} not found." });
            }

            this._logger.LogInformation($"Note with id:{note.ID} returned successfully.");
            return Ok(note);
        }

        [Route("notes")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        /// <summary>
        /// Updates a note in database
        /// </summary>
        public async Task<ActionResult<Note>> UpdateNote(int id, Note note)
        {
            if (note.ID != id || id <= 0)
            {
                this._logger.LogError("NoteID value is not correct", nameof(id));
                return BadRequest();
            }

            var updatedNote = await this._notesService.Update(id, note);

            if (updatedNote == null)
            {
                this._logger.LogError($"NoteID:{id} not found in database", nameof(note));
                return NotFound(new { Message = $"Note with id: {id} not found." });
            }

            this._logger.LogInformation($"Note with ID:{note.ID} updated successfully.");

            return CreatedAtAction(nameof(GetNote), new { id = note.ID }, null);
        }

        [Route("{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        /// <summary>
        /// Deletes a note by ID
        /// </summary>
        public async Task<IActionResult> DeleteNote(int id)
        {
            if (id <= 0)
            {
                this._logger.LogError("NoteID value is not correct", nameof(id));
                return BadRequest();
            }

            var rowsAffected = await this._notesService.Delete(id);

            if (rowsAffected == -1)
            {
                this._logger.LogError($"NoteID:{id} not found in database", nameof(id));
                return NotFound(new { Message = $"Note with id: {id} not found." });
            }

            this._logger.LogInformation($"Note with ID:{id} deleted successfully.");

            return Ok(rowsAffected);
        }
    }
}
