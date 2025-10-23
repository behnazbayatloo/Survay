namespace Survay.Domain.Dto
{
    public class GetPollDto
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }

        public string Title { get; set; }     
        
        public int QuestionCount { get; set; }  
    }
}