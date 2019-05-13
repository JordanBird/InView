using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InViewTimelineBlock
{
    [SerializeField]
    public bool ViewRequiredToContinue;

    [SerializeField]
    public InViewTimelineBlockType Type;

    public List<InViewTimelineBlockAction> Actions;

    //Animator Clip Settings
    public string AnimationName;

    //Animator Timestamp Settings
    public float StartTimeInSeconds;
    public float EndTimeInSeconds;

    public void AddAction()
    {
        Actions.Add(new InViewTimelineBlockAction());
    }

    public void RemoveAction(int index)
    {
        Actions.RemoveAt(index);
    }

    public void MoveUp(int index)
    {
        var temp = Actions[index];
        Actions[index] = Actions[index - 1];
        Actions[index - 1] = temp;
    }

    public void MoveDown(int index)
    {
        var temp = Actions[index];
        Actions[index] = Actions[index + 1];
        Actions[index + 1] = temp;
    }
}