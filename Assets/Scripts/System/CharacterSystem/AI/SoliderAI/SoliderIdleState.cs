using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defence
{
    public class SoliderIdleState : SoliderState
    {
        public SoliderIdleState(SoliderStateSystem system, SoliderStateId stateId)
            : base(system, stateId)
        {

        }

        public override void Atc()
        {
            throw new System.NotImplementedException();
        }

        public override void Reason()
        {
            throw new System.NotImplementedException();
        }
    }
}
