using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Data;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private TransformHolder _playerHolder;
    [SerializeField] private TransformHolder _houseDoorHolder;
    [SerializeField] private float _chasePlayerDistance;
    private AIPath _aiPath;
    private PlayerAnimation _enemyAnimation;
    private AIDestinationSetter _destinationSetter;

    // Start is called before the first frame update
    void Start()
    {
        _aiPath = GetComponent<AIPath>();
        _enemyAnimation = GetComponent<PlayerAnimation>();
        _destinationSetter = GetComponent<AIDestinationSetter>();
        _destinationSetter.target = _playerHolder.Variable;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, _playerHolder.Variable.position);
        if (distance <= _chasePlayerDistance)
            _destinationSetter.target = _playerHolder.Variable;
        if (distance > _chasePlayerDistance)
            _destinationSetter.target = _houseDoorHolder.Variable;
        _enemyAnimation.SetAnimation(_aiPath.desiredVelocity, true);
    }
}
