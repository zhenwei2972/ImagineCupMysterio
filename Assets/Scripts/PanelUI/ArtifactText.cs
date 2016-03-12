using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArtifactText : MonoBehaviour
{
    public float timeBetweenCharacters;
    public bool isDisplaying;
    public Text itemNameOnScreen, itemLocationOnScreen, itemDescOnScreen;
    public string name, location, desc;

    private bool isDoneAnimating = false;
    private bool textComplete;
    private float sentinel = 0;
    private int untilIndex = 0;
    private int textDisplayStage = 0; // Stage at which text is being filled

    void Update()
    {
        Debug.Log("TEXT: " + textDisplayStage);
        if (isDisplaying)
        {
            if (!isDoneAnimating)
            {
                switch (textDisplayStage)
                {
                    case 0: // Name
                        #region Display name
                        itemNameOnScreen.text = "";
                        textComplete = (untilIndex == (name.Length - 1));
                        if (!textComplete)
                        {
                            sentinel += Time.deltaTime;
                            if (sentinel >= timeBetweenCharacters)
                            {
                                untilIndex++;
                                sentinel = 0;
                            }
                            for (int i = 0; i <= untilIndex; i++)
                            {
                                itemNameOnScreen.text += name[i].ToString();
                            }
                        }
                        else
                        {
                            itemNameOnScreen.text = name;
                            untilIndex = 0;
                            sentinel = 0;
                            textDisplayStage++;
                        }
                        #endregion
                        break;
                    case 1: // Location
                        #region Display location
                        itemLocationOnScreen.text = "";
                        textComplete = (untilIndex == (("FOUND AT: " + location).Length - 1));
                        if (!textComplete)
                        {
                            sentinel += Time.deltaTime;
                            if (sentinel >= timeBetweenCharacters)
                            {
                                untilIndex++;
                                sentinel = 0;
                            }
                            for (int i = 0; i <= untilIndex; i++)
                            {
                                itemLocationOnScreen.text += ("FOUND AT: " + location)[i].ToString();
                            }
                        }
                        else
                        {
                            itemLocationOnScreen.text = ("FOUND AT: " + location);
                            untilIndex = 0;
                            sentinel = 0;
                            textDisplayStage++;
                        }
                        #endregion
                        break;
                    case 2: // Description
                        #region Display description
                        itemDescOnScreen.text = "";
                        textComplete = (untilIndex == (desc.Length - 1));
                        if (!textComplete)
                        {
                            sentinel += Time.deltaTime;
                            if (sentinel >= timeBetweenCharacters)
                            {
                                untilIndex++;
                                sentinel = 0;
                            }
                            for (int i = 0; i <= untilIndex; i++)
                            {
                                itemDescOnScreen.text += desc[i].ToString();
                            }
                        }
                        else
                        {
                            itemDescOnScreen.text = desc;
                            untilIndex = 0;
                            sentinel = 0;
                            textDisplayStage = 0;
                            isDoneAnimating = true;
                        }
                        #endregion
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            itemNameOnScreen.text = itemLocationOnScreen.text = itemDescOnScreen.text = "";
        }
    }

    public void DisplayOn()
    {
        isDisplaying = true;
        isDoneAnimating = false;
    }

    public void Reset()
    {
        isDisplaying = false;
        textDisplayStage = 0;
        untilIndex = 0;
    }
}
