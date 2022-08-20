using UnityEngine;

public class CollisionEventEvoker : TriggerColliderBaseEventEvoker
{

    void Update()
    {
        
        _timer += Time.deltaTime;
        
    }

    protected void OnCollisionEnter(Collision other)
    {
        
        OnEventEnter(other.gameObject);
        
    }

    protected void OnCollisionStay(Collision other)
    {
        
        OnEventStay(other.gameObject);
        
    }

    protected void OnCollisionExit(Collision other)
    {
        
        OnEventExit(other.gameObject);
        
    }

}
