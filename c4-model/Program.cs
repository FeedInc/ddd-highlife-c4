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
            
            //Software System
            SoftwareSystem highLife = model.AddSoftwareSystem("HighLife","HighLife is a web application for people who likes videogames and want to teach or be coached");
            SoftwareSystem openDota = model.AddSoftwareSystem("OpenDota","OpenDota API Provides Dota 2 related data including advanced match data extracted from match replays");
            SoftwareSystem developerRiot   = model.AddSoftwareSystem("DeveloperRiot","Developer Riot provides data (matches, players, items) related to Riot Games like VALORANT, League Of Legends or Teamfight Tactics");
            SoftwareSystem developerToornament = model.AddSoftwareSystem("DeveloperToornament", "Developer Toornament provides Rocket League data (matches, players, items)");
            SoftwareSystem trackerGG = model.AddSoftwareSystem("TrackerGG", "Tracker GG provides CSGO data (matches, players, items)");
            SoftwareSystem googleCalendar = model.AddSoftwareSystem("Google Calendar", "Calendar provided by Google to set important dates");
            SoftwareSystem FirebaseChat = model.AddSoftwareSystem("Firebase Chat", "Chat provided by Google Firebase. Just a simple chat.");
            
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
            highLife.Uses(FirebaseChat, "Use it in order to chat with Coach and other players");
            
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
            FirebaseChat.AddTags("Firebase Chat");
            // aircraftSystem.AddTags("AircraftSystem");
    
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


            //Drawing
            structurizrClient.UnlockWorkspace(workspaceId);
            structurizrClient.PutWorkspace(workspaceId, workspace);
        }
    }
}