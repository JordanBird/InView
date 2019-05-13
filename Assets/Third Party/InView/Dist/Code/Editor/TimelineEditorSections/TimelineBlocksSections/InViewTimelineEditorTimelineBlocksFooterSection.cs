using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InViewTimelineEditorTimelineBlocksFooterSection
{
    public static void Draw(InViewTimeline timeline)
    {
        if (GUILayout.Button("Add Block"))
        {
            timeline.AddBlock();
        }
    }
}