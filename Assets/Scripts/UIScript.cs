using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject Pannel;

   public void OpenPannel()
    {
        if (Pannel != null)
        {
            Pannel.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Pannel.SetActive(true);
        }
    }
}
