using BeTherServer.Models;

namespace BeTherServer.Models
{
    public class PreviousQuestions 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string username { get; set; } = null!;
        public string question { get; set; } = null!;
        public string date { get; set; } = null!;
        public string location { get; set; } = null!;
        public List<string>? answers { get; set; }
    }
}