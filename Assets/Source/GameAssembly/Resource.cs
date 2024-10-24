using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NuclearReactorTask
{
    public class Resource
    {
        private float timeUntilNextState;
        private State state;

        public enum State
        {
            Enrichment,
            HalfLife,
            Collapsed,
        }

        public event System.Action<State> OnStateChanged;

        public Resource(ResourceSO resourceSO)
        {
            SO = resourceSO;
            SetState(State.Enrichment);
        }

        public ResourceSO SO { get; private set; }

        public State CurrentState
        {
            get => state;
            private set
            {
                if (value == state) return;
                state = value;
                OnStateChanged?.Invoke(state);
            }
        }

        public void Activate()
        {
            if (CurrentState != State.HalfLife) return;
            SetState(State.Enrichment);
        }

        public void Tick()
        {
            timeUntilNextState -= Time.deltaTime;
            if (timeUntilNextState < 0)
            {
                switch(CurrentState)
                {
                    case State.Enrichment:
                        SetState(State.HalfLife);
                        break;

                    case State.HalfLife:
                        SetState(State.Collapsed);
                        break;
                }
            }
        }

        private void SetState(State newState)
        {
            switch (newState)
            {
                case State.Enrichment:
                    timeUntilNextState = SO.EnrichmentTime;
                    break;

                case State.HalfLife:
                    timeUntilNextState = SO.HalfLifeTime;
                    break;

                case State.Collapsed:
                    Debug.Log("OnResourceCollapsed");
                    break;
            }

            CurrentState = newState;
        }
    }
}
