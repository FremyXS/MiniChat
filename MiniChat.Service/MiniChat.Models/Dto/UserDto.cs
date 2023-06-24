using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Models.Dto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Photo { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
