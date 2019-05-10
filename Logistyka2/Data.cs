using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistyka2
{
    public class Data
    {
      
       public int id;
       public double product_price=0;
       public List<double> stock = new List<double>();  //lista zawierająca ilość surowców
    }
}
