using Structurizr;
using Structurizr.Api;

/*
 * @authors
 * Leonardo Manuel Grau Vargas @LeoGrau on Github
 */
namespace c4_model
{
    class Program
    {
        public static void Main(string[] args)
        {
            HighLife();
        }

        static void HighLife()
        {
            //"Secret data"
            const long workspaceId = 73606;
            const string apiKey = "d290faa6-7078-4574-a46b-8698bb87063f";
            const string apiSecret = "a52ee68a-b309-4465-9546-040e731eb15c";
            
            StructurizrClient structurizrClient = new StructurizrClient(apiKey, apiSecret);
            Workspace workspace = new Workspace("Software Design & Patterns - C4 Model - HighLife", "eSports coaching App");
            ViewSet viewSet = workspace.Views;
            Model model = workspace.Model;
            
            //1.Context Diagram
            //Software System
            SoftwareSystem highLife = model.AddSoftwareSystem("HighLife","HighLife is a web application for people who likes videogames and want to teach or be coached");
            SoftwareSystem openDota = model.AddSoftwareSystem("OpenDota","OpenDota API Provides Dota 2 related data including advanced match data extracted from match replays");
            SoftwareSystem developerRiot   = model.AddSoftwareSystem("DeveloperRiot","Developer Riot provides data (matches, players, items) related to Riot Games like VALORANT, League Of Legends or Teamfight Tactics");
            SoftwareSystem developerToornament = model.AddSoftwareSystem("DeveloperToornament", "Developer Toornament provides Rocket League data (matches, players, items)");
            SoftwareSystem trackerGG = model.AddSoftwareSystem("TrackerGG", "Tracker GG provides CSGO data (matches, players, items)");
            SoftwareSystem googleCalendar = model.AddSoftwareSystem("Google Calendar", "Calendar provided by Google to set important dates");
            SoftwareSystem firebaseChat = model.AddSoftwareSystem("Firebase Chat", "Chat provided by Google Firebase. Just a simple chat.");
            
            //Persons
            Person coach = model.AddPerson("Coach", "The one in charge to teach beginners or not too talented gamers to improve their skills in-game");
            Person student = model.AddPerson("Padawan", "Beginners or not too talented who wish to improve their skills in-game");
            Person cafeBoss = model.AddPerson("Gaming House Boss", "Owner of gaming house or internet cafe who wants to make tournaments!");
            
            //Uses
            
            //Person uses
            coach.Uses(highLife, "Use it for coaching and participate in events!");
            student.Uses(highLife, "Use it for be coached and participate in events!");
            cafeBoss.Uses(highLife, "Use this in order to gain popularity and creating tournaments");
            
            //SoftwareSystem uses
            highLife.Uses(openDota, "Use it in order to get Dota 2 players data");
            highLife.Uses(developerRiot, "Use it in order to get VALORANT and League Of Legends players data");
            highLife.Uses(developerToornament, "Use it in order to get Rocket League players data");
            highLife.Uses(trackerGG, "Use it in order to get CS-GO players data");
            highLife.Uses(googleCalendar, "Use it in order to set Dates for important gaming events");
            highLife.Uses(firebaseChat, "Use it in order to chat with Coach and other players");
            
            SystemContextView contextView = viewSet.CreateSystemContextView(highLife, "Context", "Context Diagram");
            contextView.PaperSize = PaperSize.A4_Landscape;
            contextView.AddAllSoftwareSystems();
            contextView.AddAllPeople();
            
            coach.AddTags("Coach");
            student.AddTags("Padawan");
            cafeBoss.AddTags("Gaming House Boss");
            highLife.AddTags("HighLife");
            openDota.AddTags("OpenDota");
            developerRiot.AddTags("Developer Riot");
            developerToornament.AddTags("Developer Toornament");
            trackerGG.AddTags("TrackerGG");
            googleCalendar.AddTags("Google Calendar");
            firebaseChat.AddTags("Firebase Chat");

            //Styles
            Styles styles = viewSet.Configuration.Styles;
            //Styles for Persons
            styles.Add(new ElementStyle("Coach") { Background = "#2B3A67", Color = "#ffffff", Shape = Shape.Person });
            styles.Add(new ElementStyle("Padawan") { Background = "#2B3A67", Color = "#ffffff", Shape = Shape.Person });
            styles.Add(new ElementStyle("Gaming House Boss") { Background = "#2B3A67", Color = "#ffffff", Shape = Shape.Person });
            //Styles for Software Systems
            //My App
            styles.Add(new ElementStyle("HighLife") { Background = "#63D471", Color = "#000000", Shape = Shape.RoundedBox });
            //Externals Apps
            styles.Add(new ElementStyle("OpenDota") { Background = "#A5243D", Color = "#ffffff", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle("Developer Riot") { Background = "#A5243D", Color = "#ffffff", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle("Developer Toornament") { Background = "#A5243D", Color = "#ffffff", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle("TrackerGG") { Background = "#A5243D", Color = "#ffffff", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle("Google Calendar") { Background = "#A5243D", Color = "#ffffff", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle("Firebase Chat") { Background = "#A5243D", Color = "#ffffff", Shape = Shape.RoundedBox });
            
            //2.Containers Diagram
            Container landingPage = highLife.AddContainer("Landing Page", "Page with information about us and our app.", "HTML, CSS and JS");
            Container webApplication = highLife.AddContainer("Web Application", "Delivers static content and SPA", "Java Spring Boot");
            Container singlePageApplication = highLife.AddContainer("Single Page Application", "Coaching and tournament front-end application", "Angular");
            Container apiRest = highLife.AddContainer("API Rest", "Reads data from Database and delivery it in .JSON", "Java Spring Boot");
            Container dataBase = highLife.AddContainer("Database", "Stores user registration information, hashed authentification credentials, access log, etc", "Relational Database Schema MySQL");
            Container highLifeContext = highLife.AddContainer("High Life Context","HighLife Bounded Context","Java Spring Boot");
            Container chatContext = highLife.AddContainer("Chat Context","Bounded Context for messaging or chating between users","Java Spring Boot");
            Container tournamentContext = highLife.AddContainer("Tournament Context","Bounded Context for gaming house owners and tournaments or events","Java Spring Boot");
            
            //Uses
            //Uses for person
            //Landing page object
            coach.Uses(landingPage,"See information about our application, help and other stuff");
            cafeBoss.Uses(landingPage,"See information about our application, help and other stuff");
            student.Uses(landingPage,"See information about our application, help and other stuff");
            //Web Application page object
            coach.Uses(webApplication,"Use it in order to upload coaching rutines and got a job as a coach");
            cafeBoss.Uses(webApplication,"Invite people to his events");
            student.Uses(webApplication,"See tournaments and event, but, mainly, be guided by really good coaches in his favorite games");
            //Single Page Application object
            coach.Uses(singlePageApplication,"See information about our application, help and other stuff");
            cafeBoss.Uses(singlePageApplication,"See information about our application, help and other stuff");
            student.Uses(singlePageApplication,"See information about our application, help and other stuff");
            
            //Uses for containers
            singlePageApplication.Uses(apiRest, "Use it for catching data and use it with functionality");

            landingPage.Uses(webApplication, "Redirect to the application");

            apiRest.Uses(highLifeContext, "Use it in order to manage all High Life functions");
            apiRest.Uses(chatContext, "Use it in order to manage chat and messaging");
            apiRest.Uses(tournamentContext, "Use it in order to manage tournaments");
            
            highLifeContext.Uses(dataBase, "Reads database and return data in .JSON format");
            chatContext.Uses(dataBase, "Reads database and return data in .JSON format");
            tournamentContext.Uses(dataBase, "Reads database and return data in .JSON format");

            chatContext.Uses(firebaseChat, "Get functionality");
            highLifeContext.Uses(openDota, "Get functionality");
            highLifeContext.Uses(developerRiot, "Get functionality");
            highLifeContext.Uses(developerToornament, "Get functionality");
            highLifeContext.Uses(trackerGG, "Get functionality");
            tournamentContext.Uses(googleCalendar, "Reads database and return data in .JSON format");

            webApplication.Uses(singlePageApplication, "Delivers to the customer's web browser");
            
            //Add tags
            landingPage.AddTags("Landing Page");
            webApplication.AddTags("Web Application");
            singlePageApplication.AddTags("Single Page Application");
            apiRest.AddTags("Api Rest");
            dataBase.AddTags("Database");
            highLifeContext.AddTags("High Life Context");
            chatContext.AddTags("Chat Context");
            tournamentContext.AddTags("Tournament Context");
            
            //Styles
            styles.Add(new ElementStyle("Landing Page") { Background = "#2B3A67", Color = "#ffffff", Shape = Shape.WebBrowser });
            styles.Add(new ElementStyle("Web Application") { Background = "#2B3A67", Color = "#ffffff", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle("Single Page Application") { Background = "#2B3A67", Color = "#ffffff", Shape = Shape.WebBrowser });
            styles.Add(new ElementStyle("Api Rest") { Background = "#0F8B8D", Color = "#ffffff", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle("Database") { Background = "#143642", Color = "#ffffff", Shape = Shape.Cylinder });
            styles.Add(new ElementStyle("High Life Context") { Background = "#F2545B", Color = "#000000", Shape = Shape.Hexagon });
            styles.Add(new ElementStyle("Gamer Data Manager Context") { Background = "#F2545B", Color = "#000000", Shape = Shape.Hexagon });
            styles.Add(new ElementStyle("Chat Context") { Background = "#F2545B", Color = "#000000", Shape = Shape.Hexagon });
            styles.Add(new ElementStyle("Tournament Context") { Background = "#F2545B", Color = "#000000", Shape = Shape.Hexagon });

            ContainerView containerView = viewSet.CreateContainerView(highLife, "Container", "Container Diagram");
            containerView.PaperSize = PaperSize.A4_Landscape;
            containerView.AddAllElements();
            
            
            //3. Components Diagram
            // Component HighLife
            Component signInController = highLifeContext.AddComponent("Sign-in controller", "","Java Spring Boot");
            Component resetPasswordController = highLifeContext.AddComponent("Restart Password Controller", "", "Java Spring Boot");
            Component signUpController = highLifeContext.AddComponent("Sign-up Controller", "", "Java Spring Boot");
            Component matchingCoachesController = highLifeContext.AddComponent("Find Matching Coaches Controller", "", "Java Spring Boot");
            Component matchingStudentsController = highLifeContext.AddComponent("Find Matching Students Controller", "", "Java Spring Boot");
            Component dataController = highLifeContext.AddComponent("DataController", "", "Java Spring Boot");
            Component accountsController = highLifeContext.AddComponent("Account controller", "", "Java Spring Boot");
            Component subAccountsController = highLifeContext.AddComponent("Subaccount controller", "", "Java Spring Boot");
            // Component findMatchingCoachesController = highLifeContext.AddComponent("Find Matching Coaches Controller", "", "Java Spring Boot");

            signUpController.Uses(dataController, "");
            signUpController.Uses(signInController, "");
            signUpController.Uses(resetPasswordController, "");

            resetPasswordController.Uses(dataController, "");
            
            signInController.Uses(dataController, "");

            matchingCoachesController.Uses(dataController, "");
            matchingStudentsController.Uses(dataController, "");

            accountsController.Uses(subAccountsController, "");
            accountsController.Uses(dataBase, "");
            
            subAccountsController.Uses(dataController, "");

            dataController.Uses(developerToornament, "");
            dataController.Uses(developerRiot, "");
            dataController.Uses(trackerGG, "");
            dataController.Uses(openDota, "");

            dataController.Uses(dataBase, "");

            apiRest.Uses(dataController, "");

            webApplication.Uses(apiRest, "");

            //Add tags
            signInController.AddTags("SignInController");
            resetPasswordController.AddTags("ResetPasswordController");
            signUpController.AddTags("SignUpController");
            matchingCoachesController.AddTags("MatchingCoachesController");
            matchingStudentsController.AddTags("MatchingStudentsController");
            dataController.AddTags("DataController");
            accountsController.AddTags("AccountsController");
            subAccountsController.AddTags("SubaccountsController");
            
            
            //Styles
            styles.Add(new ElementStyle("SignInController") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("ResetPasswordController") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("SignUpController") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("MatchingCoachesController") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("MatchingStudentsController") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("DataController") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("AccountsController") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("SubaccountsController") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            

            
            ComponentView highLifecomponentsView = viewSet.CreateComponentView(highLifeContext, "High Life Components", "High Life Component Diagram");
            highLifecomponentsView.PaperSize = PaperSize.A4_Landscape;
            
            highLifecomponentsView.Add(webApplication);
            highLifecomponentsView.Add(apiRest);
            highLifecomponentsView.Add(dataBase);
            highLifecomponentsView.Add(openDota);
            highLifecomponentsView.Add(trackerGG);
            highLifecomponentsView.Add(developerToornament);
            highLifecomponentsView.Add(developerRiot);

            highLifecomponentsView.AddAllComponents();
            
            //Component Tournament
            Component tournamentController = tournamentContext.AddComponent("Tournament Controller", "","Java Spring Boot");
            Component dateTournamentController = tournamentContext.AddComponent("Date Tournament Controller", "","Java Spring Boot");
            Component leagueTournamentController = tournamentContext.AddComponent("League Tournament Controller", "","Java Spring Boot");
            // Component findMatchingCoachesController = highLifeContext.AddComponent("Find Matching Coaches Controller", "", "Java Spring Boot");

            tournamentController.Uses(leagueTournamentController, "");
            tournamentController.Uses(dateTournamentController, "");
            dateTournamentController.Uses(googleCalendar, "");
            leagueTournamentController.Uses(dataBase, "");
            
            apiRest.Uses(tournamentController, "");

            // Component s = highLifeContext.AddComponent("Sign-in controller", "","Java Spring Boot");
            // Component a = highLifeContext.AddComponent("Restart Password Controller", "", "Java Spring Boot");
            // Component f = highLifeContext.AddComponent("Sign-up Controller", "", "Java Spring Boot");
            
            //Add tags
            tournamentController.AddTags("Tournament Controller");
            dateTournamentController.AddTags("Date Tournament Controller");
            leagueTournamentController.AddTags("League Tournament Controller");


            //Styles
            styles.Add(new ElementStyle("Tournament Controller") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("Date Tournament Controller") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("League Tournament Controller") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });


            ComponentView tournamentComponentsView = viewSet.CreateComponentView(tournamentContext, "Tournament Components", "High Life Component Diagram");
            tournamentComponentsView.PaperSize = PaperSize.A4_Landscape;
            
            tournamentComponentsView.Add(webApplication);
            tournamentComponentsView.Add(apiRest);
            tournamentComponentsView.Add(dataBase);
            tournamentComponentsView.Add(googleCalendar);
            // tournamentComponentView.Add(openDota);
            // tournamentComponentView.Add(trackerGG);
            // tournamentComponentView.Add(developerToornament);
            // tournamentComponentView.Add(developerRiot);

            tournamentComponentsView.AddAllComponents();
            
            //Chat Component
            Component chatController = tournamentContext.AddComponent("Chat Controller", "","Java Spring Boot");
            Component messageController = tournamentContext.AddComponent("Message Controller", "", "");
            Component inboxController = tournamentContext.AddComponent("Inbox Controller","", "");
            Component multimediaController = tournamentContext.AddComponent("Multimedia Controller","", "");
            
            // Component findMatchingCoachesController = highLifeContext.AddComponent("Find Matching Coaches Controller", "", "Java Spring Boot");

            chatController.Uses(dataBase, "");
            chatController.Uses(firebaseChat, "");
            inboxController.Uses(chatController, "");
            chatController.Uses(multimediaController, "");
            chatController.Uses(messageController, "");

            // Component s = highLifeContext.AddComponent("Sign-in controller", "","Java Spring Boot");
            // Component a = highLifeContext.AddComponent("Restart Password Controller", "", "Java Spring Boot");
            // Component f = highLifeContext.AddComponent("Sign-up Controller", "", "Java Spring Boot");
            
            //Add tags
            chatController.AddTags("Chat Controller");
            inboxController.AddTags("Inbox Controller");
            multimediaController.AddTags("Multimedia Controller");
            messageController.AddTags("Message Controller");

            apiRest.Uses(chatController, "");


            //Styles
            styles.Add(new ElementStyle("Chat Controller") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("Inbox Controller") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("Multimedia Controller") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("Message Controller") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });


            ComponentView chatComponentsView = viewSet.CreateComponentView(tournamentContext, "Chat Components View", "High Life Component Diagram");
            chatComponentsView.PaperSize = PaperSize.A4_Landscape;
            
            chatComponentsView.Add(webApplication);
            chatComponentsView.Add(apiRest);
            chatComponentsView.Add(dataBase);
            chatComponentsView.Add(firebaseChat);

            chatComponentsView.AddAllComponents();
            
            //Drawing
            structurizrClient.UnlockWorkspace(workspaceId);
            structurizrClient.PutWorkspace(workspaceId, workspace);




        }
    }
}