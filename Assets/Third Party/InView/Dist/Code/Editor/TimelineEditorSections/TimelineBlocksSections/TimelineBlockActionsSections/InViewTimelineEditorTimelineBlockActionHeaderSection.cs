using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class InViewTimelineEditorTimelineBlockActionHeaderSection
{
    public static void Draw(int index, InViewTimelineBlock block)
    {
        var suffix = "";

        GUILayout.BeginVertical(EditorStyles.helpBox);
        GUILayout.BeginHorizontal();
        GUILayout.Label($"Action #{index + 1}{suffix}", InViewTimelineEditorStyles.GetHeader(), GUILayout.ExpandWidth(true));

        if (index > 0)
        {
            if (GUILayout.Button("Up", GUILayout.Width(30)))
            {
                block.MoveUp(index);

                return;
            }
        }

        if (index < block.Actions.Count - 1)
        {
            if (GUILayout.Button("Down", GUILayout.Width(50)))
            {
                block.MoveDown(index);

                return;
            }
        }

        if (GUILayout.Button("X", GUILayout.Width(25)))
        {
            block.RemoveAction(index);

            return;
        }

        GUILayout.EndHorizontal();
    }
}