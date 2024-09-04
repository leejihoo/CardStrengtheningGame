using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

namespace Util
{
    public class TimeLimitPopup : Popup
    {
        [SerializeField] private TimeSO timeSo;

        private IEnumerator StartTimer()
        {
            yield return new WaitForSeconds(timeSo.Time);
            Destroy(gameObject);
        }

        private void Start()
        {
            StartCoroutine(StartTimer());
        }
    }
}
