using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{

    public float mesafe;

    private Transform hedef;

    //private Player pr;

    NavMeshAgent agent;

    Animator anim;

    public Dusman dusman;
    public int Hasar;

    bool saldiri = false;


    void Start()
    {
        hedef = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //pr = GameObject.FindWithTag("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if (dusman.oldumu == false && saldiri == false)
        {
            anim.SetFloat("Hiz", agent.velocity.magnitude);

            mesafe = Vector3.Distance(transform.position, hedef.position);

            if (mesafe <= 25)
            {
                agent.enabled = true;
                agent.destination = hedef.position;
            }
            else
            {
                agent.enabled = false;
            }
            if (mesafe <= 1.2)
            {
                agent.enabled = false;
            }
            if (dusman.oldumu == true)
            {
                agent.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (dusman.oldumu == false)
            {
                anim.SetBool("Saldir", true);
                saldiri = true;
                StartCoroutine(saldir());
            }
        }
    }

    IEnumerator saldir ()
    {
        yield return new WaitForSeconds(0.5f);
      //  pr.Hasar(Hasar);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Saldir", false);
        saldiri = false;
    }

}
