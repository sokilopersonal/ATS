
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public enum Type
{
    Once,
    Multiuse
}

namespace AdvancedTriggerSystem.Systems
{
    public class Trigger : MonoBehaviour
    {
        void Start()
        {
            if (!FindObjectOfType<AdvancedTriggerSystemBehaviour>())
            {
                if (EditorApplication.isPlaying)
                {
                    EditorApplication.ExitPlaymode();
                }
                
                throw new NullReferenceException("No ATS Behaviour on the scene. " +
                                                 "Please create one via the context menu " +
                                                 "\"Triggers/ATS Behaviour\".");
            }
            
            AdvancedTriggerSystemBehaviour.TriggerObjects.Add(gameObject.GetComponent<Trigger>());
        }

        #region Variables & Headers & Events

        public Type _type;
        
        [Header("For triggers to work, you must have a \"Player\"")]
        [Header("or \"Object\" tag on your physical object")]
        [Space]
        [Tooltip("Calls an event (method) when a physical object enters the trigger.")] 
        public UnityEvent onTouch;
        
        [Space]
        [Header("(You can leave this field blank if you use a one-time trigger)")]
        [Space]
        public UnityEvent onExit;

        #endregion

        #region Triggers Work

        public virtual void OnTriggerEnter(Collider other)
        {
            EnterLogic(other, _type);
        }

        public virtual void OnTriggerExit(Collider other)
        {
            ExitLogic(other, _type);
        }

        protected void EnterLogic(Collider other, Type type)
        {
            if (other.transform.CompareTag("Player") || other.transform.CompareTag("Object"))
            {
                switch (type)
                {
                    case Type.Once:
                        // Call the event and destroy the object to prevent it from being called again
                        onTouch?.Invoke();
                        Destroy(gameObject);
                        break;
                    case Type.Multiuse:
                        // Call the event and turn off the object,
                        // so that when object logs in again the event will be called
                        onTouch?.Invoke();
                        break;
                }
            }
        }

        protected void ExitLogic(Collider other, Type type)
        {
            // Make sure that the trigger type is not a multi-trigger type.
            // exiting the trigger it will turn back on
            if (type != Type.Multiuse) return;

            onExit?.Invoke();
        }

        #endregion
    }
}