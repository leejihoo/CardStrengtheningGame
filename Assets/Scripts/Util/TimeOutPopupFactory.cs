using System;
using Enum;
using Interface;
using UnityEngine;

namespace Util
{
    [CreateAssetMenu(menuName = "ScriptableObject/Factory/TimeOutPopupFactory", fileName = "TimeOutPopupFactory")]
    public class TimeOutPopupFactory : ScriptableFactory
    {
        // private void OnValidate()
        // {
        //     FactoryType = FactoryType.TimeOutPopup;
        // }

        public override IProduct Produce()
        {
            var prefab = Instantiate(Prefab,GameObject.Find("Canvas").transform,false);
            return prefab.GetComponent<TimeLimitPopup>();
        }
    }
}
