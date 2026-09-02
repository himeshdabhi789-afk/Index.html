using UnityEngine;
using UnityEngine.AI;

public class GrannyEnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    // Attacking & Detection
    public float sightRange = 15f;
    public float attackRange = 2f;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        // પ્લેયર રેન્જમાં છે કે નહીં તે ચેક કરશે
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void ChasePlayer()
    {
        // પ્લેયરની પાછળ ભાગશે
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        // પ્લેયર નજીક આવે ત્યારે અટેક કરશે
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        Debug.Log("Granny Attacked Player!");
        // અહીં તમે પ્લેયરના ડેમેજ અથવા Game Over નો કોડ ઉમેરી શકો છો
    }
}
