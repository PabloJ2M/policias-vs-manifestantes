using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IRegected
{
    [SerializeField, Range(0, 10)] private float _speed;
    public Vector2 Direction { private get; set; }
    private Rigidbody2D _rgb;

    private void Awake() => _rgb = GetComponent<Rigidbody2D>();
    private void OnEnable() => Direction = Vector2.down;
    private void FixedUpdate() => _rgb.MovePosition(_speed * Time.fixedDeltaTime * Direction + (Vector2)transform.position);
    private void OnBecameInvisible() => gameObject.SetActive(false);

    public void OnCollision(Vector2 normal) => Direction = normal;
}