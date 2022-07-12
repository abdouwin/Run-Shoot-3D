using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ControllerExperiment
{
    public class QuadraticBezier : MonoBehaviour
    {
           [Range(0f, 1f)]
        [SerializeField] protected float time;
         public bool AutoTime;
        [Range(0.1f, 10f)]
        [SerializeField] protected float timeScale;
        public List<GameObject> Checkpoints = new List<GameObject>();
		protected Vector3 myPosition;

		private bool clickButton ;
		//private bool moveBall;

	
                private void Shot()
        {
           
                if (clickButton )
                { 
                   // AutoTime = true;
                    time += Time.deltaTime * timeScale;

                    if (timeScale <= 0f)
                    {
                        timeScale = 0.1f;
                    }

                    if (time >= 1f)
                    {
                       // time = 0f;
					   time=0f;
						clickButton=false;
						
						
                    }
                }

              
        }

		public void GetBezier(out Vector3 pos, List<GameObject> Checkpoints, float time)
		{
			if (Checkpoints.Count > 3)
			{
				for (int i = 3; i < Checkpoints.Count; i++)
				{
					Checkpoints.RemoveAt(i);
				}
			}

			QuadraticBezierEquation.GetCurve(out pos,
				Checkpoints[0].transform.position,
				Checkpoints[1].transform.position,
				Checkpoints[2].transform.position,
				time);
		}

		private void Update()
		{  
			GetButton();
			 Shot();
			if(clickButton){
                    GetBezier(out myPosition, Checkpoints, time);
			        this.transform.position = myPosition;
					
			}
                  
	
			
		}

		private void GetButton()
		{
			 if (Input.GetButtonUp("Fire1"))
			   clickButton = true;
			
		}




	}
}