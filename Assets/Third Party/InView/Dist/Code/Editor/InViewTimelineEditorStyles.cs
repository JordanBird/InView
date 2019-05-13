using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InViewTimelineEditorStyles
{
    public static GUIStyle GetHeader()
    {
        return new GUIStyle()
        {
            fontStyle = FontStyle.Bold
        };
    }

    public static GUIStyle GetInView()
    {
        return new GUIStyle()
        {
            normal = new GUIStyleState()
            {
                textColor = Color.green
            }
        };
    }

    public static GUIStyle GetOutOfView()
    {
        return new GUIStyle()
        {
            normal = new GUIStyleState()
            {
                textColor = Color.red
            }
        };
    }
}