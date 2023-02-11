
using UnityEngine;
using UnityEditor;

public class EditorTriggerSpawner : Editor
{
    [MenuItem("GameObject/Triggers/Once Trigger", false, 3)]
    static void SpawnOnceTrigger()
    {
        GameObject once = Resources.Load<GameObject>("Once");

        Instantiate(once);
    }
    
    [MenuItem("GameObject/Triggers/Multi-use Trigger", false, 3)]
    static void SpawnMultiuseTrigger()
    {
        GameObject multiuse = Resources.Load<GameObject>("Multi-use");

        Instantiate(multiuse);
    }

    [MenuItem("GameObject/Triggers/ATS Behaviour (Important)", false, 3)]
    static void SpawnATS()
    {
        GameObject ats = Resources.Load<GameObject>("ATS Behaviour");

        GameObject atsObj = Instantiate(ats);
        atsObj.name = "ATS Behaviour";
    }
}
