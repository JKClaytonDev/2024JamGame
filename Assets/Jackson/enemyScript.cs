using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Animator anim;
    public float health;
    public void startLaugh()
    {
        FindObjectOfType<playerController>().tickleCount++;
        anim.Play("Laugh" + (int)Random.Range(1, 6));
        Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        health = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0)
            startLaugh();
    }
}
