using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainButtonBehaviour : MonoBehaviour {

    public Animator activateButton, ring;
    public bool activated = false;

    public GameObject scanner, mindPalace;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        activateButton.SetBool("Shrunken", activated);
        ring.SetBool("Expanded", activated);

        scanner.SetActive(activated);
        mindPalace.SetActive(activated);
	}

    public void ToggleActivate()
    {
        activated = !activated;
    }

    public void MindPalace()
    {
        Debug.Log("Load mind palace");
        // Load level here
    }
}
