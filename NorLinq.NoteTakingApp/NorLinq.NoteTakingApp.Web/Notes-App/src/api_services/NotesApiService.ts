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

  public addNote(title:string,comment:string): Promise<Note> | any {
     try { 
      const note : Note={
                id:0,
                title:title,
                comment:comment };
      
      return axios.post(apiUrls.notesApiURL,note);      
    } 
    catch (error) { 
      console.error(error);
      return null;
    }
  }
}