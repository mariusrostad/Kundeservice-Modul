namespace WebUi.Model {
    public class Answer {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set;}
        public Question Question { get; set; }
        public Rating Rating { get; set; }
    }
}