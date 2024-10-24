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

        public Settings CurrentSettings { get; private set; }

        public Resource(Settings settings)
        {
            CurrentSettings = settings;
            SetState(State.Enrichment);
        }

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
                    timeUntilNextState = CurrentSettings.EnrichmentTime;
                    break;

                case State.HalfLife:
                    timeUntilNextState = CurrentSettings.HalfLifeTime;
                    break;

                case State.Collapsed:
                    Debug.Log("OnResourceCollapsed");
                    break;
            }

            CurrentState = newState;
        }

        [System.Serializable]
        public struct Settings
        {
            [field: SerializeField]
            public string Name { get; private set; }

            [field: SerializeField]
            public Sprite EnrichmentSprite { get; private set; }

            [field: SerializeField]
            public Sprite HalfLifeSprite { get; private set; }

            [field: SerializeField]
            public Sprite CollapseSprite { get; private set; }

            [field: SerializeField]
            public float EnrichmentTime { get; private set; }

            [field: SerializeField]
            public float HalfLifeTime { get; private set; }
        }
    }
}
