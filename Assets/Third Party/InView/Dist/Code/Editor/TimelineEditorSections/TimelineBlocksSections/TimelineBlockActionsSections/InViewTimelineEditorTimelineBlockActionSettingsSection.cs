using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class InViewTimelineEditorTimelineBlockActionSettingsSection
{
    public static void Draw(InViewTimelineBlockAction action)
    {
        action.Type = (InViewTimelineBlockActionType)EditorGUILayout.EnumPopup("Type", action.Type);
        action.When = (InViewTimelineBlockActionWhen)EditorGUILayout.EnumPopup("When", action.When);

        if (action.Type == InViewTimelineBlockActionType.ChangeScene)
        {
            action.SceneName = EditorGUILayout.TextField("Scene Name", action.SceneName);
            action.SceneChangeDelay = EditorGUILayout.FloatField("Scene Change Delay", action.SceneChangeDelay);
        }

        if (action.Type == InViewTimelineBlockActionType.PlayAudioClip)
        {
            action.AudioClip = (AudioClip)EditorGUILayout.ObjectField("Audio Clip", action.AudioClip, typeof(AudioClip), true);
            action.AudioClipStartDelay = EditorGUILayout.FloatField("Start Delay", action.AudioClipStartDelay);
        }

        if (action.Type == InViewTimelineBlockActionType.TriggerAudioSource)
        {
            action.AudioSource = (AudioSource)EditorGUILayout.ObjectField("Audio Clip", action.AudioSource, typeof(AudioSource), true);
            action.AudioSourceStartDelay = EditorGUILayout.FloatField("Start Delay", action.AudioClipStartDelay);
        }
    }
}