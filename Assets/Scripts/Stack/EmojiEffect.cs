using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiEffect : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1f;

    public void Show()
    {
        if (!gameObject.activeSelf) 
        {
            gameObject.SetActive(true);
        }
        StartCoroutine(FadeRoutine());
    }

    IEnumerator FadeRoutine()
    {
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(0.5f); 

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f * t, transform.position.z);
            yield return null;
        }

        gameObject.SetActive(false);
    }

}
