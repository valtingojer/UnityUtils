using UnityEngine;

public class TriggerEventEvoker : TriggerColliderBaseEventEvoker
{

    void Update()
    {
        _timer += Time.deltaTime;
    }

    protected void OnTriggerEnter(Collider other)
    {
        OnEventEnter(other.gameObject);
    }

    protected void OnTriggerStay(Collider other)
    {
        OnEventStay(other.gameObject);
    }

    protected void OnTriggerExit(Collider other)
    {
        OnEventExit(other.gameObject);
    }

}
