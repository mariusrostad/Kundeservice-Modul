namespace Api.Model {
    public class Question {
        
        public int Id { get; set; }
        public string Message { get; set; }
        public Category Category { get; set; }
        public Rating Rating { get; set; }
    }
}