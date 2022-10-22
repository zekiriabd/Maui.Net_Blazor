using System.Text.Json;

namespace JsonFileCRUD.Pages
{
    public partial class Index
    {
        private UserM[] Users;
        private string dataResourceText;
        protected override async Task OnInitializedAsync()
        {
           // await ReadFile();
        }
        private void InitText()
        {
            var users = new List<UserM>()
                            {
                                new UserM(){Id=1,FirstName="Zekiri",LastName="Abdelali"},
                                new UserM(){Id=2,FirstName="Aloui",LastName="Ali"}
                            };

            dataResourceText = JsonSerializer.Serialize(users);
        }

        private async Task ReadFile()
        {
            try
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, "data2.json");
                if (!File.Exists(path))
                {
                    using StreamWriter file = new StreamWriter(path);
                }
                using (StreamReader sr = File.OpenText(path))
                {
                    dataResourceText = await sr.ReadToEndAsync();
                    Users = JsonSerializer.Deserialize<UserM[]>(dataResourceText);
                }

            }
            catch (FileNotFoundException ex)
            {
                dataResourceText = ex.Message;
            }
        }
        private async Task WriteFile()
        {
            try
            {
                string path = Path.Combine(FileSystem.AppDataDirectory, "data.json");
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(dataResourceText);
                }

                using (StreamReader sr = File.OpenText(path))
                {
                    dataResourceText = await sr.ReadToEndAsync();
                    Users = JsonSerializer.Deserialize<UserM[]>(dataResourceText);
                }
            }
            catch (FileNotFoundException ex)
            {
                dataResourceText = ex.Message;
            }
        }
    }

}