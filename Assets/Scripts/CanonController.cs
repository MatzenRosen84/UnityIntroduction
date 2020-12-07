using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanonController : MonoBehaviour
{
    public Rigidbody bulletInstance;
    public Transform bulletContainer;

    public Text bulletLabel;
    private int bulletCount = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Get the mouse position
        Vector2 mousePosition = Input.mousePosition;

        float horiziontalPosition = mousePosition.x / Screen.width;
        float verticalPosition = mousePosition.y / Screen.height;

        //Set the rotation of canon
        float degreeAngle = 30.0f;
        float horizontalRotation = -degreeAngle + degreeAngle * 2 * horiziontalPosition;
        float verticalRotation = -degreeAngle + degreeAngle * 2 * verticalPosition;

        //rotate the game object
        gameObject.transform.localEulerAngles = new Vector3(
            verticalRotation,
            0,
            horizontalRotation
            );


        if (Input.GetMouseButtonDown(0)) {
            //Check for Mouse clicks
            Rigidbody newBulletInstance = Instantiate(bulletInstance, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)), bulletContainer) as Rigidbody;
            //shoot power
            float shootPower = 50.0f;
            //get poingting direction of pipe
            Vector3 pipeVector = transform.position + gameObject.transform.up * shootPower;
            newBulletInstance.velocity = pipeVector;

            //on bullet got shoot out
            bulletCount++;
            bulletLabel.text = "Bullets: " + bulletCount;
        }


        //check for bullets
        foreach (Transform child in bulletContainer) {
            if (child.position.y < -5) {
                Destroy(child.gameObject);
            }
        }
    }
}
