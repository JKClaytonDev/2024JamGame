using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class copChaser : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        {
            RaycastHit hit;
            transform.LookAt(player.transform);
            Physics.Raycast(transform.position, transform.forward, out hit);
            if (hit.transform.gameObject == player)
                GetComponent<NavMeshAgent>().speed = 15;
        }
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        if (Vector3.Distance(transform.position, GetComponent<NavMeshAgent>().destination) < 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
