using System;
using Enum;
using Interface;
using UnityEngine;

namespace Util
{
    [CreateAssetMenu(menuName = "ScriptableObject/Factory/RandomChoicePopupFactory", fileName = "RandomChoicePopupFactory")]
    public class RandomChoicePopupFactory : ScriptableFactory
    {
        public override IProduct Produce()
        {
            var card = Instantiate(Prefab, GameObject.Find("Canvas").transform, false);
            return card.GetComponent<RandomChoicePopup>();
        }

        private void OnValidate()
        {
            FactoryType = FactoryType.RandomChoicePopup;
        }
    }
}
