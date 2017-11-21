using HoloToolkit.Unity.InputModule;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LearnHL.App.Core
{
    [RequireComponent(typeof(InteractionHandler))]
    public class ClickOnContinousFocus : MonoBehaviour, IFocusable
    {
        public float ClickAfterSeconds;

        private float FocusEnterTime;
        private IEnumerator coroutine;
        private InteractionHandler clickHandler;

        public void OnFocusEnter()
        {
            coroutine = TriggerClickOnContinousFocus();
            StartCoroutine(coroutine);
        }

        public void OnFocusExit()
        {
            StopCoroutine(coroutine);
        }

        // Use this for initialization
        void Start()
        {
            clickHandler = gameObject.GetComponent<InteractionHandler>();            
        }

        IEnumerator TriggerClickOnContinousFocus()
        {
            FocusEnterTime = Time.time;
            bool triggered = false;
            while (!triggered)
            {
                if (HasContinousFocus())
                {
                    triggered = true;
                    clickHandler.OnInputClicked(new InputClickedEventData(EventSystem.current));                    
                }
                yield return new WaitForEndOfFrame();
            }
        }

        private bool HasContinousFocus()
        {
            return Time.time - FocusEnterTime > ClickAfterSeconds;
        }
    }
}
