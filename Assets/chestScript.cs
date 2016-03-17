using UnityEngine;
using System.Collections;

public class chestScript : MonoBehaviour
{
    public GameObject target;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            playAnim();
        }

    }
    void playAnim()
    {
        target.GetComponent<Animation>().Play("ChestAnim");
    }
}
