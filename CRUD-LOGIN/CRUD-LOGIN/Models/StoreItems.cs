using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CRUD_LOGIN.Models
{
    public class StoreItems
    {
     
        public int Id { get; set; }

     
        public string Name { get; set; }


        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
