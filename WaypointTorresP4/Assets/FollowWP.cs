using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWp = 0;
    public float rotSpeed = 10.0f;
    public float speed = 10.0f;
    GameObject tracker;
    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }
    void ProgressTracker()
    {
        if (Vector3.Distance(this.transform.position, waypoints[currentWp].transform.position) < 3)
        {
            currentWp++;
        }
        if (currentWp >= waypoints.Length)
        {
            currentWp = 0;
        }
        tracker.transform.LookAt(waypoints[currentWp].transform.position);
        tracker.transform.Translate(0, 0, 0.1f);
    }
    // Update is called once per frame
    void Update()
    {
        ProgressTracker();
        //this.transform.LookAt(waypoints[currentWp].transform);
        
        //Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWp].transform.position - this.transform.position);
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);
        //this.transform.Translate(0,0,speed * Time.deltaTime);
    }
}
