using UnityEngine;
using System.Collections;

public class sceneSwitch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void switchPalace()
    {
        Application.LoadLevel("HardyScene");
    }
    public void switchScanner()
    {
        Application.LoadLevel("ARScene");
    }
}
