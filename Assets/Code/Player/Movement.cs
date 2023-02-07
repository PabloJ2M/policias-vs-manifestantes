using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Camera _cam;
        [SerializeField] private InputAction _movement;
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(0, 10)] private float _limits;
        private Rigidbody2D _rgb;
        private Vector2 _target, _current;
        //private bool _backwards;

        public float Limits { set => _limits = value; }

        private void Awake() => _rgb = GetComponent<Rigidbody2D>();
        private void Start() => _movement.performed += SetPosition;
        private void OnEnable() => _movement.Enable();
        private void OnDisable() => _movement.Disable();
        //private void Update()
        //{
        //    Vector2 position = transform.position;
        //    position.x = Mathf.Clamp(position.x, -_limits, _limits);

        //    if (Mathf.Abs(transform.position.x) <= _limits) return;
        //    transform.position = position;
        //    SwipeDirection();
        //}
        private void Update()
        {
            _current.y = transform.position.y;
            _current.x = Mathf.Lerp(_current.x, _target.x, Time.deltaTime * _speed);
            _current.x = Mathf.Clamp(_current.x, -_limits, _limits);
        }
        private void FixedUpdate()
        {
            _rgb.MovePosition(_current);
            //Vector2 direction = _backwards ? Vector2.right : Vector2.left;
            //_rgb.MovePosition(_speed * Time.fixedDeltaTime * direction + (Vector2)transform.position);
        }
        private void SetPosition(InputAction.CallbackContext ctx)
        {
            _target = _cam.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
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
            //_backwards = !_backwards;
        }
    }
}