using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InViewTimeline))]
public class InViewTimelineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var timeline = (InViewTimeline)target;

        EditorGUILayout.Space();
        InViewTimelineEditorTimelineInfoSection.Draw(timeline);
        EditorGUILayout.Space();

        InViewTimelineEditorTimelineSettingsSection.Draw(timeline);
        EditorGUILayout.Space();

        InViewTimelineEditorTimelineBlocksSection.Draw(timeline);

        EditorUtility.SetDirty(target);
    }
}