using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitTriggerBehaviour : MonoBehaviour {

    public Image fillRing;
    public float stareTime;
    public bool IsLookedAt = false;

    private float originalStareTime;

    void Start()
    {
        originalStareTime = stareTime;
    }

	// Update is called once per frame
	void Update () {
        if (IsLookedAt)
        {
            stareTime -= Time.deltaTime;
            if (stareTime <= 0)
            {
                Application.LoadLevel("ARScene");
                // Load Scanner
            }
        }

        fillRing.fillAmount = stareTime / originalStareTime;
	}

    public void ActivateExit()
    {
        IsLookedAt = true;
    }

    public void DeactivateExit()
    {
        IsLookedAt = false;
        stareTime = originalStareTime;
    }
}
