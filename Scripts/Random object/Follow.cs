using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Follow : MonoBehaviour
{
    //Levy flight (random walk algorithim)
    
    public NavMeshSurface area;

    public NavMeshAgent agent;

    private bool _donewithpath;

    void Start()
    {
        _donewithpath = true;
    }
    //constant update variables
    private Vector3 _gotopos;
    private Vector3 _postion;
    float _range = 0f;
    private float _randomoccurence;
    private Vector3 _move;
    private float _rangex;
    private float _rangez;
    
    void Update()
    {
        _postion = agent.transform.localPosition;
        
        _randomoccurence = Random.value * 100;
            if (_randomoccurence < 1)
            {
                _range = Random.Range(0.5f,1f) * 15;
            }
            else
            {
                _range = 5;
            }
            _move = new Vector3(Random.Range(-1f,1f),0,Random.Range(-1f,1f))*_range;
            _gotopos = _postion + _move;
            Navmeshmove(_gotopos);
        
        
        
        
    }

    void LateUpdate()
    {
        if (Vector3.Distance(_gotopos,agent.transform.localPosition) < 0.6f )
        {
            this._donewithpath = true;
        }
    }

    void Navmeshmove(Vector3 pos)
    {
        if (_donewithpath == true)
        {
            agent.SetDestination(pos);
            _donewithpath = false;
        }
        
    }
}
