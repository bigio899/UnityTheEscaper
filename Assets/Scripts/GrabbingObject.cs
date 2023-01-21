using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabbingObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyGrabbedTextAdvise; //variable where's contained the text "You have grabbed the key!"
    private bool isKeyGrabbedToThePlayer = false;  //boolean where is contained the information about the grab or not of the key.
    private bool isCoroutineEnded=false;
    private void Update()
    {
        if (isCoroutineEnded == true)
        {
            keyGrabbedTextAdvise.gameObject.SetActive(false); // the text that inform the player whop has grabbed the key is sected to inactive.
            Destroy(keyGrabbedTextAdvise.gameObject);
            isCoroutineEnded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if((other.gameObject.CompareTag("Key")))  //if the triggerer collides with a key
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            isKeyGrabbedToThePlayer = true;
            if(isKeyGrabbedToThePlayer==true)
            {
                keyGrabbedTextAdvise.gameObject.SetActive(true); // the text that inform the player whop has grabbed the key is sected to active.
                StartCoroutine(TimeOfViewingKeyText()); //start of 5 second of coroutine. 
            }
        }
    }

    public IEnumerator TimeOfViewingKeyText()
    {
        yield return (new WaitForSeconds(3.5f));  //3 seconds for read the text that inform the player whop has grabbed the key.
        isCoroutineEnded = true;
    }
}
