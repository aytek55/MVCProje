using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }

        public bool ContentStatus { get; set; }
        //ContentYazar
        //ContentBaşlık
        // Başlıkla içeriği yani headingle content i bu şekilde ilişkilendiriyorum.
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }
        //  database tarafında fazla foreign key olduğu için writerıd hatası aldım.
        //  sorun çıktığı için nullable type yaptım
        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
