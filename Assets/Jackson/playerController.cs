using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public Text timerText;
    Rigidbody rb;
    public Camera cam;
    public Animator featherAnim;
    int righttickleNum;
    int lefttickleNum;
    float startTime;
    public int tickleCount = 0;
    public AudioSource ticklen;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.realtimeSinceStartup;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        defaultAngles = new Vector3[leftfingees.Length];
        int i = 0;
        foreach (GameObject g in leftfingees)
        {
            defaultAngles[i] = g.transform.localEulerAngles;
            i++;
        }
    }
    public Vector3[] defaultAngles;
    public GameObject[] rightfingees;
    public GameObject righthandParent;
    public float[] righttickleNumbers;

    public GameObject[] leftfingees;
    public GameObject lefthandParent;
    public float[] lefttickleNumbers;
    // Update is called once per frame
    void Update()
    {
        timerText.text = "Time: " + (int)(startTime - Time.realtimeSinceStartup + 30)+"\nTickles: " + tickleCount;
        if ((startTime - Time.realtimeSinceStartup + 30) < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        //if (Vector3.Distance(new Vector3(), GetComponent<Rigidbody>().velocity) < 0.1f)
        {
            righthandParent.transform.localPosition = new Vector3(((float)righttickleNum - 3) / 30, 0, 0);

            if (Input.GetKeyDown(KeyCode.H))
                righttickleNum = 1;
            if (Input.GetKeyDown(KeyCode.J))
                righttickleNum = 2;
            if (Input.GetKeyDown(KeyCode.K))
                righttickleNum = 3;
            if (Input.GetKeyDown(KeyCode.L))
                righttickleNum = 4;
            if (Input.GetKeyDown(KeyCode.H))
                righttickleNumbers[0] += 0.2f;
            if (Input.GetKeyDown(KeyCode.J))
                righttickleNumbers[1] += 0.2f;
            if (Input.GetKeyDown(KeyCode.K))
                righttickleNumbers[2] += 0.2f;
            if (Input.GetKeyDown(KeyCode.L))
                righttickleNumbers[3] += 0.2f;
            for (int j = 0; j < righttickleNumbers.Length; j++)
            {
                righttickleNumbers[j] = Mathf.Min(1, Mathf.Max(0, righttickleNumbers[j] - Time.deltaTime));
            }
            int i = 0;
            foreach (GameObject g in rightfingees)
            {
                g.transform.localEulerAngles = defaultAngles[i] + 25 * new Vector3(0, 0, righttickleNumbers[i] * 25 * Mathf.Sin(Time.realtimeSinceStartup * 25 + i * 10));

                i++;
                Debug.Log("CHECKING FINGY " + i);
            }

            lefthandParent.transform.localPosition = new Vector3(((float)lefttickleNum - 3) / 30, 0, 0);

            if (Input.GetKeyDown(KeyCode.V))
                lefttickleNum = 1;
            if (Input.GetKeyDown(KeyCode.C))
                lefttickleNum = 2;
            if (Input.GetKeyDown(KeyCode.X))
                lefttickleNum = 3;
            if (Input.GetKeyDown(KeyCode.Z))
                lefttickleNum = 4;
            if (Input.GetKeyDown(KeyCode.V))
                lefttickleNumbers[0] += 0.2f;
            if (Input.GetKeyDown(KeyCode.C))
                lefttickleNumbers[1] += 0.2f;
            if (Input.GetKeyDown(KeyCode.X))
                lefttickleNumbers[2] += 0.2f;
            if (Input.GetKeyDown(KeyCode.Z))
                lefttickleNumbers[3] += 0.2f;
            for (int j = 0; j < lefttickleNumbers.Length; j++)
            {
                lefttickleNumbers[j] = Mathf.Min(1, Mathf.Max(0, lefttickleNumbers[j] - Time.deltaTime));
            }
            i = 0;
            foreach (GameObject g in leftfingees)
            {
                g.transform.localEulerAngles = defaultAngles[i] + 25 * new Vector3(0, 0, lefttickleNumbers[i] * 25 * Mathf.Sin(Time.realtimeSinceStartup * 25 + i * 10));

                i++;
                Debug.Log("CHECKING FINGY " + i);
            }
            rb.velocity = new Vector3();
            float totalTickle = 0;
            foreach (float f in righttickleNumbers)
                totalTickle += f;
            foreach (float f in lefttickleNumbers)
                totalTickle += f;
            ticklen.volume = totalTickle;
            totalTickle *= Time.deltaTime;
           
            foreach (Collider c in Physics.OverlapSphere(transform.position, 3))
            {
                if (c.gameObject.GetComponent<enemyScript>() && (((Input.GetKey(KeyCode.H) || Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.L)) && ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.V))))))
                    c.gameObject.GetComponent<enemyScript>().health -= totalTickle * 10;
            }
        }
         {
            rb.velocity = 10 * (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal"));
            transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X"), 0);
            cam.transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);
        }
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
        
        {
            
        }
        GetComponent<Rigidbody>().velocity /= 1 + Time.deltaTime * 0.05f;

    }
    float vertSpeed = 0;
}
