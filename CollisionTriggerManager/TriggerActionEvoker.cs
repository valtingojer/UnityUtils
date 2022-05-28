using UnityEngine;

public class TriggerActionEvoker : TriggerColliderBaseActionEvoker
{
    
    void Update()
    {
        _timer += Time.deltaTime;
    }
    
    protected void OnTriggerEnter(Collider other)
    {
        OnActionEnter(other.gameObject);
    }

    protected void OnTriggerStay(Collider other)
    {
        OnActionStay(other.gameObject);
    }

    protected void OnTriggerExit(Collider other)
    {
        OnActionExit(other.gameObject);
    }
    
}
