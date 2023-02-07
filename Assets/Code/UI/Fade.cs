using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField, Range(0, 1)] private float _time;

    public string sceneName { private get; set; }

    private void Start()
    {
        bool value = string.IsNullOrWhiteSpace(sceneName);

        _canvasGroup.alpha = value ? 1 : 0;
        if (value) Tween(0, false, () => Destroy(gameObject));
        else Tween(1, true, () => SceneManager.LoadSceneAsync(sceneName));
    }
    private void Tween(float target, bool ignoreTimeScale, System.Action callback)
    {
        LeanTween.alphaCanvas(_canvasGroup, target, _time).setIgnoreTimeScale(ignoreTimeScale).setOnComplete(callback.Invoke);
    }
}