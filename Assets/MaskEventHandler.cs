using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Vuforia
{
    public class MaskEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES
    private int merlionStatus;
    private int mrtStatus;
    float timeLeft = 100;
    //private int[3] objectStatues =0;
    int[] objectStatus = new int[3];
    private TrackableBehaviour mTrackableBehaviour;
    public int clear = 0;
    public GameObject artifact;
    public Text StatusText;
        private GameObject touchControl;
    private bool isRendered = false;
    #endregion // PRIVATE_MEMBER_VARIABLES
    public int ScannerStatus = 0;


    #region UNTIY_MONOBEHAVIOUR_METHODS

    void Start()
    {

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
            touchControl = GameObject.FindGameObjectWithTag("TouchControl");
     }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS

    void Update()
    {
            //Debug.Log(touchControl.GetComponent<touchControl>().clear);
        if (isRendered)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft > 0)
            {
                if (artifact != null)
                {
                    artifact.transform.RotateAround(artifact.transform.position, artifact.transform.up, 75 * Time.deltaTime);
                }
            }

            else if (timeLeft < 0 || touchControl.GetComponent<touchControl>().clear == 4)
            {
                timeLeft = -1;
                ScannerStatus = 1;
                StatusText.text = "Scan Complete Object Received";
                Debug.Log("Object Collected!");
            }

            PlayerPrefs.SetInt("merlionStatus", objectStatus[0]);
            PlayerPrefs.SetInt("mrtStatus", objectStatus[1]);
            PlayerPrefs.SetInt("babyStatus", objectStatus[2]);
            // Debug.Log(PlayerPrefs.GetInt("mrtStatus"));
        }


    }

    #region PUBLIC_METHODS

    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS



    #region PRIVATE_METHODS


    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }
        if (mTrackableBehaviour.TrackableName == "Merlion")
        {
            //merlion located
            objectStatus[0] = 1;
        }
        else if (mTrackableBehaviour.TrackableName == "mrtMap")
        {
            //mrtMap located
            objectStatus[1] = 1;
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        isRendered = true;
    }


    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        isRendered = false;
    }

    #endregion // PRIVATE_METHODS
}
}
