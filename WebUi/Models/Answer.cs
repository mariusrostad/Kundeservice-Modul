namespace WebUi.Models {
    public class Answer {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set;}
        public Question Question { get; set; }
        public int Rating { get; set; }
    }
}