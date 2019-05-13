using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class InViewTimelineEditorTimelineBlockHeaderSection
{
    public static void Draw(int index, InViewTimeline timeline)
    {
        var suffix = "";
        if (index == timeline.GetActiveBlockIndex())
        {
            suffix += " [ACTIVE]";
        }

        GUILayout.BeginVertical(EditorStyles.helpBox);
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Block #{index + 1}{suffix}", InViewTimelineEditorStyles.GetHeader(), GUILayout.ExpandWidth(true));

        if (index > 0)
        {
            if (GUILayout.Button("Up", GUILayout.Width(30)))
            {
                timeline.MoveUp(index);

                return;
            }
        }

        if (index < timeline.Blocks.Count - 1)
        {
            if (GUILayout.Button("Down", GUILayout.Width(50)))
            {
                timeline.MoveDown(index);

                return;
            }
        }

        if (GUILayout.Button("X", GUILayout.Width(25)))
        {
            timeline.RemoveBlock(index);

            return;
        }

        GUILayout.EndHorizontal();
    }
}