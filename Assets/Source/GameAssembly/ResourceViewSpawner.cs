using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NuclearReactorTask
{
    public class ResourceViewSpawner : MonoBehaviour
    {
        [SerializeField]
        private IconButton iconButtonPrefab;

        private ResourceViewModel[] resourceButtons;

        public void CreateButtons(Resource[] resources)
        {
            resourceButtons = new ResourceViewModel[resources.Length];

            for (int i = 0; i < resources.Length; i++)
            {
                var iconButton = Instantiate(iconButtonPrefab, transform);
                resourceButtons[i] = new(resources[i], iconButton);
            }
        }
    }
}
