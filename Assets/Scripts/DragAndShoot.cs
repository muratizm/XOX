using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    private Vector3 pressDownPos;
    private Vector3 releasePos;

    private Rigidbody rb;

    private bool isShoot;

    [SerializeField]
    float forceMultiplier = 3;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

  private void OnMouseDown()
    {
        pressDownPos = Input.mousePosition;
    }
    private void OnMouseUp()
    {
        releasePos = Input.mousePosition;
        Shoot(pressDownPos - releasePos);

    }
    void Shoot(Vector3 force)
    {
        if (isShoot)
        {
            return;
        }
        rb.AddForce(new Vector3(force.x, force.y, force.y) * forceMultiplier);
        isShoot = true;
    }
}
