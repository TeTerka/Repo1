using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ManScript : MonoBehaviour {

    NavMeshAgent agent;
    Animator anim;
    public Transform target;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("walking", true);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        float dist = agent.remainingDistance;
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
            anim.SetBool("walking", false);
        else
            anim.SetBool("walking", true);
    }
}
