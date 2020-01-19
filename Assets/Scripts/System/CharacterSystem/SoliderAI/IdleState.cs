using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBase
{
    public class IdleState : SoliderState
    {
        public IdleState(SoliderStateSystem system, SoliderId id)
            : base(system, id)
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
