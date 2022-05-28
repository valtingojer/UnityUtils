using System;
using System.Reflection;
using UnityEngine;

public class TriggerColliderBaseMethodEvoker : TriggerColliderBase
{
    
    [SerializeField]
    [Tooltip("The class and method in object or its parent to send other as parameter, ie: 'HealthManager'  'TakeDamage' . And the 'Collider' or 'Collision' will be sent as 'other' to 'TakeDamage' at 'HealthManager'")]
    protected ClassMethodPair[] OnEnterMethodAction;
    [SerializeField]
    [Tooltip("The class and method in object or its parent to send other as parameter, ie: 'HealthManager'  'TakeDamage' . And the 'Collider' or 'Collision' will be sent as 'other' to 'TakeDamage' at 'HealthManager'")]
    protected ClassMethodPair[] OnStayMethodAction;
    [SerializeField]
    [Tooltip("The class and method in object or its parent to send other as parameter, ie: 'HealthManager'  'TakeDamage' . And the 'Collider' or 'Collision' will be sent as 'other' to 'TakeDamage' at 'HealthManager'")]
    protected ClassMethodPair[] OnExitMethodAction;


    protected void CallMethodWithOther(GameObject other, string theClass, string theMethod)
    {
        
        try
        {
            var component = gameObject.GetComponent(theClass);
            if (component == null)
            {
                component = gameObject.GetComponentInParent(Type.GetType(theClass));
            }

            if (component == null)
            {
                throw new Exception(string.Format("the class {0} was not found", theClass));
            }

            MethodInfo method = component.GetType().GetMethod(theMethod);

            if (method == null)
            {
                throw new Exception(string.Format("the method {0} was not found", theMethod));
            }

            method.Invoke(component, new object[] { other });
        }
        catch (Exception ex)
        {
            LoggerEventBroker.Log(ex, string.Format("Failed to find enemy controller on {0}", gameObject.name));
        }
        
    }

    protected void CallMethodsWithOther(GameObject other, ClassMethodPair[] classMethodPairs)
    {
        
        foreach (var pair in classMethodPairs)
        {
            CallMethodWithOther(other, pair.Class, pair.Method);
        }
        
    }

    protected void OnMethodEnter(GameObject other)
    {
        
        if (!OnEnter(other)) return;
        
        if (OnEnterMethodAction == null || OnEnterMethodAction.Length == 0) return;

        CallMethodsWithOther(other, OnEnterMethodAction);
        
    }

    protected void OnMethodStay(GameObject other)
    {
        
        if (!OnStay(other)) return;
        
        CallMethodsWithOther(other, OnStayMethodAction);
        
    }

    protected void OnMethodExit(GameObject other)
    {

        if (!OnExit(other)) return;

        CallMethodsWithOther(other, OnExitMethodAction);
        
    }
}
