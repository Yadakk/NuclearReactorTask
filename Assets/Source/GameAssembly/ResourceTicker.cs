using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NuclearReactorTask
{
    public class ResourceTicker
    {
        private readonly Resource[] resources;

        public ResourceTicker(Resource[] resources)
        {
            this.resources = resources;
        }

        public void TickAll()
        {
            foreach(var resource in resources)
            {
                resource.Tick();
            }
        }
    }
}
