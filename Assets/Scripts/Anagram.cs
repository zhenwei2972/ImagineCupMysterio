using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Anagram : MonoBehaviour
{
    public Text[] alphabetDisplay;

    public GameObject[] anagramRotators;

    private int indexHasChanged = -1; // When none has changed

    private char[] alphabets = { 'A', 'B', 'C', 'D', 
                                   'E', 'F', 'G', 'H', 
                                   'I', 'J', 'K', 'L', 
                                   'M', 'N', 'O', 'P', 
                                   'Q', 'R', 'S', 'T', 
                                   'U', 'V', 'W', 'X', 'Y', 'Z' };

    private int[] orderInIndex = { 0, 0, 0, 0, 0 }; // Starts as A-A-A-A-A

    private float[] rotationAngles = {282,291,306,318,
                                         332,345,0,15,
                                     29,41,57,70,
                                     85,98,111,124,
                                     138,154,167,180,
                                     193,208,223,235,249,266};

    // Handle all changes in the letter sequence. Called from the individual AnagramHandle objects
    public void ApplyChange(bool Up, int alphabetIndex)
    {
        if (Up)
        {
            if (orderInIndex[alphabetIndex] == 0)
            {
                orderInIndex[alphabetIndex] = 25;
            }
            else
            {
                orderInIndex[alphabetIndex]--;
            }
        }
        else
        {
            if (orderInIndex[alphabetIndex] == 25)
            {
                orderInIndex[alphabetIndex] = 0;
            }
            else
            {
                orderInIndex[alphabetIndex]++;
            }
        }
        indexHasChanged = alphabetIndex;

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(orderInIndex[0] + "-" + orderInIndex[1] + "-" + orderInIndex[2] + "-" + orderInIndex[3] + "-" + orderInIndex[4]);
        if (indexHasChanged != -1) // One of the rotators has changed
        {
            anagramRotators[indexHasChanged].transform.localEulerAngles = new Vector3(
                anagramRotators[indexHasChanged].transform.localEulerAngles.x,
                anagramRotators[indexHasChanged].transform.localEulerAngles.y,
                rotationAngles[orderInIndex[indexHasChanged]]);
            
            alphabetDisplay[indexHasChanged].text = alphabets[orderInIndex[indexHasChanged]].ToString();

            indexHasChanged = -1;
        }
    }
}
