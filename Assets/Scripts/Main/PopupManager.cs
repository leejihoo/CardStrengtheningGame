using System;
using System.Collections.Generic;
using Enum;
using UnityEngine;
using Util;

namespace Main
{
    public class PopupManager : MonoBehaviour
    {
        [SerializeField] private ScriptableFactory[] scriptableFactories;
        private Dictionary<FactoryType, ScriptableFactory> _popupFactoryDictionary;
        private Stack<GameObject> _managedPopup;

        private void Awake()
        {
            InitDictionary();
            _managedPopup = new Stack<GameObject>();
        }

        public GameObject CreatePopup(FactoryType factoryType)
        {
            var factory = _popupFactoryDictionary[factoryType];
            var product = factory.Produce() as Popup;
            
            if (factory.GetType() != typeof(TimeOutPopupFactory))
            {
                _managedPopup.Push(product.gameObject);
            }
            // if (factoryType != FactoryType.TimeOutPopup)
            // {
            //     _managedPopup.Push(product.gameObject);
            // }
            
            return product.gameObject;
        }

        public void RemoveTopPopup()
        {
            var popup = _managedPopup.Pop();
            Destroy(popup);
        }
        
        private void InitDictionary()
        {
            _popupFactoryDictionary = new Dictionary<FactoryType, ScriptableFactory>();
            
            foreach (var factory in scriptableFactories)
            {
                _popupFactoryDictionary[factory.FactoryType] = factory;
                Debug.Log(factory.FactoryType + "가 정상적으로 들어갔습니다.");
            }
        }
    }
}
