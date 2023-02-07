using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IRegected
{
    [SerializeField, Range(0, 10)] private float _speed, _delay;
    public Vector2 Direction { private get; set; }
    private Rigidbody2D _rgb;

    private void Awake() => _rgb = GetComponent<Rigidbody2D>();
    private void OnEnable() { Direction = Vector2.down; StartCoroutine(Hide()); }
    private void FixedUpdate() => _rgb.MovePosition(_speed * Time.fixedDeltaTime * Direction + (Vector2)transform.position);

    public void OnCollision(Vector2 normal) => Direction = normal;
    private System.Collections.IEnumerator Hide()
    {
        yield return new WaitForSeconds(_delay);
        gameObject.SetActive(false);
    }
}