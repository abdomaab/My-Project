namespace webapi.Dtos
{
    public class CollegeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Affiliation { get; set; }
        public string Address { get; set; }
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }   
}

