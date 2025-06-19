using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dto_s.BasketDto
{
    public class BasketDto
    {
        public string Id { get; set; }

        public ICollection<BasketItemDto> Items { get; set; } = [];
    }
}
