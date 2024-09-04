using System.Collections.Generic;
using Interface;
using UnityEngine;

namespace Util
{
    public class ThreeChoicePlacer : MonoBehaviour, IRandomChoicePlacer
    {
        [field: SerializeField] public RandomChoicePlaceSO Model { get; set; }
        public void Place(List<GameObject> choices)
        {
            if (Model.ChoiceCount != choices.Count)
            {
                Debug.LogError("선택지 갯수가 3개가 아닙니다.");
            }

            for (int i = 0; i < 3; i++)
            {
                //Debug.Log("작동중");
                //Rect rect = new Rect(Model.ChoicesPos[i].X,Model.ChoicesPos[i].Y,Model.ChoiceWidth,Model.ChoiceHeight);
                //choices[i].GetComponent<RectTransform>().rect.Set(Model.ChoicesPos[i].X,Model.ChoicesPos[i].Y,Model.ChoiceWidth,Model.ChoiceHeight);
                choices[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(Model.ChoicesPos[i].X, Model.ChoicesPos[i].Y);
                choices[i].GetComponent<RectTransform>().sizeDelta = new Vector2(Model.ChoiceWidth, Model.ChoiceHeight);

            }
        }
    }
}
