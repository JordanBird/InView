using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class InViewTimelineEditorTimelineBlockTypeSection
{
    public static void Draw(InViewTimelineBlock block)
    {
        block.Type = (InViewTimelineBlockType)EditorGUILayout.EnumPopup("Type", block.Type);

        if (block.Type == InViewTimelineBlockType.AnimatorClip || block.Type == InViewTimelineBlockType.AnimatorTimestamp)
        {
            block.AnimationName = EditorGUILayout.TextField("Animation Name", block.AnimationName);
        }

        if (block.Type == InViewTimelineBlockType.AnimatorTimestamp)
        {
            block.StartTimeInSeconds = EditorGUILayout.FloatField("Start Time (Seconds)", block.StartTimeInSeconds);
            block.EndTimeInSeconds = EditorGUILayout.FloatField("End Time (Seconds)", block.EndTimeInSeconds);
        }
    }
}