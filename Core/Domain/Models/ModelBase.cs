using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ModelBase<Tkey> //we will make this model base as generic type
    {
        public Tkey Id { get; set; }




    }
}
