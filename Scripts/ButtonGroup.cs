using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

namespace Alprogram.Alvalues
{

    [RequireComponent(typeof(Button))]
    public class ButtonGroup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Colors")]
        [SerializeField] private Color HighlightedColor;
        [SerializeField] private Color NormalColor;

        [Header("Components")]
        [SerializeField] private TextMeshProUGUI[] texts;
        [SerializeField] private Image[] imgs;


        public void OnPointerEnter(PointerEventData eventData)
        {
            foreach (var item in texts)
                item.color = HighlightedColor;

            foreach (var item in imgs)
                item.color = HighlightedColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            foreach (var item in texts)
                item.color = NormalColor;

            foreach (var item in imgs)
                item.color = NormalColor;
        }
    }
}
