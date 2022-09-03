namespace ViewComponent.Pages
{
    public class IndexViewModel
    {
        public string Name { get; set; }
        public string Result { get; set; }
        public void GetText()
        {
            Result = Name + "22222";
        }
    }
}