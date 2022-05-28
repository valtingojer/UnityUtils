using UnityEngine;

public class CollisionMethodEvoker : TriggerColliderBaseMethodEvoker
{
    
    void Update()
    {
        
        _timer += Time.deltaTime;
        
    }

    protected void OnCollisionEnter(Collision other)
    {
        
        OnMethodEnter(other.gameObject);
        
    }

    protected void OnCollisionStay(Collision other)
    {
        
        OnMethodStay(other.gameObject);
        
    }

    protected void OnCollisionExit(Collision other)
    {
        
        OnMethodExit(other.gameObject);
        
    }

}




