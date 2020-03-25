using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Defence
{
    public class EnemyAttackState : EnemyState
    {
        public EnemyAttackState(EnemyStateSystem system, EnemyId id):base(system,id)
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
