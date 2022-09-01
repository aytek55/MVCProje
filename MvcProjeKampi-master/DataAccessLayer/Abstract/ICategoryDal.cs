using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //Irespository interfaceinden kalıtsal aldığım tğm değerleri bu ve diğer interfacelerde
    //kullanıyorum. 
    public interface ICategoryDal : IRepository<Category>
    {
                
    }
}
