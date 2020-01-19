using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Defence
{
    public abstract class State
    {
        public string SceneName { get; protected set; }

        public StateControl control;

        public virtual void OnStart() { }
        public virtual void OnUpdate() { }
        public virtual void OnExit() { }

        protected State(string sceneName, StateControl control)
        {
            SceneName = sceneName;
            this.control = control;
        }
    }
}