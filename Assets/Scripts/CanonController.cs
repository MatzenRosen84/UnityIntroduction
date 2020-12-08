using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CanonController : MonoBehaviour
{
    public float degreeAngle = 30.0f;
    public Rigidbody bulletInstance;
    public Transform bulletContainer;
    public Text bulletText;

    private int _bulletCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse position
        Vector2 mousePosition = Input.mousePosition;

        // Relative mouse position
        float horizontalPosition = mousePosition.x / Screen.width;
        float verticlPosition = mousePosition.y / Screen.height;

        // Roate tube based on mouse positions
        float horizontalRostation = -degreeAngle + degreeAngle * 2 * horizontalPosition;
        float verticalRostation = -degreeAngle + degreeAngle * 2 * verticlPosition;

        gameObject.transform.localEulerAngles = new Vector3(verticalRostation, 0, horizontalRostation);


        //check mouse press
        if (Input.GetMouseButtonDown(0)) {
            // Emit a bullet
            Rigidbody newBulletInstance = Instantiate(bulletInstance, gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)), bulletContainer);
            // shoot power
            float shootPower = 50.0f;
            // driecton of the pipe
            Vector3 pipeVector = transform.position + gameObject.transform.up * shootPower;
            newBulletInstance.velocity = pipeVector;

            // count up bullets
            _bulletCount++;
            bulletText.text = "Bullets: " + _bulletCount;
        }


        // check bullet positions
        foreach (Transform child in bulletContainer) {
            if (child.position.y < -5) {
                Destroy(child.gameObject);
            }
        }
    }
}
