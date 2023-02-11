using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AdvancedTriggerSystem.Systems;

namespace AdvancedTriggerSystem
{
    public class AdvancedTriggerSystemBehaviour : MonoBehaviour
    {
        Camera _cam;

        public static List<Trigger> TriggerObjects = new List<Trigger>();
        static List<AdvancedTriggerSystemBehaviour> count = new List<AdvancedTriggerSystemBehaviour>(); 
        
        int _noDrawLayer;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);

            _cam = Camera.main;

            _noDrawLayer = LayerMask.NameToLayer("NoDraw");

            count.Add(this);

            //if (_noDrawLayer == -1)
            //{
            //    _noDrawLayer = 8;
            //}

            //_cam.cullingMask &= ~(1 << _noDrawLayer);
        }

        void Start()
        {
            if (count.Count > 1)
            {
                Debug.LogError("You cannot create more than one ATS Behaviour. " +
                        "The scene will stop running until you leave only one.");
            }

            foreach (Trigger triggers in TriggerObjects)
            {
                triggers.gameObject.layer = _noDrawLayer;
            }
        }
    }
}