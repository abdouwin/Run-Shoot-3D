using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ControllerExperiment
{
public class BallManager : MonoBehaviour
{  
    public List<GameObject> Checkpoint = new List<GameObject>();
    public List<GameObject> LineControllers = new List<GameObject>();
    QuadraticBezier  Bezier ;
    GameObject point;
    bool swap=false;
    int i=0;
   
    void Start()
    { 
        Bezier = GameObject.Find("Ball").GetComponent<QuadraticBezier>();
        
    }
        
    void Update()
    { 
        
        if (Input.GetButtonDown("Fire1")){
              swap=true;
        }
      
       else {swap=false;}
        
    }

        private void SwitchCheckPoints ()
        {
            
           //yield return new WaitForSeconds(1f);
         Bezier.Checkpoints[2] =Checkpoint[4];
          Bezier.Checkpoints[1] =Checkpoint[3]; 
         Bezier.Checkpoints[0] = Checkpoint[2]; 
         
       
        }
        

         private void OnTriggerStay(Collider other) {
 
        if(other.gameObject.tag =="simo") {
            if(swap){
                SwitchCheckPoints();
          LineControllers[0].SetActive(false);
          LineControllers[1].SetActive(true);
            }
         


          }           
    
}
}}
