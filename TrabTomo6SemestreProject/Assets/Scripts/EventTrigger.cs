using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public bool playOnStart;
    public UnityEvent eventToTrigger;

    private void Start()
    {
        if (playOnStart)
            eventToTrigger.Invoke();
    }

    public void TriggerEvent()
    {
        eventToTrigger.Invoke();
    }

    public void TriggerEvent(float delayTime)
    {
        StartCoroutine(TriggerEventDelayed(delayTime));
    }

    IEnumerator TriggerEventDelayed(float time)
    {
        yield return new WaitForSeconds(time);

        TriggerEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eventToTrigger.Invoke();
        }
    }
}
