using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Alprogram.Alvalues
{
    /// <summary>
    /// Need a component that can be raycasted
    /// </summary>
    public class ButtonGroup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private UnityEvent buttonEvent;

        [Header("Colors")]
        [SerializeField] private Color NormalColor;
        [SerializeField] private Color HighlightedColor;
        [SerializeField] private Color PressedColor;
        [SerializeField] private Color DisabledColor;

        [Header("Components")]
        [SerializeField] private TextMeshProUGUI[] texts;
        [SerializeField] private Image[] imgs;

        private bool disabled = false;
        public bool Disable
        {
            get => disabled;
            set
            {
                disabled = value;
                ChangeDisable();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!disabled)
            {
                foreach (var item in texts)
                    item.color = PressedColor;

                foreach (var item in imgs)
                    item.color = PressedColor;

                buttonEvent?.Invoke();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!disabled)
            {
                foreach (var item in texts)
                    item.color = HighlightedColor;

                foreach (var item in imgs)
                    item.color = HighlightedColor;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!disabled)
            {
                foreach (var item in texts)
                    item.color = NormalColor;

                foreach (var item in imgs)
                    item.color = NormalColor;
            }
        }

        private void ChangeDisable()
        {
            if (!disabled)
            {
                foreach (var item in texts)
                    item.color = NormalColor;
                foreach (var item in imgs)
                    item.color = NormalColor;
            }

            else
            {
                foreach (var item in texts)
                    item.color = DisabledColor;
                foreach (var item in imgs)
                    item.color = DisabledColor;
            }
        }
    }
}
