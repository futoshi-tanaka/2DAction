using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshAgent : MonoBehaviour
{
    public GameObject m_targetObject;      // 移動予定のオブジェクト

    private NavMeshAgent m_navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            m_navMeshAgent.SetDestination(new Vector3(m_targetObject.transform.position.x, m_targetObject.transform.position.y, 0.0f));
        }
    }
}
