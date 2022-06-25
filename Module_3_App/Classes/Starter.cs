using Module_3_App.Services;

namespace Module_3_App.Classes
{
    internal class Starter
    {   
        public int Limit { get; set; }
        public Starter()
        {
            Limit = IOService.LoadJson();
        }

        public void WriteToFile(List<string> logs)
        {
            Console.WriteLine(Limit);
            Console.WriteLine(logs.Count);
            Console.WriteLine(logs.Count % Limit == 0);
            if(logs.Count % Limit == 0)
            {
                Console.WriteLine("I am writing");
                IOService.WriteFile(logs, DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss"));
               
            }
        }
    }
}
