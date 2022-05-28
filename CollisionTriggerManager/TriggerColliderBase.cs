using Enums;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColliderBase : MonoBehaviour
{
    
    [SerializeField]
    protected List<TagEnum> TagsToInteract;

    [SerializeField]
    protected bool DetectEnter = true;
    [SerializeField]
    protected bool DetectStay = true;
    [SerializeField]
    protected bool DetectExit = true;

    [SerializeField]
    protected bool RunOnlyOnce;
    [SerializeField]
    protected bool RunWithDelay = true;
    [SerializeField]
    protected int Delay = 1;

    protected float _delayTimer = 0;
    protected float _timer = 0;
    protected bool HasRun;


    protected TagEnum ConvertTagStringToTagEnum(string tag)
    {
        
        TagEnum result = TagEnum.None;
        try
        {
            result = (TagEnum)Enum.Parse(typeof(TagEnum), tag, true);
        }
        catch (System.Exception ex)
        {
            LoggerEventBroker.Log(ex, string.Format("Failed to convert tag string to tag enum: {0}", tag));
        }
        
        return result;
        
    }

    protected bool OnEnter(GameObject other)
    {
        
        if (!DetectEnter) return false;
        if (RunOnlyOnce && HasRun) return false;
        if (!TagsToInteract.Contains(ConvertTagStringToTagEnum(other.tag))) return false;
        if (RunWithDelay && _timer < _delayTimer) return false;

        _delayTimer = _timer + Delay;

        HasRun = true;

        return true;

    }

    protected bool OnStay(GameObject other)
    {

        if (!DetectStay) return false;
        if (RunOnlyOnce && HasRun) return false;
        if (!TagsToInteract.Contains(ConvertTagStringToTagEnum(other.tag))) return false;
        if (RunWithDelay && _timer < _delayTimer) return false;

        _delayTimer = _timer + Delay;

        HasRun = true;

        return true;
        
    }

    protected bool OnExit(GameObject other)
    {

        if (!DetectExit) return false;
        if (RunOnlyOnce && HasRun) return false;
        if (!TagsToInteract.Contains(ConvertTagStringToTagEnum(other.tag))) return false;
        if (RunWithDelay && _timer < _delayTimer) return false;

        _delayTimer = _timer + Delay;

        HasRun = true;

        return true;
    }
}
