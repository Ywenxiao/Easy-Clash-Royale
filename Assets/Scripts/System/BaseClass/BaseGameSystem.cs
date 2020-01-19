using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defence
{
    public abstract class BaseGameSystem
    {
        public virtual void Init() { }
        public virtual void Update() { }
        public virtual void Release() { }
    }
}
