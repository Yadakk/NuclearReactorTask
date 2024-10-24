using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NuclearReactorTask
{
    public static class ResourceContainer
    {
        private static Resource[] resources;
        public static Resource[] Resources
        {
            get
            {
                resources ??= LoadResources();
                return resources;
            }
            private set
            {
                resources = value;
            }
        }

        private static Resource[] LoadResources()
        {
            var resourceSOs = UnityEngine.Resources.LoadAll<ResourceSO>("ResourceSOs");
            Resource[] resources = new Resource[resourceSOs.Length];

            for (int i = 0; i < resourceSOs.Length; i++)
            {
                resources[i] = new(resourceSOs[i].Settings);
            }

            UnityEngine.Resources.UnloadUnusedAssets();
            return resources;
        }
    }
}
