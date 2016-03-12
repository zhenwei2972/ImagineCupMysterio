using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PuzzlePiece : MonoBehaviour {

    public bool isFixed = false;

    public Image[] selectors; // 0 - border, 1 - inner fill

    public Vector3 originalPosition;

    public Vector3 correctPos;

    public bool isLookedAt = false;

    public bool isMoving = false;
    public float stareSelectTime = 5;

    private float originalStareTime;
	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
        originalStareTime = stareSelectTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (isLookedAt)
        {
            if (!isMoving)
            {
                stareSelectTime -= Time.deltaTime;
                selectors[1].fillAmount = stareSelectTime / originalStareTime;
                if (stareSelectTime < 0)
                {
                    isMoving = true;
                    
                    // Temporarily disable all the colliders on the pieces.
                    GameObject[] pieces = GameObject.FindGameObjectsWithTag("MayanCalendarPiece");
                    foreach (GameObject p in pieces)
                    {
                        p.GetComponent<PuzzlePiece>().isLookedAt = false;
                        p.GetComponent<BoxCollider>().enabled = false;
                    }
                    isLookedAt = true;
                    GameObject.FindGameObjectWithTag("VRHead").GetComponent<CameraLineTracer>().puzzleMode = true;
                    GameObject.FindGameObjectWithTag("MayanCalendarSupport").GetComponent<BoxCollider>().enabled = true;
                }
            }
            else
            {
                Debug.Log("Follow");
                // Follow gaze
                transform.position = GameObject.FindGameObjectWithTag("VRHead").GetComponent<CameraLineTracer>().puzzleGazePos;

                if (Mathf.Abs(transform.position.x - correctPos.x) < 0.02 && Mathf.Abs(transform.position.y - correctPos.y) < 0.02)
                {
                    Debug.Log("Correct");
                    transform.position = correctPos;
                    isMoving = false;
                    GameObject.FindGameObjectWithTag("VRHead").GetComponent<CameraLineTracer>().puzzleMode = false;
                    GameObject.FindGameObjectWithTag("MayanCalendarSupport").GetComponent<BoxCollider>().enabled = false;
                    // Temporarily disable all the colliders on the pieces.
                    GameObject[] pieces = GameObject.FindGameObjectsWithTag("MayanCalendarPiece");
                    foreach (GameObject p in pieces)
                    {
                        p.GetComponent<PuzzlePiece>().isLookedAt = false;
                        p.GetComponent<BoxCollider>().enabled = true;
                    }
                    GetComponent<BoxCollider>().enabled = false;
                    enabled = false;
                    isFixed = true;
                }
            }
        }
        else
        {

        }

        foreach (Image s in selectors)
        {
            s.enabled = isLookedAt;
        }
	}

    public void PieceMoveStart()
    {
        // Temporarily disable all the colliders on the pieces.
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("MayanCalendarPiece");
        foreach (GameObject p in pieces)
        {
            p.GetComponent<PuzzlePiece>().isLookedAt = false;
            //p.GetComponent<BoxCollider>().enabled = false;
        }
        stareSelectTime = originalStareTime;
        isLookedAt = true;
    }

    public void ResetPiece()
    {
        gameObject.transform.position = originalPosition;

        GameObject[] pieces = GameObject.FindGameObjectsWithTag("MayanCalendarPiece");
        foreach (GameObject p in pieces)
        {
            p.GetComponent<PuzzlePiece>().isLookedAt = false;
            p.GetComponent<BoxCollider>().enabled = true;
        }

        isMoving = false;

        //GameObject.FindGameObjectWithTag("MayanCalendarSupport").GetComponent<BoxCollider>().enabled = false;
    }
}
