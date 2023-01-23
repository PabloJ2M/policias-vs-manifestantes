using UnityEngine;

namespace Player
{
    public class Shield : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            IRegected regected = collision.gameObject.GetComponent<IRegected>();
            if (regected == null) return;

            Vector2 direction = collision.GetContact(0).normal;
            regected.OnCollision(-direction);
        }
    }
}