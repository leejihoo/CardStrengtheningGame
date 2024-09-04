using Enum;
using Interface;
using UnityEngine;

namespace Util
{
    public abstract class ScriptableFactory : ScriptableObject, IFactory
    {
        public abstract IProduct Produce();
        [field: SerializeField] public GameObject Prefab { get; set; }
        [field: SerializeField] public FactoryType FactoryType { get; set; }
    }
}
