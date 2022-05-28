using UnityEngine;

public class TriggerMethodEvoker : TriggerColliderBaseMethodEvoker
{

    void Update()
    {
        _timer += Time.deltaTime;
    }

    protected void OnTriggerEnter(Collider other)
    {
        OnMethodEnter(other.gameObject);
    }

    protected void OnTriggerStay(Collider other)
    {
        OnMethodStay(other.gameObject);
    }

    protected void OnTriggerExit(Collider other)
    {
        OnMethodExit(other.gameObject);
    }
    
}
