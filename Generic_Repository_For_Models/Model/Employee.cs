namespace GenericRepository.Model
{
    public class Employee : BaseEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Company { get; set; }    
        public int Salary { get; set; }    
    }
}
