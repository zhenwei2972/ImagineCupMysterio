using UnityEngine;
using System.Collections;

public class MaskGame : MonoBehaviour {
    public GameObject shield1;
    public GameObject shield2;
    public GameObject shield3;
    public GameObject shield4;
    public GameObject elementPower;
    private Renderer rend;
    private float timeLeft = 2;
    public float colorSwitchTime =3;
    public int colorIndex = 0;
    public Color currentColor;
    // Use this for initialization
    void Start () {
	rend = elementPower.GetComponent<Renderer>();
	}

    // Update is called once per frame
    void Update()
    {

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
}
