using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBoxes : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float defaultAngularDrag = 1;
    private bool stopCube = false;
    public GameManager gameManager;
    [SerializeField]
    private bool isEmpty = false;
    [SerializeField]
    private bool isX = false;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        TMP_Text[] facesOfThisBox = gameObject.GetComponentsInChildren<TMP_Text>();
        if (isEmpty)
        {
            for (int i = 0; i < facesOfThisBox.Length; i++)
            {
                facesOfThisBox[i].text = " ";
                isEmpty = true;
            }
        }
        else
        {
            if (isX)
            {
                facesOfThisBox[0].text = "X";
                facesOfThisBox[1].text = "X";
                facesOfThisBox[2].text = "O";
                facesOfThisBox[3].text = "O";
                isEmpty = false;
                isX = true;
            }
            else
            {
                facesOfThisBox[0].text = "O";
                facesOfThisBox[1].text = "O";
                facesOfThisBox[2].text = "X";
                facesOfThisBox[3].text = "X";
                isEmpty = false;
                isX = false;
            }
            
        }
    }
    private void Update()
    {
        if (Mathf.Abs(rb.angularVelocity.z) < 1 && Mathf.Abs(rb.angularVelocity.z) > 0.05)
        {
            rb.angularDrag = 0;
            stopCube = true;
            
        }

        if (stopCube && transform.localRotation.eulerAngles.x % 90 <= 5)
        {
            stopCube = false;
            transform.eulerAngles = new Vector3(GetClosestNumber(transform.localRotation.eulerAngles.x, 90), transform.eulerAngles.y, transform.eulerAngles.z); // atýþ yapýldýktan sonra sapanýn yönünü yine default haline çeviriyoruz
            rb.angularDrag = defaultAngularDrag;
            rb.angularVelocity = Vector3.zero;
            TMP_Text[] facesOfThisBox = gameObject.GetComponentsInChildren<TMP_Text>();
            if(facesOfThisBox[0].text == "X")
            {
                isX = true;
            }
            else
            {
                isX = false;
            }
            gameManager.BoardPattern();
            //gameManager.checkWinner();
            
        }



    }

    static float GetClosestNumber(float value, float step)
    {
        // Get the absolute values of our arguments
        var absValue = Mathf.Abs(value);
        step = Mathf.Abs(step);

        // Determing the numbers on either side of value
        var low = absValue - absValue % step;
        var high = low + step;

        // Return the closest one, multiplied by -1 if value < 0
        var result = absValue - low < high - absValue ? low : high;

        return result * Mathf.Sign(value);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isEmpty && Mathf.Abs(rb.angularVelocity.z) > 0.5f)
        {
            TMP_Text[] thisBox = gameObject.GetComponentsInChildren<TMP_Text>();
            thisBox[0].text = "X";
            thisBox[1].text = "X";
            thisBox[2].text = "O";
            thisBox[3].text = "O";
            isEmpty = false;
        }

    }


}

