# NorLinq HomeAssignment RupaMistry


# To set up and run the application, please follow below steps:
   1. Clone repository to your local dev environment using "https://github.com/RupaMistry/NorLinq.NoteTakingApp.git" or directly launch it in VS Studio
2. Open NorLinq.NoteTakingApp.sln and Build
3. Open Package manager console in VS and perform EF migrations   

        a. select "NorLinq.NoteTakingApp.Infrastructure" project
        b. run command "update-database"
5. Build & Run
6. Web API Project can be tested directly using Swagger UI 
7. Open SQL Studio and verify creation of "NotesApp" database with Notes table. 
8. Open "NorLinq.NoteTakingApp.Web" project in VS Code
9. Open Constants.ts file under "src\models" folder and update the notesApiURL value to your local API portal instance.
10. On terminal - run command "npm run dev" and navigate to the local UI portal
