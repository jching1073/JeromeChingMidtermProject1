using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    
    public bool isInrange = false;
    public Animator anim;
    public GameObject pannel;

    [SerializeField] private GameObject stars;
    [SerializeField] private Transform firePoint;
    [SerializeField] float rate;
    private float fireCounter = .5f;
    private bool isOpens = false;

    private void Update()
    {
        if (isInrange && Input.GetKeyDown(KeyCode.E))
        {

            anim.SetBool("isOpen", true);
            isOpens = true;
        }
        if (isOpens)
        {
            fireCounter -= Time.deltaTime;
            if (fireCounter <= 0)
            {
                fireCounter = rate;
                Instantiate(stars, firePoint.transform.position, firePoint.transform.rotation);
            }

        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            pannel.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Inrange");
            isInrange = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Not Inrange");
            isInrange = false;
        }
    }

    public void FireStars()
    {
        fireCounter -= Time.deltaTime;
        if (fireCounter <= 0)
        {
            fireCounter = rate;
            Instantiate(stars, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
    
}
