using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defence
{
    public class EnemyChaseState : EnemyState
    {
        public EnemyChaseState(EnemyStateSystem state,EnemyId id)
            :base(state,id)
        {

        }
        
        public override void Atc()
        {
            throw new NotImplementedException();
        }

        public override void Reason()
        {
            throw new NotImplementedException();
        }
    }
}
