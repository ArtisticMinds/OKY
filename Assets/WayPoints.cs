using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class WayPoints : MonoBehaviour {

    public Transform[] points;
    int i = 0;


    void OnEnable () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        List<Transform> transforms = new List<Transform>(GetComponentsInChildren<Transform>());
        transforms.Remove(transform);
        points = transforms.ToArray();

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        // important to reduce the upper limit by one since we add 1 inside the loop
        for (int i = 0; i < points.Length - 1; i++)
        {
            Gizmos.DrawLine(points[i].position, points[i+1].position);
         
        }
        Gizmos.color = Color.green;
        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.DrawSphere(points[i].position, 0.1f);
        }
    }

    void Start () {
        if (Application.isPlaying) transform.SetParent(null);
	}
}
