using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //time delay
        if (collision.gameObject.name == "Floor") {
            StartCoroutine(RemoveAfterdelay());
        }
    }

    IEnumerator RemoveAfterdelay() {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
