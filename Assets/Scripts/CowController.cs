using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour
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
        if (collision.gameObject.name == "Floor") {
            StartCoroutine(DestroyOnDelay());
        } 
    }

    IEnumerator DestroyOnDelay() {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

}
