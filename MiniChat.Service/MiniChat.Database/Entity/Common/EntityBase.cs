using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniChat.Database.Entity.Common
{
    public abstract class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; } = null;

        public void SetCreateTime()
        {
            CreateDate = DateTime.UtcNow;
        }

        public void SetDeleteDate()
        {
            DeleteDate = DateTime.UtcNow;
        }
    }
}
