using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Alprogram.Alvalues
{
    public class MusicSliderVolume : MonoBehaviour
    {
        /// <summary>
        /// The name of the exposed paramerter of the Audio mixer
        /// </summary>
        [SerializeField] private string group;
        [SerializeField] private AudioMixer master;
        [SerializeField] Slider slider;

        private void Awake()
        {
            slider.onValueChanged.AddListener(SliderVolumeController);
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(SliderVolumeController);
        }

        private void SliderVolumeController(float value)
        {
            master.SetFloat(group, value);
        }
    }
}
