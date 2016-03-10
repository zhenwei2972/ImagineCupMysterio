﻿using UnityEngine;
using System.Collections;

public class CameraLineTracer : MonoBehaviour
{

    private const float sightDistance = 5;
    private GameObject[] viewedObjects;
    public bool puzzleMode = false;

    public Vector3 puzzleGazePos;

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
                #region Regular artifacts
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



                // Temporarily disable all the colliders on the pieces.
                GameObject[] pieces = GameObject.FindGameObjectsWithTag("MayanCalendarPiece");
                foreach (GameObject p in pieces)
                {
                    p.GetComponent<PuzzlePiece>().isLookedAt = false;
                }
                #endregion
            }
            else if (!puzzleMode && hit.transform.gameObject.tag.Equals("MayanCalendarPiece"))
            {
                viewedObjects[0] = hit.transform.gameObject;

                if (viewedObjects[0] == viewedObjects[1])
                {

                }
                else
                {
                    viewedObjects[1] = hit.transform.gameObject;
                    //puzzleMode = true;
                    hit.transform.gameObject.GetComponent<PuzzlePiece>().PieceMoveStart();
                }
            }
            else if (puzzleMode && hit.transform.gameObject.tag.Equals("MayanCalendarSupport"))
            {
                Debug.Log("Following bah");
                puzzleGazePos = hit.point;
            }
        }
        else
        {
            // Not looked at anything
            // Deactivate previous looked at item
            if (viewedObjects[1] != null && viewedObjects[1].tag.Equals("Artifact"))
            {
                viewedObjects[1].GetComponent<ArtifactBehaviour>().Deactivate();
                viewedObjects[1] = null;

                Debug.Log("LAG");
            }
            else if (viewedObjects[1] != null && (viewedObjects[1].tag.Equals("MayanCalendarPiece") || viewedObjects[1].tag.Equals("MayanCalendarSupport")))
            {
                // Temporarily disable all the colliders on the pieces.
                GameObject[] pieces = GameObject.FindGameObjectsWithTag("MayanCalendarPiece");
                foreach (GameObject p in pieces)
                {
                    p.GetComponent<PuzzlePiece>().isLookedAt = false;
                }
                viewedObjects[1] = null;
                Debug.Log("More lag");
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.forward + transform.position);
    }
}
