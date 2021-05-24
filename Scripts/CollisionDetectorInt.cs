using UnityEngine;
using Alprogram.Alvalues;

namespace Alprogram.Alvalues
{
    public class CollisionDetectorInt : MonoBehaviour
    {
        [SerializeField] private IntValue value;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            value.CurrentValue++;
        }
    }
}
