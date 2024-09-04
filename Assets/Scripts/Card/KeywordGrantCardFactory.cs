using Interface;
using UnityEngine;
using Util;

namespace Card
{
    [CreateAssetMenu(menuName = "ScriptableObject/Factory/KeywordGrantCardFactory", fileName = "KeywordGrantCardFactory")]
    public class KeywordGrantCardFactory : ScriptableFactory
    {
        public override IProduct Produce()
        {
            var card = Instantiate(Prefab, GameObject.Find("Canvas").transform, false);
            return card.GetComponent<KeywordGrantCard>();
        }
    }
}
