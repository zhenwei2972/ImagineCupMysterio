using UnityEngine;
using System.Collections;

public class CameraLineTracer : MonoBehaviour
{

    private const float sightDistance = 5;
    private GameObject[] viewedObjects;

    void Awake()
    {
        // Maximum of two objects within this array ([0] new target and [1] old target)
        viewedObjects = new GameObject[2];
    }

    // Use this for initialization
    void Start()
    {
        if (viewedObjects[0] == null)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position,
            gameObject.transform.forward,
            out hit, sightDistance))
        {
            // ヒットのオブジェクトのタッグは「Artifact」なら、。。。
            if (hit.transform.gameObject.tag.Equals("Artifact"))
            {
                // Set the viewed item to "new viewed object"
                viewedObjects[0] = hit.transform.gameObject;
                
                //　新しいオブジェクトは前のオブジェクトと同じなら、。。。
                if (viewedObjects[0] == viewedObjects[1])
                {

                }
                else
                {
                    // Set the current viewed object to "old viewed object" for next frame
                    viewedObjects[1] = viewedObjects[0];
                    // Activate the artifact's display
                    hit.transform.gameObject.GetComponent<ArtifactBehaviour>().Activate();
                }
            }
        }
        else
        {
            // Not looked at anything
            // Deactivate previous looked at item
            if (viewedObjects[1])
            {
                viewedObjects[1].GetComponent<ArtifactBehaviour>().Deactivate();
                viewedObjects[1] = null;
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.forward + transform.position);
    }
}
