using UnityEngine;
using System.Collections;

public class ArtifactBehaviour : MonoBehaviour {

    public int artifactIndex;

    public GameObject item; // The gameObject of the physical object
    public GameObject infoCanvas; // The gameObject of the information canvas

    public bool isLookedAt = false;

	// Use this for initialization
	void Start () {
        GameObject loader = GameObject.FindGameObjectWithTag("Loader");
        infoCanvas.GetComponent<ArtifactText>().name = loader.GetComponent<ArtifactLoader>().ac.artifacts[artifactIndex].name;
        infoCanvas.GetComponent<ArtifactText>().location = loader.GetComponent<ArtifactLoader>().ac.artifacts[artifactIndex].location;
        infoCanvas.GetComponent<ArtifactText>().desc = loader.GetComponent<ArtifactLoader>().ac.artifacts[artifactIndex].description;
	}
	
	// Update is called once per frame
	void Update () {
        if (infoCanvas.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("NotDisplaying") && !isLookedAt)
        {
            infoCanvas.SetActive(false);
        }
        if (infoCanvas.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Displaying") && isLookedAt)
        {
            if (!infoCanvas.GetComponent<ArtifactText>().isDisplaying)
            {
                infoCanvas.GetComponent<ArtifactText>().DisplayOn();
            }
        }
	}

    public void Activate()
    {
        infoCanvas.SetActive(true);
        isLookedAt = true;
        infoCanvas.GetComponent<Animator>().SetBool("IsDisplaying", true);
    }

    public void Deactivate()
    {
        isLookedAt = false;
        infoCanvas.GetComponent<Animator>().SetBool("IsDisplaying", false);
        infoCanvas.GetComponent<ArtifactText>().Reset();
    }
}
