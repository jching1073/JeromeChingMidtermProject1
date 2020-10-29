using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    [SerializeField] private float speed = 7.5f;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.up;
        StartCoroutine(DestroyStars());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnBecameInvisible() //destroy bullet after a while
    {
        Destroy(gameObject);
    }
    public IEnumerator DestroyStars()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
