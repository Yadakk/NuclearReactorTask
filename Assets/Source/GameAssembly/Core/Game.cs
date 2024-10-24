using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NuclearReactorTask
{
    public class Game
    {
        private readonly ResourceViewSpawner buttonCreator;
        private readonly ResourceTicker resourceTicker;
        private readonly Resource[] resources;

        public Game(
            ResourceViewSpawner buttonCreator, 
            ResourceTicker resourceTicker, Resource[] resources)
        {
            this.buttonCreator = buttonCreator;
            this.resourceTicker = resourceTicker;
            this.resources = resources;
        }

        public void Init()
        {
            buttonCreator.CreateButtons(resources);
        }

        public void Tick()
        {
            resourceTicker.TickAll();
        }
    }
}
