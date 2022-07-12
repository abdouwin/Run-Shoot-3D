using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PathCreation.Examples
{
public class Follow : MonoBehaviour
{
   public PathCreator pathCreator;
     
        public float speed = 5;
        float distanceTravelled;
   
    void Update()
    {
        distanceTravelled+=speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        
    }
}
}