using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class InViewTimelineBlockAction
{
    public InViewTimelineBlockActionType Type;
    public InViewTimelineBlockActionWhen When;

    //Scene Settings
    public string SceneName;
    public float SceneChangeDelay;

    //PlayAudioClip Settings
    public AudioClip AudioClip;
    public float AudioClipStartDelay;

    //TriggerAudioSource Settings
    public AudioSource AudioSource;
    public float AudioSourceStartDelay;

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
            case InViewTimelineBlockActionType.PlayAudioClip:
                var gameObject = new GameObject($"Timeline Action: PlayAudioClip - {AudioClip.name}");
                var audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = AudioClip;
                audioSource.playOnAwake = false;
                audioSource.PlayDelayed(AudioClipStartDelay);

                Object.Destroy(gameObject, AudioClipStartDelay + AudioClip.length);

                return;
            case InViewTimelineBlockActionType.TriggerAudioSource:
                AudioSource.PlayDelayed(AudioSourceStartDelay);

                return;
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