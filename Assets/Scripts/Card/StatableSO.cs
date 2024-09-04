using Interface;
using UnityEngine;

namespace Card
{
    [CreateAssetMenu(menuName = "ScriptableObject/Stat/AttackAndHp",fileName = "Stat")]
    public class StatableSO : ScriptableObject,IStatable
    {
        [field:SerializeField] public int Attack { get; set; }
        [field:SerializeField] public int Hp { get; set; }
        public GameObject statBuffPopupPrefab;
    }
}
