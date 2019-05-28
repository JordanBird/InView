using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class InViewTimelineEditorTimelineBlockSettingsSection
{
    public static void Draw(InViewTimelineBlock block)
    {
        block.ViewRequiredToContinue = GUILayout.Toggle(block.ViewRequiredToContinue, "View Required to Continue");
        block.BlocksToSkipIfInViewAtEnd = EditorGUILayout.IntField("Blocks to Skip if in View at End", block.BlocksToSkipIfInViewAtEnd);
    }
}