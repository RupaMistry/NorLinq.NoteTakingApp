import type Note from "@/models/Note";
import { apiUrls }  from '@/models/Constants'
import axios from 'axios';

export class NotesApiService {
 
  constructor() {}

  public async getAllNotes(): Promise<Note[]>{
     try { 
      const response = await axios.get(apiUrls.notesApiURL);
      
      return response.data; 
    } 
    catch (error) {
      
      console.error(error);
      return [];
    }
  } 
}