using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class copChaser : MonoBehaviour
{
    public GameObject chasedText;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().speed = 0;
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
            {
                GetComponent<NavMeshAgent>().speed = 12;
                chasedText.SetActive(true);
                GetComponent<AudioSource>().enabled = true;
                GetComponent<Animator>().speed = 1;
            }
        }
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        Vector3 angles = transform.eulerAngles;
        angles.x = 0;
        angles.z = 0;
        transform.eulerAngles = angles;
        if (Vector3.Distance(transform.position, GetComponent<NavMeshAgent>().destination) < 1)
        {
            player.transform.LookAt(transform);
            SceneManager.LoadScene("GameEnd");
        }
    }
}
