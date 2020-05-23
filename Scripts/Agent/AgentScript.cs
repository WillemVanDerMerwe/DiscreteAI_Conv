using System;
using UnityEngine;
using UnityEngine.AI;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class AgentScript : Agent
{
    public Transform target;

    public NavMeshAgent agent;
    
    
    
    void Follow()
    {
        agent.SetDestination(target.localPosition);
    }

    void Stop()
    {
        agent.isStopped = true;
    }

    void Update()
    {
        if (Vector3.Distance(target.transform.localPosition,agent.transform.localPosition) < 1.2f )
        {
            SetReward(0.2f);
        }
        else
        {
            SetReward(0.1f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.name.Equals(target.name) )
        {
            SetReward(-0.5f);
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(target.transform.localPosition);
        sensor.AddObservation(agent.transform.localPosition);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        
        int move = Mathf.FloorToInt(vectorAction[0]);
        switch (move)
        {
            case 1:
                Follow();
                break;
            case 2:
                Stop();
                break;
            
        }
    }
}
