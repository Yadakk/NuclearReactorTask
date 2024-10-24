using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NuclearReactorTask
{
    public class Bootstrap : MonoBehaviour
    {
        private Game game;

        private void Start()
        {
            ResourceViewSpawner buttonCreator = 
                FindObjectOfType<ResourceViewSpawner>();

            Resource[] resources = ResourceContainer.Resources;
            ResourceTicker resourceTicker = new(resources);

            game = new(buttonCreator, resourceTicker, resources);
            game.Init();
        }

        private void Update()
        {
            game.Tick();
        }
    }
}
