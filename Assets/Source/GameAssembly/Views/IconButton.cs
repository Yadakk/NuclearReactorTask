using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace NuclearReactorTask
{
    public class IconButton : MonoBehaviour
    {
        [field: SerializeField]
        public Image Icon { get; private set; }

        [field: SerializeField]
        public TextMeshProUGUI Tmpu { get; private set; }

        [field: SerializeField]
        public Button Button { get; private set; }
    }
}