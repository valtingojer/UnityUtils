using UnityEngine;
using UnityEngine.Events;

public class TriggerColliderBaseActionEvoker : TriggerColliderBase
{
    
    [SerializeField]
    protected UnityEvent OnEnterAction;
    [SerializeField]
    protected UnityEvent OnStayAction;
    [SerializeField]
    protected UnityEvent OnExitAction;
    
    
    protected void OnActionEnter(GameObject other)
    {
        
        if (!OnEnter(other)) return;

        OnEnterAction?.Invoke();

    }

    protected void OnActionStay(GameObject other)
    {
        
        if (!OnStay(other)) return;

        OnStayAction?.Invoke();

    }

    protected void OnActionExit(GameObject other)
    {

        if (!OnExit(other)) return;

        OnExitAction?.Invoke();

    }
}
