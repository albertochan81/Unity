using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagleNav2 : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent navMeshAgent;
    public float timerForNewPath;
    public float timerForNewPath2;
    public float randomRangeX;
    public float randomRangeY;
    public float randomRangeZ;
    
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
        float x = Random.Range(-500,randomRangeX);
        float z = Random.Range (-500, randomRangeZ);
        float y = Random.Range ( -20,randomRangeY);

        Vector3 pos = new Vector3(x, y, z);
        return pos;

    }

    IEnumerator DoSomething ()
    {
        InCoRoutine = true;
        yield return new WaitForSeconds(timerForNewPath);
        GetNewPath();
        yield return new WaitForSeconds(timerForNewPath2);
        InCoRoutine = false;

    }
    void GetNewPath()
        {
            navMeshAgent.SetDestination(getNewRandomPosition());
        }
    

}


 
