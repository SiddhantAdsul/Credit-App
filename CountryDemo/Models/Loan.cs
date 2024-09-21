using CountryDemo.Data;

namespace CountryDemo.Models
{
    public class Loan
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public int Duration{ get; set; }
        public DateTime DateApplied { get; set; }
        public double Amount { get; set; }
        public Status Status { get; set; }
    }
}
