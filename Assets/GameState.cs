using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Vuforia
{
    public class GameState : MonoBehaviour
    {
        public GameObject anagramSolver;
        public GameObject mayanCalenderPuzzle;
        bool doOnce = true;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(PlayerPrefs.GetInt("calender"));
            if (PlayerPrefs.GetInt("calender") == 1)
            {
                if (doOnce)
                {
                    anagramSolver.SetActive(false);
                    mayanCalenderPuzzle.SetActive(true);
                    doOnce = false;
                }

            }

        }
    }
}
