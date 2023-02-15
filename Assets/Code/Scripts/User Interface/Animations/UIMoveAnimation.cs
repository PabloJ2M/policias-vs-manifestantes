using UnityEngine.Events;

namespace UnityEngine.UI.Animation
{
    [ExecuteAlways]
    public class UIMoveAnimation : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] private float _time;
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private UnityEvent _onEndComplete, _onInitComplete;

        private Transform _self;
        private Vector2 _initPosition, _endPosition;

        private void Awake() => _self = transform;

        //Events
        public void LerpToEndPosition() => Lerp(_endPosition, _onEndComplete);
        public void LerpToInitPosition() => Lerp(_initPosition, _onInitComplete);
        private void Lerp(Vector2 point, UnityEvent action)
        {
            LeanTween.cancel(gameObject);
            LeanTween.move(gameObject, point, _time).setEase(_curve).setOnComplete(action.Invoke);
        }

        //Editor
        public Vector2 Init => _initPosition;
        public Vector2 Final => _endPosition;
        public void SaveEndPosition() => _endPosition = _self.position;
        public void SaveInitPosition() => _initPosition = _self.position;
        public void StopEditInitPosition() => _self.position = _endPosition;
        public void StartEditInitPosition() { _endPosition = _self.position; _self.position = _initPosition; }
    }
}