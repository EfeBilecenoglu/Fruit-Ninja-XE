using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = 0.1f; //vol2

    private Rigidbody2D rb;
    private Vector3 lastMousePos; //vol2
    private Vector3 mouseVelo; //vol2

    private Collider2D col2d; //vol2

    // Start is called before the first frame update
    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>(); //vol2
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        col2d.enabled = IsMouseMoving();  // (vol2) only make action when mouse are moving 
        
        SetBladeToMouse();
    }

    private void SetBladeToMouse()
    {
        var mousePos= Input.mousePosition;
        mousePos.z = 10; // distance of 10 units from the camera
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
    private bool IsMouseMoving() //vol2
    {
        Vector3 curMousePos= transform.position;
        float traveled = (lastMousePos - curMousePos).magnitude; //calculete lenght of the vector
        lastMousePos = curMousePos;

        if (traveled>minVelo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
