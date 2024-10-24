using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NuclearReactorTask
{
    public class ResourceViewModel
    {
        private readonly Resource resource;
        private readonly IconButton iconButton;

        public ResourceViewModel(Resource resource, IconButton iconButton)
        {
            this.resource = resource;
            this.iconButton = iconButton;

            this.resource.OnStateChanged += OnActiveChangedHandler;
            this.iconButton.Button.onClick.AddListener(OnButtonClickHandler);

            iconButton.Tmpu.text = resource.CurrentSettings.Name;

            UpdateView(this.resource.CurrentState);
        }

        private void OnActiveChangedHandler(Resource.State newState)
        {
            UpdateView(newState);
        }

        private void OnButtonClickHandler()
        {
            resource.Activate();
        }

        private void UpdateView(Resource.State newState)
        {
            switch (newState)
            {
                case Resource.State.Enrichment:
                    iconButton.Button.interactable = false;
                    iconButton.Icon.sprite = resource.CurrentSettings.EnrichmentSprite;
                    break;

                case Resource.State.HalfLife:
                    iconButton.Button.interactable = true;
                    iconButton.Icon.sprite = resource.CurrentSettings.HalfLifeSprite;
                    break;

                case Resource.State.Collapsed:
                    iconButton.Button.interactable = false;
                    iconButton.Icon.sprite = resource.CurrentSettings.CollapseSprite;
                    break;
            }
        }
    }
}
