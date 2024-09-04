using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Card
{
    [Serializable]
    public class MinionCardView
    {
        public GameObject Star;
        public TMP_Text Attack;
        public TMP_Text Hp;
        public TMP_Text Cost;
        public TMP_Text MinionAttribute;
        public Image MinionRatingFrame;
        public Image CardForeground;
        public Image CardPortrait;
    }
}
