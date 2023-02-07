using UnityEngine;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField, Range(0, 1)] private float _time;
    [SerializeField] private UnityEvent<bool> _callback;

    public bool Skip { private get; set; }

    public void Show() => StartCoroutine(TutorialAnimation());
    private System.Collections.IEnumerator TutorialAnimation()
    {
        Freeze(true);
        LeanTween.alphaCanvas(_canvasGroup, 1, _time).setIgnoreTimeScale(true);
        
        yield return new WaitUntil(() => Skip);

        LeanTween.alphaCanvas(_canvasGroup, 0, _time).setIgnoreTimeScale(true).setOnComplete(() => Freeze(false));

        void Freeze(bool value)
        {
            _callback.Invoke(value);
            Time.timeScale = value ? 0 : 1;
        }
    }
}