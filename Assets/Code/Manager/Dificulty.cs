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
    [SerializeField] private Camera _camera;
    [Space]
    [SerializeField, Range(0, 1)] private float _time;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private States[] _states;
    
    private System.Action OnShieldUsed;
    private int _level, _current;

    private void Start() => OnShieldUsed += AddDificulty;
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
    private void CameraSize(float value) => _camera.orthographicSize = value;
    public void DetectShield() => OnShieldUsed?.Invoke();
}