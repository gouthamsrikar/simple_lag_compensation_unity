using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clientlag : MonoBehaviour
{
    public GameObject server;
    public float lagtime=0.2f;
    public float ping=0;
    public Vector3 position1,rotation1;
    public Vector3 position2,rotation2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clientprediction(server.transform.position, server.transform.eulerAngles);
    }
    void clientprediction(Vector3 position,Vector3 rotation)
    {
        ping += Time.deltaTime;
        if (ping >= lagtime)
        {
            changepos(position,rotation);
            ping = 0;
            position2 = position1;
            position1 = position;
            rotation2 = rotation1;
            rotation1 = rotation; ;
        }
        else
        {
            Vector3 fakedistance = (position1 - position2) / lagtime;
            transform.position += fakedistance * Time.deltaTime;
            Vector3 fakerotation = (rotation1 - rotation2) / lagtime;
            transform.eulerAngles += fakerotation * lagtime;
        }
    }
   void changepos(Vector3 position,Vector3 rotation)
    { 
        transform.position = position ;
        transform.eulerAngles =rotation;
    }

    
}
