using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private UnityEvent _onCollide;
        [SerializeField, Range(0, 1)] private float _force;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            LeanTween.move(_camera.gameObject, _force * new Vector2(0.1f, 0.2f), 0.1f).setEase(LeanTweenType.easeShake);
            IRegected regected = collision.gameObject.GetComponent<IRegected>();
            if (regected == null) return;

            Vector2 direction = collision.GetContact(0).normal;
            regected.OnCollision(-direction);
            _onCollide.Invoke();
        }
    }
}