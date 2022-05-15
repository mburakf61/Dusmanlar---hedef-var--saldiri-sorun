using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    public float can = 100;

    private Animator anim;

    public bool oldumu = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void HasarVer (float amount)
    {
        can -= amount;

        if(can <= 0)
        {
            Olum();
        }
    }

    public void Olum ()
    {
        anim.SetBool("Oldu", true);
        oldumu = true;
        gameObject.tag = "Untagged";
        StartCoroutine(sil());
    }

    IEnumerator sil ()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
}
