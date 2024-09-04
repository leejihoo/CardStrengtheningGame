using System;
using System.Collections;
using System.Collections.Generic;
using Main;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonEventController : MonoBehaviour
{
    [SerializeField] private Button button;
    private void Start()
    {
        button.onClick.AddListener(GameManager.Instance.LoadMainScene);
    }
}
