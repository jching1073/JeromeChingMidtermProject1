using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInrange;
    public KeyCode interactKey;
    public UnityEvent ineract;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInrange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                ineract.Invoke(); //fireEvent
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInrange = true;
            Debug.Log("Inrange");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInrange = false;
            Debug.Log("Not Inrange");
        }
    }
}
