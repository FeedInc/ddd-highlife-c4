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
            
            SoftwareSystem highLife = model.AddSoftwareSystem("HighLife","HighLife is a web application for people who likes videogames and want to teach or be coached");
            SoftwareSystem openDota = model.AddSoftwareSystem("OpenDota","OpenDota API Provides Dota 2 related data including advanced match data extracted from match replays");

            Person coach = model.AddPerson("Coach", "The one in charge to teach beginners or not too talented gamers to improve their skills in-game");
            Person student = model.AddPerson("Padawan", "Beginners or not too talented who wish to improve their skills in-game");
            
            //Uses
            coach.Uses(highLife, "Use it for coaching and participate in events!");
            student.Uses(highLife, "Use it for be coached and participate in events!");
            highLife.Uses(openDota, "Use it in order to get Dota 2 players data");
            
            SystemContextView contextView = viewSet.CreateSystemContextView(openDota, "Contexto", "Diagrama de contexto");
            contextView.PaperSize = PaperSize.A4_Landscape;
            contextView.AddAllSoftwareSystems();
            contextView.AddAllPeople();
            
            coach.AddTags("Coach");
            student.AddTags("Padawan");
            highLife.AddTags("HighLife");
            openDota.AddTags("OpenDota");
            // aircraftSystem.AddTags("AircraftSystem");
    
            //Styles
            Styles styles = viewSet.Configuration.Styles;
            styles.Add(new ElementStyle("Coach") { Background = "#0a60ff", Color = "#ffffff", Shape = Shape.Person });
            styles.Add(new ElementStyle("Padawan") { Background = "#0a60ff", Color = "#ffffff", Shape = Shape.Person });
            styles.Add(new ElementStyle("HighLife") { Background = "#008f39", Color = "#ffffff", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle("OpenDota") { Background = "#90714c", Color = "#ffffff", Shape = Shape.RoundedBox });



            //Drawing
            structurizrClient.UnlockWorkspace(workspaceId);
            structurizrClient.PutWorkspace(workspaceId, workspace);
        }
    }
}