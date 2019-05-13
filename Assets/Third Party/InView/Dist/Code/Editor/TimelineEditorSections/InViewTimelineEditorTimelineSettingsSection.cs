using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class InViewTimelineEditorTimelineSettingsSection
{
    public static void Draw(InViewTimeline timeline)
    {
        GUILayout.Label("Timeline Settings", InViewTimelineEditorStyles.GetHeader());

        timeline.TriggerZoneCentre = EditorGUILayout.Vector3Field("Trigger Zone Centre", timeline.TriggerZoneCentre);
        timeline.TriggerZoneSize = EditorGUILayout.Vector3Field("Trigger Zone Size", timeline.TriggerZoneSize);
        timeline.LastInViewThreshold = EditorGUILayout.FloatField("Last in View Threshold", timeline.LastInViewThreshold);
        EditorGUILayout.HelpBox("Seconds that a timeline will be still considered in view after the user has looked away. 0 being the user must be looking at the timeline to continue.", MessageType.Info);

        timeline.Animator = (Animator)EditorGUILayout.ObjectField("Target Animator", timeline.Animator, typeof(Animator), true);
        EditorGUILayout.HelpBox("Target Animator for this timeline. If one isn't selected the timeline will search for an Animator attached to it.", MessageType.Info);
    }
}