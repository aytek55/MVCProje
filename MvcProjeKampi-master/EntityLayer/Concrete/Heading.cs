using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
  public  class Heading
    {
        [Key]  
        public int HeadingID { get; set; }
        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        //ilişki yapıyorum.property adıma catogery sınıfımdaki anahtar sütunuyla aynı veriyorum. 
        public int CategoryID { get; set; }
        // heading tablomun içinde CategoryID diye bir sütun olacak. sonrasında ilişki olduğunu belirtmek için; 
        // kategori sınıfımdan categori property si oluşturuyorum.
        //kategori sınıfında Icollection ile headingi ilişkilendirmiştim. aynı işlemi de bu sınıfta yapıyoruz 
        // ilgili sınıfran bir değer alarak yani category türünden property oluşturdum ve ilişkili tablomdaki id alanım yaptım.
        public virtual Category Category { get; set; }
        // sonrasında heading lede content sınıfımı ilişkilendireceğim için;
        public ICollection<Content> Contents { get; set; }

        public bool HeadingStatus { get; set; }

        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
