using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private Dificulty _manager;
    [SerializeField] private Image _image;
    [SerializeField, Range(0, 10)] private int _amount;
    [SerializeField] private UnityEvent _callback;

    private float _current, _target;
    private bool _inUse;

    private void Awake() => _image.fillAmount = 0;
    private void Start() => _manager.OnShieldUsed += Add;
    private void Update()
    {
        if (Mathf.Abs(_current - _target) <= 0.01f) return;
        _current = Mathf.Lerp(_current, _target, Time.deltaTime * 5);
        _image.fillAmount = _current;
    }

    public void Add()
    {
        if (_inUse) return;
        if (_target < 1) _target = Mathf.Clamp01(_target += 1f / _amount);
        else
        {
            _inUse = true;
            _callback.Invoke();
        }
    }
    public void Reset()
    {
        _target = 0;
        _inUse = false;
    }
}