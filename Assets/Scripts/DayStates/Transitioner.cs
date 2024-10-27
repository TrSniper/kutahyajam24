using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class Transitioner : MonoBehaviour
{
    [SerializeField] private Canvas transitionCanvas;
    [SerializeField] private TextMeshProUGUI[] transitionTexts;
    [SerializeField] private float transitionTime = 1f;

    private CanvasGroup canvasGroup;
    private Tween fadeTween;

    private void Start()
    {
        canvasGroup = transitionCanvas.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        StartCoroutine(TestFade());
    }

    public void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        });
    }

    public void FadeOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        });
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = canvasGroup.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }

    private IEnumerator TestFade()
    {
        yield return new WaitForSeconds(2f);
        FadeOut(1f);
        yield return new WaitForSeconds(3f);
        FadeIn(1f);
    }
}