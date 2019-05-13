using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InViewTimelineEditorTimelineInfoSection
{
    public static void Draw(InViewTimeline timeline)
    {
        GUILayout.Label("Timeline Info", InViewTimelineEditorStyles.GetHeader());

        if (timeline.IsInView())
        {
            GUILayout.Label(GetViewStatusText(timeline.IsInView()), InViewTimelineEditorStyles.GetInView());
            GUILayout.Label(GetLastInViewText(timeline.GetLastInViewTimestamp()), InViewTimelineEditorStyles.GetInView());
        }
        else
        {
            GUILayout.Label(GetViewStatusText(timeline.IsInView()), InViewTimelineEditorStyles.GetOutOfView());
            GUILayout.Label(GetLastInViewText(timeline.GetLastInViewTimestamp()), InViewTimelineEditorStyles.GetOutOfView());
        }
    }

    private static string GetViewStatusText(bool inView)
    {
        if (inView)
        {
            return "Timeline is Currently in View";
        }

        return "Timeline is Currently out of View";
    }

    private static string GetLastInViewText(float? time)
    {
        var output = "Last in View:";

        if (!time.HasValue)
        {
            return $"{output} Never";
        }

        var timeSince = Time.time - time.Value;

        if (timeSince < 1)
        {
            return $"{output} Just Now";
        }

        if (timeSince < 60)
        {
            return $"{output} {timeSince.ToString("F0")} Seconds Ago";
        }

        return $"{output} {(timeSince / 60).ToString("F0")} Minutes Ago";
    }
}