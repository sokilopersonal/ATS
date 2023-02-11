using AdvancedTriggerSystem.Systems;
using UnityEngine;

public class MultiuseTrigger : Trigger
{
    private void Awake()
    {
        _type = Type.Multiuse;
    }
}
