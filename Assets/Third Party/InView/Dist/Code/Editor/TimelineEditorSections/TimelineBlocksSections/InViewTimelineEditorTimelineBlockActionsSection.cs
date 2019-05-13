using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InViewTimelineEditorTimelineBlockActionsSection
{
    public static void Draw(InViewTimelineBlock block)
    {
        for (var i = 0; i < block.Actions.Count; i++)
        {
            InViewTimelineEditorTimelineBlockActionHeaderSection.Draw(i, block);
            InViewTimelineEditorTimelineBlockActionSettingsSection.Draw(block.Actions[i]);
            InViewTimelineEditorTimelineBlockActionFooterSection.Draw();
        }

        InViewTimelineEditorTimelineBlockActionsFooterSection.Draw(block);
    }
}