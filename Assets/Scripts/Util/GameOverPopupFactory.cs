using Interface;
using UnityEngine;

namespace Util
{
    [CreateAssetMenu(menuName = "ScriptableObject/Factory/GameOverPopupFactory", fileName = "GameOverPopupFactory")]
    public class GameOverPopupFactory : ScriptableFactory
    {
        public override IProduct Produce()
        {
            var card = Instantiate(Prefab, GameObject.Find("Canvas").transform, false);
            return card.GetComponent<OneButtonPopup>();
        }
    }
}
