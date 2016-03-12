using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnagramHandle : MonoBehaviour {

    public int alphabetIndex;
    public bool Up;
    public float startSelectorTime;
    public Image FillSelector;
    public bool isLookedAt = false;

    private Anagram mainAnagramObj; // Always report to this guy
    private float selectorTime;
    private int stareCount = 0;

	// Use this for initialization
	void Start () {
        mainAnagramObj = GameObject.FindGameObjectWithTag("AnagramSolver").GetComponent<Anagram>();
        selectorTime = startSelectorTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (isLookedAt)
        {
            selectorTime -= Time.deltaTime;
            if (selectorTime <= 0)
            {
                stareCount++;
                mainAnagramObj.ApplyChange(Up, alphabetIndex);
                selectorTime = startSelectorTime;
            }
        }
        else
        {
            selectorTime = startSelectorTime;
        }

        if (stareCount > 3)
        {
            startSelectorTime = 0.5f;
        }

        FillSelector.enabled = isLookedAt;
        FillSelector.fillAmount = selectorTime / startSelectorTime;
	}

    public void Select()
    {
        isLookedAt = true;
    }

    public void Deselect()
    {
        isLookedAt = false;
        startSelectorTime = 1;
    }
}
