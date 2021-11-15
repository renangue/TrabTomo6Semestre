using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[DefaultExecutionOrder(-1)]
[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFader : MonoBehaviour
{
    [SerializeField] bool startOn;
	[SerializeField] float fadeTime = 0.05f;
	[Space]
    [SerializeField] UnityEvent OnFadeIn_Start;
    [SerializeField] UnityEvent OnFadeIn_End;
    [SerializeField] UnityEvent OnFadeOut_Start;
    [SerializeField] UnityEvent OnFadeOut_End;

    CanvasGroup myCanvasGroup;

    bool isFading;
    bool isFadedIn;
    float currentFadeTime;
    float percOfFade;
	
    void Awake()
    {
        myCanvasGroup = this.GetComponent<CanvasGroup>();

        isFading = false;

        myCanvasGroup.alpha = (startOn) ? 1 : 0;
        myCanvasGroup.interactable = startOn;
        myCanvasGroup.blocksRaycasts = startOn;
        isFadedIn = startOn;
    }

    public void ToggleFade()
    {
        if (isFading) return;

        DoFade(!isFadedIn);
    }

	public void DoFade(bool isFadeIn, bool forceFade = false)
    {
        if (isFading) return;

        if (isFadeIn) DoFadeIn(forceFade);
        else DoFadeOut(forceFade);
	}

	public void DoFadeIn(bool forceFade = false)
    {
        if (!forceFade && (isFading || myCanvasGroup.alpha == 1)) return;

        if (fadeTime <= 0 || (forceFade && isFading))
        {
            StopAllCoroutines();
            SetCanvasFaded(true);
        }
        else
            StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        OnFadeIn_Start.Invoke();

        isFading = true;
        currentFadeTime = myCanvasGroup.alpha * fadeTime;
        percOfFade = currentFadeTime / fadeTime;

        while (isFading)
        {
            yield return null;

            currentFadeTime += Time.deltaTime;
            if (currentFadeTime > fadeTime)
            {
                currentFadeTime = fadeTime;
                isFading = false;
            }

            percOfFade = currentFadeTime / fadeTime;
            myCanvasGroup.alpha = Mathf.Lerp(0, 1, percOfFade);
        }

		OnFadeIn_End.Invoke();
        isFadedIn = true;
        myCanvasGroup.interactable = true;
        myCanvasGroup.blocksRaycasts = true;
    }

    public void DoFadeOut(bool forceFade = false)
    {
        if (!forceFade && (isFading || myCanvasGroup.alpha == 0)) return;

        if (fadeTime <= 0 || (forceFade && isFading))
        {
            StopAllCoroutines();
            SetCanvasFaded(false);
        }
        else
            StartCoroutine(FadeOut());
    }


    IEnumerator FadeOut()
    {
        OnFadeOut_Start.Invoke();

        isFading = true;
        //Debug.Log("Fade Out " + this.name, this);
        currentFadeTime = (1 - myCanvasGroup.alpha) * fadeTime;
        percOfFade = currentFadeTime / fadeTime;

        myCanvasGroup.interactable = false;
        myCanvasGroup.blocksRaycasts = false;

        while (isFading)
        {
            yield return null;

            currentFadeTime += Time.deltaTime;
            if (currentFadeTime > fadeTime)
            {
                currentFadeTime = fadeTime;
                isFading = false;
            }

			isFadedIn = false;
            percOfFade = currentFadeTime / fadeTime;
            myCanvasGroup.alpha = Mathf.Lerp(1, 0, percOfFade);
		}

        OnFadeOut_End.Invoke();
    }

    public void SetCanvasFaded(bool fadedIn)
    {
        myCanvasGroup.alpha = (fadedIn) ? 1 : 0;
        myCanvasGroup.interactable = fadedIn;
        myCanvasGroup.blocksRaycasts = fadedIn;
        isFadedIn = fadedIn;
        isFading = false;

        if (isFadedIn)
        {
            OnFadeIn_Start.Invoke();
            OnFadeIn_End.Invoke();
        }
        else
        {
            OnFadeOut_Start.Invoke();
            OnFadeOut_End.Invoke();
        }
	}

	public void SetInteractable(bool isInteractable)
	{
		myCanvasGroup.interactable = isInteractable;
		myCanvasGroup.blocksRaycasts = isInteractable;
	}

    public bool GetIsFading()
    {
        return isFading;
    }

	public bool GetIsFadedIn()
	{
		return isFadedIn;
	}

    public bool GetStartFaded()
	{
        return startOn;
	}

	public void SetAlpha(float newAlpha)
    {
        if (newAlpha >= 1)
		{
            newAlpha = 1;
			SetInteractable(true);
		}
		else if (newAlpha <= 0)
		{
			newAlpha = 0;
			SetInteractable(false);
		}

		myCanvasGroup.alpha = newAlpha;
	}
}