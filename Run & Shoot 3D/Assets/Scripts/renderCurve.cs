using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderCurve : MonoBehaviour
{
   public LineRenderer lineRenderer;
   public Transform point0, point1,point2;
    public FloatingJoystick joystick;
    public float speed;
    

   private int numPoints = 50;
   private Vector3[] positions = new Vector3[50];
  

    float hAxis=0;
    float vAxis=0;
    Vector3 moveVec;

    void Start()
    {
        lineRenderer.positionCount = numPoints;

        DrawQuadraticCurve();
    }

    // Update is called once per frame
    void Update()
    {
       DrawQuadraticCurve(); 

     GetInput();
     Move();

    }

    void GetInput()
    {
       hAxis =  joystick.Horizontal;
       vAxis = joystick.Vertical;
        /*
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");*/
       if (Input.GetButton("Fire1"))
			   {
                lineRenderer.enabled=true;
                }
               else{
                lineRenderer.enabled=false;
                }
        
        
                
    }
    void Move(){
        moveVec =new Vector3(hAxis,0,vAxis).normalized;
        transform.position+=moveVec *speed * Time.deltaTime;
        //transform.LookAt(transform.position + moveVec);
         //anim.SetBool("isWalking", moveVec != Vector3.zero);
         if(moveVec==Vector3.zero){
           //  anim.SetBool("isWalking", false);
         }
    }

    private void DrawLinearCurve(){
        for(int i=1;i<numPoints+1;i++) {
            float t=i/(float)numPoints;
            positions[i-1]=calculateLinearBezierPoint(t,point0.position,point1.position);
        }
        lineRenderer.SetPositions(positions);

    }
    private void DrawQuadraticCurve(){
        for(int i=1;i<numPoints+1;i++) {
            float t=i/(float)numPoints;
            positions[i-1] = calculateQuadraticBezierPoint(t,point0.position,point1.position,point2.position);
        }
        lineRenderer.SetPositions(positions);
    }

 private Vector3 calculateLinearBezierPoint(float t,Vector3 p0, Vector3 p1 )
    {
       return p0 + t *(p1 - p0);

    }

    private Vector3 calculateQuadraticBezierPoint(float t,Vector3 p0, Vector3 p1 , Vector3 p2)
    {
        float u = 1 - t;
        float tt= t * t;
        float uu= u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt *p2;
        return p ; 

    }
}
