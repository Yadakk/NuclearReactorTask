using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NuclearReactorTask
{
    [CreateAssetMenu(fileName = "ResourceSO", menuName = "SO/ResourceSO", order = 51)]
    public class ResourceSO : ScriptableObject
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
