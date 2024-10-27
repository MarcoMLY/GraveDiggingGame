using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Data;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private TransformHolder _playerHolder, _houseDoorHolder;
    [SerializeField] private float _chasePlayerDistance, _chasePlantDistance, _playerPriotitizeDistance;
    [SerializeField] private LayerMask _player, _plants;
    [SerializeField] private LayerMask _zombies;
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
        Transform target = _houseDoorHolder.Variable;
        Transform closestPlant = FindCLosestPlant();
        float distance = Vector2.Distance(transform.position, _playerHolder.Variable.position);
        if (closestPlant != null)
        {
            if (distance > _chasePlayerDistance)
                target = closestPlant;
            if (distance <= _chasePlayerDistance)
            {
                float distanceToPlant = Vector2.Distance(transform.position, closestPlant.position);
                target = distanceToPlant + _playerPriotitizeDistance < distance ? closestPlant : _playerHolder.Variable;
            }
        }
        if (closestPlant == null & distance <= _chasePlayerDistance)
            target = _playerHolder.Variable;
        _destinationSetter.target = target;

        _enemyAnimation.SetAnimation(_aiPath.desiredVelocity, true);
    }

    private Transform FindCLosestPlant()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, _chasePlantDistance, _plants);
        Transform closestPlant = null;
        float closestDistance = Mathf.Infinity;
        foreach (Collider2D plant in hit)
        {
            float distance = Vector2.Distance(transform.position, plant.transform.position);
            if (distance < closestDistance && HasLineOfSight(plant))
            {
                closestPlant = plant.transform;
                closestDistance = distance;
            }
        }
        return closestPlant;
    }

    private bool HasLineOfSight(Collider2D collider)
    {
        RaycastHit2D[] ray = Physics2D.RaycastAll(transform.position, (collider.transform.position - transform.position).normalized, _chasePlayerDistance, _zombies);
        return ray.Length <= 1;
    }
}
