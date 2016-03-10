using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Vuforia;
    public class LocationService : MonoBehaviour
    {
        public Text testDisplay;
       
        public void FixedUpdate()
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }
        IEnumerator Start()
        {
            // First, check if user has location service enabled
            if (!Input.location.isEnabledByUser)
                yield break;

            // Start service before querying location
            Input.location.Start();

            // Wait until service initializes
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            // Service didn't initialize in 20 seconds
            if (maxWait < 1)
            {
                print("Timed out");
                yield break;
            }

            // Connection has failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                print("Unable to determine device location");
                yield break;
            }
            else
            {
                testDisplay.text = ("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude);
                // Access granted and location value could be retrieved
                print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude);
            }

            // Stop service if there is no need to query location updates continuously
            Input.location.Stop();
        }
    }
