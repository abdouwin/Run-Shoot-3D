using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dupl : MonoBehaviour
{
	
    // Settings
    public float MaxArmy;
	public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 10;
	
	//public Vector3 ExtraGap;
	
    // References
    public GameObject BodyPrefab;

    // Lists
    public List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start() {
        // GrowSnake();
	
    }

    // Update is called once per frame
    void Update() {

        // Move forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // Steer
        // float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
        // transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
		
        foreach (var body in BodyParts) {
			
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
			
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
    }

    private void GrowSnake(GameObject col)  {
        // Instantiate body instance and
        // add it to the list
        GameObject body = col; //Instantiate(BodyPrefab);
		
		
		// if(gameObject.tag == "enemy"){
			// body.transform.GetChild(0).gameObject.tag = "enemy_part";
		// }
		
	     if(gameObject.tag == "player"){
		    body.transform.GetChild(0).gameObject.tag = "player_part";
		 }
		
		body.name = BodyParts.Count.ToString();

        BodyParts.Add(body);
    }
	
	 void OnTriggerEnter(Collider col)
    {
   
	if (BodyParts.Count < MaxArmy )
	if(col.gameObject.tag == "nuteral") 
		{
         GrowSnake(col.transform.parent.gameObject); 
		 col.gameObject.tag = "Untagged" ;
		 col.GetComponent<SphereCollider>().isTrigger = false ;
		 
		
        }
	
  }
}