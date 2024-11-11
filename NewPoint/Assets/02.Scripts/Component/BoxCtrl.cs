using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCtrl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Enable());
        }
    }

    IEnumerator Enable()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);

        Invoke("Disable", 3);
    }

    void Disable()
    {
        this.gameObject.SetActive(true);
    }
}
