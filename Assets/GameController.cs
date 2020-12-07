using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public ChickenController[] chickens;
    private int birdsCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        birdsCount = 0;
        foreach (ChickenController chicken in chickens) {
            if (chicken) {
                birdsCount++;
            }
        }

        if (birdsCount == 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
