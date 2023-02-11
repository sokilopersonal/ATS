using AdvancedTriggerSystem.Systems;

public class OnceTrigger : Trigger
{
    private void Awake()
    {
        _type = Type.Once;
    }
}
