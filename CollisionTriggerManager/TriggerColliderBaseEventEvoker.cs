using UnityEngine;

public class TriggerColliderBaseEventEvoker : TriggerColliderBase
{
    
    [SerializeField]
    protected GameEvent OnEnterEvent;
    [SerializeField]
    protected GameEvent OnStayEvent;
    [SerializeField]
    protected GameEvent OnExitEvent;

    
    protected void OnEventEnter(GameObject other)
    {
        
        if (!OnEnter(other)) return;

        OnEnterEvent?.Raise();
        
    }

    protected void OnEventStay(GameObject other)
    {

        if (!OnStay(other)) return;

        OnStayEvent?.Raise();

    }

    protected void OnEventExit(GameObject other)
    {

        if (!OnExit(other)) return;

        OnExitEvent?.Raise();

    }
}
