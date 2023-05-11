using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class CanvasUtils
{
    public delegate void FinishCallback();

    public static void FadeIn(MonoBehaviour ctx, CanvasGroup canvasGroup, float duration, FinishCallback callback = null)
    {
        canvasGroup.alpha = 0;
        canvasGroup.gameObject.SetActive(true);
        ctx.StartCoroutine(IFadeIn(canvasGroup, duration, callback));
    }

    public static void FadeOut(MonoBehaviour ctx, CanvasGroup canvasGroup, float duration, FinishCallback callback = null)
    {
        canvasGroup.gameObject.SetActive(true);
        ctx.StartCoroutine(IFadeOut(canvasGroup, duration, callback));
    }

    private static IEnumerator IFadeIn(CanvasGroup canvasGroup, float duration, FinishCallback callback = null)
    {
        float time = 0;
        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1;
        if (callback != null) callback();
    }

    private static IEnumerator IFadeOut(CanvasGroup canvasGroup, float duration, FinishCallback callback = null)
    {
        float time = 0;
        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(1, 0, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 0;
        if (callback != null) callback();
    }
}
