using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Vuforia
{
    public class ScannerControl : MonoBehaviour
    {
       
        public GameObject ImageTarget;
        public GameObject passiveScanning;
      
        public GameObject scannerComplete;
        bool limiter = false;
        // Use this for initialization
        void Start()
        {


            
       
        }

        // Update is called once per frame
        void Update()
        {

            // if()
            if (ImageTarget.GetComponent<CustomEventHandler>().ScannerStatus == 1 && limiter==false)
            {
                //change image
                passiveScanning.SetActive(false);
                scannerComplete.SetActive(true);
                limiter = true;
               
            }
        }

    }

}