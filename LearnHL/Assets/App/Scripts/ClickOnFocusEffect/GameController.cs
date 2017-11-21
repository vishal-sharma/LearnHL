using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

namespace LearnHL.App.Core
{
    public class GameController : Singleton<GameController>
    {
        public float speed = 10.0f;
        public float height = 1.0f;
        
        public void FlyCube()
        {
            var go = GameObject.Find("Flying Cube");
            FlyObject(go);
        }

        public void LandCube()
        {
            var go = GameObject.Find("Flying Cube");
            LandObject(go);
        }

        public void FlyObject(GameObject go)
        {
            var startPosition = go.transform.position;
            var endPosition = new Vector3(go.transform.position.x, go.transform.position.y + height, go.transform.position.z);
            StartCoroutine(Move(go, startPosition,endPosition));
        }

        public void LandObject(GameObject go)
        {
            var startPosition = go.transform.position;
            var endPosition = new Vector3(go.transform.position.x,0.0f, go.transform.position.z);
            StartCoroutine(Move(go, startPosition, endPosition));
        }

        IEnumerator Move(GameObject go, Vector3 start, Vector3 end)
        {
            float startTime = Time.time;
            float journeyLength = Vector3.Distance(start, end);
            float distCovered = (Time.time - startTime) * speed;
            
            while (distCovered < journeyLength)
            {
                distCovered = (Time.time - startTime) * speed;
                float fracJourney = distCovered / journeyLength;
                go.transform.position = Vector3.Lerp(start, end, fracJourney);
                yield return new WaitForEndOfFrame();
            }            
        }
    }
}
