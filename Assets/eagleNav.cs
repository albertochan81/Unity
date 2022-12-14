using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class eagleNav : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    public float timerForNewPath;
    bool InCoRoutine;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!InCoRoutine)
        StartCoroutine(DoSomething());
    }

    Vector3 getNewRandomPosition ()
    {
        float x = Random.Range(-100,100);
        float z = Random.Range (-80, 80);
        float y = Random.Range ( -10,10);

        Vector3 pos = new Vector3(x, y, z);
        return pos;

    }

    IEnumerator DoSomething ()
    {
        InCoRoutine = true;
        yield return new WaitForSeconds(timerForNewPath);
        GetNewPath();
        InCoRoutine = false;

    }
    void GetNewPath()
        {
            navMeshAgent.SetDestination(getNewRandomPosition());
        }
    

}

