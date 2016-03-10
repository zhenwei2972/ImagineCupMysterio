using UnityEngine;
using System.Collections;

public class ArtifactLoader : MonoBehaviour {

    const string path = "artifacts";
    public ArtifactContainer ac;

    void Awake()
    {
        ac = ArtifactContainer.Load(path);

        foreach (Artifact artifact in ac.artifacts)
        {
            Debug.Log(artifact.name);
        }
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
