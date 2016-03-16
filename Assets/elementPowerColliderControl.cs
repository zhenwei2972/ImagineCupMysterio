using UnityEngine;
using System.Collections;

public class elementPowerColliderControl : MonoBehaviour {
    private GameObject touchControl;
    public GameObject ball;
    private Color ballColor;
    private Renderer rend;
    private float timeLeft = 2;
    public float colorSwitchTime = 2;
    public int colorIndex = 0;
    public Color currentColor;
    private int random;
    //public GameObject maskGame;
    // Use this for initialization
    void Start () {
	    touchControl = GameObject.FindGameObjectWithTag("TouchControl");
        random = Random.Range(0, 3);
        if (random == 0)
        {
            colorIndex = random;
        }
        rend = gameObject.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        //Instantiate(ball, touchControl.transform.position, touchControl.transform.rotation);
        if (rend != null)
        {
            //Color Switch Code
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                switch (colorIndex)
                {
                    case 0:
                        currentColor = Color.blue;
                        rend.material.SetColor("_Color", currentColor);
                        timeLeft = colorSwitchTime;
                        colorIndex = 1;
                        break;
                    case 1:
                        currentColor = Color.yellow;
                        rend.material.SetColor("_Color", currentColor);
                        timeLeft = colorSwitchTime;
                        colorIndex = 2;
                        break;
                    case 2:
                        currentColor = Color.green;
                        rend.material.SetColor("_Color", currentColor);
                        timeLeft = colorSwitchTime;
                        colorIndex = 3;
                        break;
                    case 3:
                        currentColor = Color.red;
                        rend.material.SetColor("_Color", currentColor);
                        timeLeft = colorSwitchTime;
                        colorIndex = 0;
                        break;
                    default:
                        Debug.Log("color Switch Error");
                        break;
                }


            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ShieldRed")
        {
            if (rend.material.color ==Color.red)
            {
            touchControl.GetComponent<touchControl>().ballAlive = false;
            Debug.Log("destroy");
            Destroy(other.gameObject);
            Destroy(gameObject);
            touchControl.GetComponent<touchControl>().clear++;
            }

        }
        if (other.tag == "ShieldYellow")
        {
            if (rend.material.color == Color.yellow)
            {
                touchControl.GetComponent<touchControl>().ballAlive = false;
                Debug.Log("destroy");
                Destroy(other.gameObject);
                Destroy(gameObject);
                touchControl.GetComponent<touchControl>().clear++;
            }

        }
        if (other.tag == "ShieldGreen")
        {
            if (rend.material.color == Color.green)
            {
                touchControl.GetComponent<touchControl>().ballAlive = false;
                Debug.Log("destroy");
                Destroy(other.gameObject);
                Destroy(gameObject);
                touchControl.GetComponent<touchControl>().clear++;
            }

        }
        if (other.tag == "ShieldBlue")
        {
            if (rend.material.color == Color.blue)
            {
                touchControl.GetComponent<touchControl>().ballAlive = false;
                Debug.Log("destroy");
                Destroy(other.gameObject);
                Destroy(gameObject);
                touchControl.GetComponent<touchControl>().clear++;
            }

        }
        if (other.tag == "Destroy")
        {
            
                touchControl.GetComponent<touchControl>().ballAlive = false;
                Debug.Log("destroy");
                Destroy(gameObject);
              
            

        }

    }
}
