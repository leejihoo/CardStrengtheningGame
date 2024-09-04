using Interface;
using UnityEngine;
using Util;

namespace Card
{
    [CreateAssetMenu(menuName = "ScriptableObject/Factory/StatBuffCardFactory", fileName = "StatBuffCardFactory")]
    public class StatBuffCardFactory : ScriptableFactory
    {
        public override IProduct Produce()
        {
            var card = Instantiate(Prefab, GameObject.Find("Canvas").transform, false);
            return card.GetComponent<StatBuffCard>();
        }
    }
}
