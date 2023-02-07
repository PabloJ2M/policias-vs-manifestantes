using UnityEngine;
using UnityEngine.U2D;

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
    [SerializeField] private PixelPerfectCamera _pixelCamera;
    [SerializeField] private ConstantPosition[] _constants;
    [Space]
    [SerializeField, Range(0, 1)] private float _time;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private States[] _states;
    
    public System.Action OnShieldUsed;
    private int _level, _current;

    private void Awake() => OnShieldUsed += AddDificulty;
    private void Start() => CameraSize(_pixelCamera.assetsPPU, true);

    private void AddDificulty()
    {
        if (_level >= _states.Length) return;
        
        _current++;
        if (_current < _states[_level].shildUse) return;

        _player.Limits = _states[_level].movementLimit;
        foreach (var item in _states[_level].enemies) item.SetActive(true);
        LeanTween.value(_pixelCamera.assetsPPU, _states[_level].cameraSize, _time).setOnUpdate((float v) => CameraSize(v, false)).setEase(_curve);
        
        _level++;
        _current = 0;
    }
    private void CameraSize(float value, bool locked)
    {
        _pixelCamera.assetsPPU =  (int)value;
        if (locked) return;
        foreach (var item in _constants) item.Setup(_camera);
    }
    public void DetectShield() => OnShieldUsed?.Invoke();
}