using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    [Serializable]
    public class MainUIView
    {
        public TMP_Text PlayerMana;
        public Button SellButton;
        public Button CreationButton;
        public Button StrengthButton;
        public TMP_Text Price;
        public TMP_Text StrengthProbability;
        public TMP_Text Cost;
    }
}
