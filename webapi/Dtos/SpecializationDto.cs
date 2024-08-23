namespace webapi.Dtos
{
    public class SpecializationDto
    {
        public int Id { get; set; }
        public string specializationName { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
