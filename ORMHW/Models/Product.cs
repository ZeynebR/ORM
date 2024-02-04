

namespace ORMHW.Models
{
    public class Product: BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }    
        public int CategoryId { get; set; } 
        public Category Category { get; set; }  
    }
}
