using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InViewTimeline : MonoBehaviour
{
    [SerializeField]
    public Vector3 TriggerZoneCentre;
    [SerializeField]
    public Vector3 TriggerZoneSize;
    [SerializeField]
    public float LastInViewThreshold;

    [SerializeField]
    public List<InViewTimelineBlock> Blocks;

    [SerializeField]
    public Animator Animator;

    private float? lastTimeInView;
    private int activeBlockIndex;

    private BoxCollider collision;
    private Rigidbody rigidBody;

    private void Start()
    {
        collision = gameObject.AddComponent<BoxCollider>();
        collision.center = TriggerZoneCentre;
        collision.size = TriggerZoneSize;
        collision.isTrigger = true;

        rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.useGravity = false;

        //Blocks
        if (Animator == null)
        {
            Animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        switch (Blocks[activeBlockIndex].Type)
        {
            case InViewTimelineBlockType.AnimatorClip:
                if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    NextBlock();
                }
                break;
            case InViewTimelineBlockType.AnimatorTimestamp:
                if (Animator.GetCurrentAnimatorStateInfo(0).length * Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= Blocks[activeBlockIndex].EndTimeInSeconds)
                {
                    NextBlock();
                }
                break;
            default:
                break;
        }
    }

    public void PingInView()
    {
        lastTimeInView = Time.time;
    }

    public bool IsInView()
    {
        return Time.time - (lastTimeInView + LastInViewThreshold) <= 0;
    }

    public float? GetLastInViewTimestamp()
    {
        return lastTimeInView;
    }

    public int GetActiveBlockIndex()
    {
        return activeBlockIndex;
    }

    public void AddBlock()
    {
        if (Blocks == null)
        {
            Blocks = new List<InViewTimelineBlock>();
        }

        Blocks.Add(new InViewTimelineBlock());
    }

    public void RemoveBlock(int index)
    {
        Blocks.RemoveAt(index);
    }

    public void MoveUp(int index)
    {
        var temp = Blocks[index];
        Blocks[index] = Blocks[index - 1];
        Blocks[index - 1] = temp;
    }

    public void MoveDown(int index)
    {
        var temp = Blocks[index];
        Blocks[index] = Blocks[index + 1];
        Blocks[index + 1] = temp;
    }

    public void NextBlock()
    {
        var activeBlock = Blocks[activeBlockIndex];
        if (!activeBlock.ViewRequiredToContinue || IsInView())
        {
            activeBlockIndex++;
        }

        if (activeBlockIndex >= Blocks.Count)
        {
            activeBlockIndex = Blocks.Count - 1;
        }

        var activeBlockEndActions = activeBlock.Actions.Where(x => x.When == InViewTimelineBlockActionWhen.End);
        if (activeBlockEndActions.Count() > 0)
        {
            foreach (var action in activeBlockEndActions)
            {
                action.Execute(this);
            }
        }

        var nextBlock = Blocks[activeBlockIndex];
        switch (nextBlock.Type)
        {
            case InViewTimelineBlockType.AnimatorClip:
                Animator.Play(nextBlock.AnimationName, 0, 0);
                break;
            case InViewTimelineBlockType.AnimatorTimestamp:
                Animator.Play(nextBlock.AnimationName, 0, nextBlock.StartTimeInSeconds / Animator.GetCurrentAnimatorStateInfo(0).length);
                break;
            default:
                break;
        }

        var nextBlockEndActions = nextBlock.Actions.Where(x => x.When == InViewTimelineBlockActionWhen.Start);
        if (nextBlockEndActions.Count() > 0)
        {
            foreach (var action in nextBlockEndActions)
            {
                action.Execute(this);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (IsInView())
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawWireCube(transform.position + TriggerZoneCentre, TriggerZoneSize);
    }
}