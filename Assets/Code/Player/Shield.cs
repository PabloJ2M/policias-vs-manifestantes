using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onCollide;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            IRegected regected = collision.gameObject.GetComponent<IRegected>();
            if (regected == null) return;

            Vector2 direction = collision.GetContact(0).normal;
            regected.OnCollision(-direction);
            _onCollide.Invoke();
        }
    }
}