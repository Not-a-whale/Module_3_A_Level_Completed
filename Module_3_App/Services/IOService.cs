using Newtonsoft.Json;

namespace Module_3_App.Services
{
    internal class IOService
    {
        private static void CreateAFile(string FileName)
        {
            string Path = "../../../Backup/" + FileName + ".txt";

            if (!File.Exists(Path))
            {
                File.Create("../../../Backup/" + FileName + ".txt").Close();
            }
        }


        public static void WriteFile(List<string> Document, string FileName = "KornienkoProgramLogs")
        {
            string Path = "../../../Backup/" + FileName + ".txt";

            if (!File.Exists(Path))
            {
                CreateAFile(FileName);
            }

            if (File.Exists(Path))
            {
                using (StreamWriter sw = new StreamWriter(Path))
                {
                    foreach (string line in Document)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                }
            }
        }

        public static int LoadJson()
        {
            string jsonData = File.ReadAllText("../../../Config/config.json", System.Text.Encoding.ASCII);
            dynamic? jsonConfig = JsonConvert.DeserializeObject<object>(jsonData);
            if (jsonConfig != null)
            {
                return (int)jsonConfig.iterations;
            }
            else
            {
                WrongInput();
            }
            return 0;
        }

        public static void WrongInput()
        {
            Console.WriteLine("You don't have any config");
        }
    }
}
