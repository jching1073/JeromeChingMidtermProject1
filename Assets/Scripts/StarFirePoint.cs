using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFirePoint : MonoBehaviour
{
    [SerializeField] private GameObject stars;
    [SerializeField] private Transform firePoint;
    [SerializeField] float rate;
    private float fireCounter = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fireCounter -= Time.deltaTime;
        if (fireCounter <= 0)
        {
            fireCounter = rate;
            Instantiate(stars, firePoint.transform.position, firePoint.transform.rotation);
        }
    }
}