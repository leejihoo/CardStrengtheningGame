using Interface;
using UnityEngine;

namespace Util
{
    [CreateAssetMenu(menuName = "ScriptableObject/Factory/GameClearPopupFactory", fileName = "GameClearPopupFactory")]
    public class GameClearPopupFactory : ScriptableFactory
    {
        public override IProduct Produce()
        {
            var card = Instantiate(Prefab, GameObject.Find("Canvas").transform, false);
            return card.GetComponent<OneButtonPopup>();
        }
    }
}
