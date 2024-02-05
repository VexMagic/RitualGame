using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Villager : MonoBehaviour
{
    DT theTree;


    // stun?
    [SerializeField] float idleMinTime = 5f;
    [SerializeField] float idleMaxTime = 10f;
    float movmentSpeed = 6f;


    [SerializeField] Transform player;
    [SerializeField] Transform ritual;

    float idleTimeRemaining;

    float playerTargetRange = 10f;
    float playerTargetShootingRange = 7f;
    float meleeRange = 2f;
    float villagerTargetRange = 10f;
    float ritualTargetRange = 200f;

    int currentVillager;
    int currentPlayer;

    [SerializeField] bool isHitByVooDoo = false;

    bool notAtive = false;

    [SerializeField] bool ranged = false;

    [SerializeField] GameObject projectileVillagerPrefab;
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float shootCooldown = 3.5f;

    private float timeSinceLastShot = 0f;

    [SerializeField] CharacterManager characterManager;
    [SerializeField] ParticleSystem particleSystem;
    private List<GameObject> players = new List<GameObject>();
    private List<GameObject> agents = new List<GameObject>();
    private List<ObjectStats> attackingTargets = new List<ObjectStats>();
    [SerializeField] int damage = 1;
    [SerializeField] float attacksPerSecond = 0.5f;
    private float attackTimer;
    private void Awake()
    {
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] allAgents = GameObject.FindGameObjectsWithTag("Villager");

        players.AddRange(allPlayers);
        agents.AddRange(allAgents);
    }
    void Start()
    {

        theTree = new DT(
        new DecisionBranch
        {
            decisionFunction = () => IsVooDoo(),
            trueNode = new DecisionLeaf { action = UpdateAttackVillgare },
            falseNode = new DecisionBranch
            {
                decisionFunction = () => IsPlayerInRange(),
                trueNode = new DecisionLeaf { action = UpdatePlayerInRange },
                //falseNode = new DecisionLeaf { action = UpdateStateIdle }
                falseNode = new DecisionBranch
                {
                    decisionFunction = () => IsRitualInSight(),
                    trueNode = new DecisionLeaf { action = UpdateRitualInRange },
                    falseNode = new DecisionLeaf { action = UpdateExplotion } // player won, ritual done

                }
            }
        }
        );

        theTree.MakeDecision();
    }

    private void Update()
    {
        if (notAtive)
            return;

        AttackTargets();
        theTree.MakeDecision();
        
    }

    public void AtivateVodo(bool active)
    {
        isHitByVooDoo = active;
    }

    bool IsVooDoo()
    {
        if (isHitByVooDoo)
        {
            for (int i = 0; i < agents.Count; i++)
            {
                if (Vector2.Distance(agents[i].transform.position, this.transform.position) < villagerTargetRange)
                {
                    currentVillager = i;
                    return true;
                }
            }
        }
        return false;
    }
    bool IsRitualInSight()
    {
        if (Vector2.Distance(ritual.transform.position, this.transform.position) < ritualTargetRange)
        {
            return true;
        }
        return false;
    }

    bool IsPlayerInRange()
    {

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].transform.gameObject.activeSelf)
            {
                if (Vector2.Distance(players[i].transform.position, this.transform.position) < playerTargetRange)
                {
                    currentPlayer = i;
                    return true;
                }
            }

        }

        return false;
    }

    void UpdateAttackVillgare()
    {
        // hit by VooDoo
        // Attack other villeger
        transform.position = Vector2.MoveTowards(transform.position, agents[currentVillager].transform.position, movmentSpeed * Time.deltaTime);
    }
    void UpdatePlayerInRange()
    {
        if (ranged)
        {
            float distance = Vector2.Distance(players[currentPlayer].transform.position, this.transform.position);
            timeSinceLastShot += Time.deltaTime;
            if (distance < playerTargetShootingRange && meleeRange < distance)
            {
                if (timeSinceLastShot >= shootCooldown)
                {
                    ShootProjectile();
                    timeSinceLastShot = 0f;
                }
            }
            else if (meleeRange > distance)
            {
                Debug.Log("attack");
                // do attack
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, players[currentPlayer].transform.position, movmentSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, players[currentPlayer].transform.position, movmentSpeed * Time.deltaTime);
        }
        // move towards player        
    }

    void UpdateRitualInRange()
    {


        // move towards ritual
        transform.position = Vector2.MoveTowards(transform.position, ritual.transform.position, movmentSpeed * Time.deltaTime);
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectileVillagerPrefab, transform.position, Quaternion.identity);
        Vector2 direction = (players[currentPlayer].transform.position - transform.position).normalized;


        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = direction * projectileSpeed;

    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.gameObject.CompareTag("Player"))
    //    {

    //        GameObject enemyOb = collision.gameObject;
    //        enemyOb.SetActive(false);
    //    }
    //}
    void UpdateExplotion()
    {
        // Add explotion

        particleSystem.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    //Stun?
    void UpdateStateIdle()
    {
        //update idle time remaining
        idleTimeRemaining -= Time.deltaTime;
        if (idleTimeRemaining <= 0)
        {
        }

    }
    private void AttackTargets()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attacksPerSecond && attackingTargets.Count != 0)
        {
            attackTimer = 0;

            foreach (var target in attackingTargets)
            {
                target.TakeDamage(damage);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ritual"))
        {
            attackingTargets.Add(collision.gameObject.GetComponent<ObjectStats>());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Ritual"))
        {
            if (attackingTargets.Contains(collision.gameObject.GetComponent<ObjectStats>()))
            {
                attackingTargets.Remove(collision.gameObject.GetComponent<ObjectStats>());
            }
        }
    }
}
