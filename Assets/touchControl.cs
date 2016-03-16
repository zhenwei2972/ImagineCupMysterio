using UnityEngine;
using System.Collections;

public class touchControl : MonoBehaviour {
    GameObject obj;
    bool fire = false;
    public float thrust = 20;
    public GameObject ball;
    public bool ballAlive = true;
    public int clear = 0;
    public GameObject maskParticle;
    public GameObject mayanMask;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        //   Input.GetTouch(0);
        //use raycasts to check for touch.
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Launcher")
                {
                    obj = GameObject.FindGameObjectWithTag("Launcher");
                    fire = true;
                }
            }
        }

        if (fire == true)
        {
            obj = GameObject.FindGameObjectWithTag("Launcher");
            //if not null, add force in the Z axis to launch the ball to destroy the spheres

            if (obj != null)
            {
                Vector3 movementVector = new Vector3(0, 0, 400);
                //    obj.transform.position = Vector3.Lerp(obj.transform.position, obj.transform.position + movementVector, Time.deltaTime);
                obj.GetComponent<Rigidbody>().AddForce(movementVector * thrust);
            }
        }
        if (ballAlive == false)
        {
            if (clear < 4)
            {
                fire = false;
                Instantiate(ball, transform.position, transform.rotation);
                ballAlive = true;
            }

        }
        if (clear >= 4)
        {
            maskParticle.SetActive(true);
            //Debug.Log("Object Collected!");
            //Tap to dismiss
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(maskParticle);
                Destroy(mayanMask);
            }


            //if (clear == 4)
            //{
            //    //Unlock artifact
            //    Debug.Log("Clear!");
            //}



        }
    }
   public void Reload()
    {
        fire = false;
        Instantiate(ball, transform.position, transform.rotation);
    }
    
}
