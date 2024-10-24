using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NuclearReactorTask
{
    [CreateAssetMenu(fileName = "ResourceSO", menuName = "SO/ResourceSO", order = 51)]
    public class ResourceSO : ScriptableObject
    {
        [field: SerializeField]
        public Resource.Settings Settings { get; private set; }
    }
}
