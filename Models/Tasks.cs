namespace Minimal.Models
{
    public class Tasks
    {
        public Tasks(Guid id, string title, bool done)
        {
            Id = id;
            Title = title;
            Done = done;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set;} = false;
    }
       
}