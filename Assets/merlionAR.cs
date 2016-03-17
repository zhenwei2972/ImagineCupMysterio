using UnityEngine;
using System.Collections;
namespace Vuforia
{
    public class merlionAR : MonoBehaviour
    {
        public GameObject particleKing;
        public GameObject particleQueen;
        public GameObject particleDwarf;
        public GameObject Statue;
        public GameObject mayaSculpture;
        public GameObject kingStatue;
        public GameObject queenStatue;
        public GameObject dwarfStatue;
        
        float timeLeft = 4;
        int activateShield = 0;
        bool king = false;
        bool queen = false;
        bool dwarf = false;
        bool runOnce = true;
        private string sequence;
        bool win = false;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Statue.GetComponent<CustomEventHandler>().isRendered)
            {


                timeLeft -= Time.deltaTime;
                if (timeLeft > 0 && runOnce)
                {
                    StartCoroutine(switchActive(particleKing, true, 1));
                    StartCoroutine(switchActive(particleQueen, true, 2));
                    StartCoroutine(switchActive(particleDwarf, true, 3));

                }
                else if (timeLeft < 0 && runOnce)
                {
                    StartCoroutine(switchActive(particleKing, false, 1));
                    StartCoroutine(switchActive(particleQueen, false, 2));
                    StartCoroutine(switchActive(particleDwarf, false, 3));
                    runOnce = false;
                }

                if (Input.GetMouseButtonDown(0))
                { // if left button pressed...
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.tag == "Totem")
                        {

                            if (hit.collider.gameObject.name == "king")
                            {
                                sequence += 1.ToString();
                                king = true;

                                StartCoroutine(switchActive(particleKing, true, 0));

                            }
                            else if (hit.collider.gameObject.name == "queen")
                            {
                                sequence += 2.ToString();
                                StartCoroutine(switchActive(particleQueen, true, 0));
                                queen = true;

                            }
                            else if (hit.collider.gameObject.name == "dwarf")
                            {
                                sequence += 3.ToString();
                                StartCoroutine(switchActive(particleDwarf, true, 0));
                                dwarf = true;



                            }
                        }
                    }
                }
                if (win)
                {
                    StartCoroutine(destroyObject(5));
                    win = false;
                }
                if (king && queen && dwarf)
                {
                    if (sequence == "123")
                {
                        king = false;
              //      Debug.Log("win");
                        win = true;
                        mayaSculpture.SetActive(win);
                 }
                else
                {
                    StartCoroutine(switchActive(particleKing, false, 0));
                    StartCoroutine(switchActive(particleQueen, false, 0));
                    StartCoroutine(switchActive(particleDwarf, false, 0));
                    sequence = "";
                    Debug.Log("fail");
                        king = queen = dwarf = false;
                }
    
               }
                

            }
        }
        IEnumerator switchActive(GameObject particle, bool state, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            particle.SetActive(state);
        }
        IEnumerator destroyObject( float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            activateShield = 1;
            PlayerPrefs.SetInt("calender", activateShield);
            mayaSculpture.SetActive(false);
            kingStatue.SetActive(false);
            queenStatue.SetActive(false);
            dwarfStatue.SetActive(false);
          //  Debug.Log(PlayerPrefs.GetInt("calenderStatus"));
        }
    }
}