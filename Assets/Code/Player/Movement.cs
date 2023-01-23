using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(0, 10)] private float _limits;
        private Rigidbody2D _rgb;
        private bool _backwards;

        private void Awake() => _rgb = GetComponent<Rigidbody2D>();
        private void Update()
        {
            Vector2 position = transform.position;
            position.x = Mathf.Clamp(position.x, -_limits, _limits);

            if (Mathf.Abs(transform.position.x) <= _limits) return;
            transform.position = position;
            SwipeDirection();
        }
        private void FixedUpdate()
        {
            Vector2 direction = _backwards ? Vector2.right : Vector2.left;
            _rgb.MovePosition(_speed * Time.fixedDeltaTime * direction + (Vector2)transform.position);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector2 size = new Vector2(0.05f, 0.5f);
            Vector2 position = new Vector2(0, transform.position.y);

            for (int i = -1; i <= 1; i+=2)
                Gizmos.DrawCube(_limits * i * Vector2.right + position, size);
        }

        public void SwipeDirection()
        {
            _backwards = !_backwards;
        }
    }
}