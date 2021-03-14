﻿using TMPro;
using UnityEngine;

namespace Bones.Scripts.Shared.UI
{
    public class TextButton : MonoBehaviour
    {
        public TextMeshProUGUI buttonLabel;

        private void OnValidate()
        {
            if (gameObject && gameObject.activeSelf && enabled && buttonLabel) buttonLabel.text = gameObject.name;
        }
    }
}