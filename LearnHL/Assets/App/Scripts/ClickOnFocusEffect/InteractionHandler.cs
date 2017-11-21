using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace LearnHL.App.Core
{
    public class InteractionHandler : MonoBehaviour, IInputClickHandler
    {
        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (gameObject.name == "Flying Cube")
            {
                if (gameObject.transform.position.y  < GameController.Instance.height) GameController.Instance.FlyObject(gameObject);
                else GameController.Instance.LandObject(gameObject);
            }            
        }

        
    }
}
