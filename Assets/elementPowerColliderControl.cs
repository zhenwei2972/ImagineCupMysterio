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
    public bool redhit, bluehit, greenhit, yellowhit;
    public AudioSource audio;
    //public GameObject maskGame;
    // Use this for initialization
    void Start () {
	    touchControl = GameObject.FindGameObjectWithTag("TouchControl");
        random = Random.Range(0, 4);
        audio = GetComponent<AudioSource>();
        
        colorIndex = random;
        
        rend = gameObject.GetComponent<Renderer>();

        redhit = yellowhit = greenhit = bluehit = false;
    }
	
	// Update is called once per frame
	void Update () {
       
        //Instantiate(ball, touchControl.transform.position, touchControl.transform.rotation);
        if (rend != null)
        {
            
                switch (colorIndex)
                {
                    case 0:
                    if (bluehit == true)
                    {
                        colorIndex = 1;
                    }
                    currentColor = Color.blue;
                    rend.material.SetColor("_Color", currentColor);
                      //  timeLeft = colorSwitchTime;
                       // colorIndex = 1;
                        break;
                    case 1:
                    if (yellowhit == true)
                    {
                        colorIndex = 2;
                    }
                    currentColor = Color.yellow;
                    rend.material.SetColor("_Color", currentColor);
                     //   timeLeft = colorSwitchTime;
                   //     colorIndex = 2;
                        break;
                    case 2:
                    if (greenhit == true)
                    {
                        colorIndex = 3;
                    }
                    currentColor = Color.green;
                    rend.material.SetColor("_Color", currentColor);
                     //   timeLeft = colorSwitchTime;
                      //  colorIndex = 3;
                        break;
                    case 3:
                    if (redhit == true)
                    {
                        colorIndex = 0;
                    }
                    currentColor = Color.red;
                    rend.material.SetColor("_Color", currentColor);
                    //    timeLeft = colorSwitchTime;
                      //  colorIndex = 0;
                        break;
                    default:
                        Debug.Log("color Switch Error");
                        break;
                }

            if (touchControl.GetComponent<touchControl>().clear >= 4)
            {
                gameObject.GetComponent<Renderer>().enabled = false;
                PlayerPrefs.SetInt("calender", 1);
               // audio.Play();
                StartCoroutine(destroyDelay(gameObject, 2));
            }
            }
        }
    IEnumerator destroyDelay(GameObject particle, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ShieldRed")
        {
            
            if (rend.material.color ==Color.red)
            {
                audio.Play();
                redhit = true;
                touchControl.GetComponent<touchControl>().fire = false;
                touchControl.GetComponent<touchControl>().ballAlive = false;
                Debug.Log("destroy");
                Destroy(other.gameObject);
                    // Destroy(gameObject);
                transform.position = touchControl.transform.position;
                touchControl.GetComponent<touchControl>().clear++;
            }

        }
        if (other.tag == "ShieldYellow")
        {
            
            if (rend.material.color == Color.yellow)
            {
                audio.Play();
                yellowhit = true;
                touchControl.GetComponent<touchControl>().fire = false;
                touchControl.GetComponent<touchControl>().ballAlive = false;
                Debug.Log("destroy");
                Destroy(other.gameObject);
                
                transform.position = touchControl.transform.position;
                touchControl.GetComponent<touchControl>().clear++;
            }

        }
        if (other.tag == "ShieldGreen")
        {
            
            if (rend.material.color == Color.green)
            {
                audio.Play();
                greenhit = true;
                touchControl.GetComponent<touchControl>().fire = false;
                touchControl.GetComponent<touchControl>().ballAlive = false;
                Debug.Log("destroy");
                Destroy(other.gameObject);
                transform.position = touchControl.transform.position;
                touchControl.GetComponent<touchControl>().clear++;
            }

        }
        if (other.tag == "ShieldBlue")
        {
            
            if (rend.material.color == Color.blue)
            {
                audio.Play();
                bluehit = true;
                touchControl.GetComponent<touchControl>().fire = false;
                touchControl.GetComponent<touchControl>().ballAlive = false;
                Debug.Log("destroy");
                Destroy(other.gameObject);
                transform.position = touchControl.transform.position;
                touchControl.GetComponent<touchControl>().clear++;
            }

        }
        if (other.tag == "Destroy")
        {
          //  audio.Play();
            random = Random.Range(0, 4);
            colorIndex = random;
            touchControl.GetComponent<touchControl>().fire = false;
            touchControl.GetComponent<touchControl>().ballAlive = false;
            Debug.Log("destroy");
            transform.position = touchControl.transform.position;
        }

    }
}
