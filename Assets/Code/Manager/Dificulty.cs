using UnityEngine;

public class Dificulty : MonoBehaviour
{
    [System.Serializable] private struct States
    {
        public int shildUse;
        public float cameraSize, movementLimit;
        public GameObject[] enemies;
    }

    [SerializeField] private Player.Movement _player;
    [SerializeField] private Transform _enemyLine, _playerLine;
    [SerializeField, Range(0, 1)] private float _enemyPercent, _playerPercent;
    [SerializeField] private Camera _camera;
    [Space]
    [SerializeField, Range(0, 1)] private float _time;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private States[] _states;
    
    private System.Action OnShieldUsed;
    private int _level, _current;

    private void Awake() => OnShieldUsed += AddDificulty;
    private void Start() => CameraSize(_camera.orthographicSize);

    private void AddDificulty()
    {
        if (_level >= _states.Length) return;
        
        _current++;
        if (_current < _states[_level].shildUse) return;

        _player.Limits = _states[_level].movementLimit;
        foreach (var item in _states[_level].enemies) item.SetActive(true);
        LeanTween.value(_camera.orthographicSize, _states[_level].cameraSize, _time).setOnUpdate(CameraSize).setEase(_curve);
        
        _level++;
        _current = 0;
    }
    private void CameraSize(float value)
    {
        _camera.orthographicSize = value;
        _enemyLine.position = new Vector2(0, _camera.ViewportToWorldPoint(_enemyPercent * Vector2.up).y);
        _playerLine.position = new Vector2(0, _camera.ViewportToWorldPoint(_playerPercent * Vector2.up).y);
    }
    public void DetectShield() => OnShieldUsed?.Invoke();
}