using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InViewTimelineEditorTimelineBlockActionsFooterSection
{
    public static void Draw(InViewTimelineBlock block)
    {
        if (GUILayout.Button("Add Action"))
        {
            block.AddAction();
        }
    }
}