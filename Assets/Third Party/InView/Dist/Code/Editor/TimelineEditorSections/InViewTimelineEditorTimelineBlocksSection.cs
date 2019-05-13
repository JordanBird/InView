using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class InViewTimelineEditorTimelineBlocksSection
{
    public static void Draw(InViewTimeline timeline)
    {
        InViewTimelineEditorTimelineBlocksHeaderSection.Draw();
        
        for (var i = 0; i < timeline.Blocks.Count; i++)
        {
            InViewTimelineEditorTimelineBlockHeaderSection.Draw(i, timeline);
            InViewTimelineEditorTimelineBlockSettingsSection.Draw(timeline.Blocks[i]);
            InViewTimelineEditorTimelineBlockTypeSection.Draw(timeline.Blocks[i]);
            InViewTimelineEditorTimelineBlockActionsSection.Draw(timeline.Blocks[i]);
            InViewTimelineEditorTimelineBlockFooterSection.Draw(timeline);
        }

        InViewTimelineEditorTimelineBlocksFooterSection.Draw(timeline);
    }
}