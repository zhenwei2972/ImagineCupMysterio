using UnityEngine;
using System.Collections;

public class PuzzleBehaviour : MonoBehaviour {

    public GameObject replacementPuzzle;
    public bool completed = false;

    private int count = 0;

    // Use this for initialization
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        PuzzlePiece[] pps = GetComponentsInChildren<PuzzlePiece>();

        if (!completed)
        {
            count = 0;
            foreach (PuzzlePiece pp in pps)
            {
                if (pp.isFixed)
                {
                    count++;
                }
            }
            if (count == 5)
            {
                completed = true;
            }
        }
        else
        {
            replacementPuzzle.SetActive(true);
            Destroy(gameObject);
        }
    }
}
