using System.Collections;
using UnityEngine;

public class BerryReceiver : MonoBehaviour
{
    [SerializeField] GameObject startDialogue;
    [SerializeField] GameObject yesDialogue;
    [SerializeField] GameObject noDialogue;

    void Start()
    {
       
        if (startDialogue != null)
        {
            
            //startDialogue.SetActive(true);
            StartCoroutine(ShowStartDialogue());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Nomad>())
        {
            if (other.gameObject.GetComponent<Nomad>().currentHoldable != null)
            {   
                if (other.gameObject.GetComponent<Nomad>().currentHoldable.isWinningBerry)
                {
                    print("Winner");
                    if (yesDialogue != null)
                    {
                        StartCoroutine(ShowYesDialogue());
                    }
                    FindObjectOfType<Door>().Open();
                }
                else
                {
                    if (noDialogue != null)
                    {
                        StartCoroutine(ShowNoDialogue());
                    }
                    print("Wrong Berry!");
                }
                other.gameObject.GetComponent<Nomad>().GiveHoldable();
            }
        }
    }

    private IEnumerator ShowStartDialogue()
    {
        //startDialogue.SetActive(true);
        yield return new WaitForSeconds(6);
        startDialogue.SetActive(false);
        print("start");
    }

    private IEnumerator ShowYesDialogue()
    {
        yesDialogue.SetActive(true);
        yield return new WaitForSeconds(4);
        yesDialogue.SetActive(false);
    }

    private IEnumerator ShowNoDialogue()
    {
        noDialogue.SetActive(true);
        yield return new WaitForSeconds(4);
        noDialogue.SetActive(false);
    }
}
