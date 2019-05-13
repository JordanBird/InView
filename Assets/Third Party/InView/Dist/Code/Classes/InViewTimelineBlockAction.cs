using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class InViewTimelineBlockAction
{
    public InViewTimelineBlockActionType Type;
    public InViewTimelineBlockActionWhen When;

    //Scene Settings
    public string SceneName;
    public float SceneChangeDelay;

    public void Execute(InViewTimeline timeline)
    {
        switch (Type)
        {
            case InViewTimelineBlockActionType.ChangeScene:
                if (SceneChangeDelay <= 0)
                {
                    SceneManager.LoadSceneAsync(SceneName);

                    return;
                }

                timeline.StartCoroutine(LoadSceneCoroutine(SceneChangeDelay));
                break;
            default:
                break;
        }
    }

    private IEnumerator LoadSceneCoroutine(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);

        SceneManager.LoadSceneAsync(SceneName);
    }
}