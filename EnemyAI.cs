using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private float enemyHealth = 100f;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    private Animation anim;
    private float contadorstun;
    //patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    private float deathtime;
    private bool Dead;
    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    private bool stunned;
    bool x;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //damage skills
    [SerializeField]
    float damageEnemyskill2 = 40;
    [SerializeField]
    float damageEnemyskill3;






    private void Start()
    {
        contadorstun = 9.5f;
        stunned = false;
        deathtime = 3f;
        Dead = false;

    }
    private void Awake()
    {
        anim = gameObject.GetComponent<Animation>();
        player = GameObject.Find("firstperso").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
      
     //check for sigh and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if (stunned == false)
        {

            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();
        }
        stun_check();
        firedamage();
       

       
        death();
      
        

    }

    private void stun_check()
    {

        if (Input.GetKey(KeyCode.G) && contadorstun == 9.5f)
        {
            stunned = true;
            EnemyHealth sn = gameObject.GetComponent<EnemyHealth>();
            sn.HealthDeduct(damageEnemyskill2);
            enemyHealth = enemyHealth - damageEnemyskill2;
        }
        if (stunned == true)
        {
            agent.SetDestination(transform.position);
            contadorstun -= Time.deltaTime;
            anim.Play("stunn");
            Debug.Log(contadorstun);

        }

        if ((contadorstun < 0) && (enemyHealth > 0))
        {
            stunned = false;
            anim.Play("run");
            contadorstun = 9.5f;
            Debug.Log(contadorstun);
        }

    }


    void OnTriggerEnter(Collider collider)
    {
     
        x = true;
    }

    void OnTriggerExit(Collider collider)
    {
       
        x = false;
    }


    private void firedamage()
    {
        if (x == true)
        {
            damageEnemyskill3 = Time.deltaTime * 20;
            EnemyHealth sn = gameObject.GetComponent<EnemyHealth>();
            sn.HealthDeduct(damageEnemyskill3);
            enemyHealth = enemyHealth - damageEnemyskill3;
        }
    }

    private void death()
    {
        if (enemyHealth < 0)
        {
            Dead = true;
            agent.SetDestination(transform.position);
            stunned = false;
            anim = gameObject.GetComponent<Animation>();
            anim.Play("death");
            deathtime -= Time.deltaTime;
            if (deathtime < 0.5)
                Destroy(gameObject);
                Dead = false;
        }
            
    }


    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;


    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {

            anim.Play("attack1");

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }


    private void ResetAttack()
    {
        alreadyAttacked = false;
        anim.Play("run");
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }
}