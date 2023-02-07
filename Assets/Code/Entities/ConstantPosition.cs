using UnityEngine;

[ExecuteAlways]
public class ConstantPosition : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _weight;
    [SerializeField] private bool _preview;
    [SerializeField, Range(-1, 2)] private float _percentage;
    private float _current;

    private void Awake() => _preview = false;
    private void Update() { if (_preview) Setup(null); }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(0, _current), 0.1f * Vector2.one);
    }

    private float Position(Camera cam, Vector2 position, float percent) => cam.ViewportToWorldPoint(new Vector2(position.x, percent)).y;
    public void SetWeightToOne()
    {
        float value = Position(Camera.main, transform.position, _percentage);
        LeanTween.moveY(gameObject, value, 0.5f).setOnUpdate((float v) => _weight = v).setOnComplete(() => _weight = 1).setEase(LeanTweenType.easeInOutQuart);
    }
    public void Setup(Camera cam)
    {
        if (!cam) cam = Camera.main;

        Vector2 position = transform.position;
        _current = position.y = Position(cam, position, _percentage * _weight);
        transform.position = position;
    }
}