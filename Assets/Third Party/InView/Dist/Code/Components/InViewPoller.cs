using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InViewPoller : MonoBehaviour
{
    public float PollFrequency;
    public float MaxDistance = 100;

    // Start is called before the first frame update
    void Start()
    {
        if (PollFrequency > 0)
        {
            StartCoroutine(PollTimelineCoroutine());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PollFrequency > 0)
        {
            return;
        }

        PollTimeline();
    }

    private void PollTimeline()
    {
        Physics.Raycast(transform.position, transform.forward * MaxDistance, out RaycastHit hit);

        var timeline = hit.collider?.gameObject?.GetComponent<InViewTimeline>();
        if (timeline == null)
        {
            return;
        }

        timeline.PingInView();
    }

    IEnumerator PollTimelineCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(PollFrequency);

            PollTimeline();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.blue);
    }
}
