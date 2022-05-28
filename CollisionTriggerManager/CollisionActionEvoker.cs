using UnityEngine;

public class CollisionActionEvoker : TriggerColliderBaseActionEvoker
{
    
    void Update()
    {
        
        _timer += Time.deltaTime;
        
    }
    
    protected void OnCollisionEnter(Collision other)
    {
        
        OnActionEnter(other.gameObject);
        
    }

    protected void OnCollisionStay(Collision other)
    {
        
        OnActionStay(other.gameObject);
        
    }

    protected void OnCollisionExit(Collision other)
    {
        
        OnActionExit(other.gameObject);
        
    }

}




