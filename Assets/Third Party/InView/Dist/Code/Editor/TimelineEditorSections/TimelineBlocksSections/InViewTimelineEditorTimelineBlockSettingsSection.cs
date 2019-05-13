using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InViewTimelineEditorTimelineBlockSettingsSection
{
    public static void Draw(InViewTimelineBlock block)
    {
        block.ViewRequiredToContinue = GUILayout.Toggle(block.ViewRequiredToContinue, "View Required to Continue");
    }
}