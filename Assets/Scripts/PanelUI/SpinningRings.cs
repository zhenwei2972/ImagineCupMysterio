using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpinningRings : MonoBehaviour {

    public Image Ring1, Ring2, Ring3;
    public float zRot = 0;
    public float rotateSpeed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        zRot += rotateSpeed * Time.deltaTime;
        Ring1.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, zRot);
        Ring2.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -zRot);
        Ring3.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, zRot);
	}
}
