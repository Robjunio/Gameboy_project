using UnityEngine;

public class EnemySpawer : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private LayerMask layerEnemyCannotSpawn;
    [SerializeField] private Collider2D collider2d;
    [SerializeField] private GameObject[] enemiesPrefab;
    [SerializeField] private GameObject bossPrefab;

    private int enemies;

    public float timeToBoss;
    public float timeBetweenWaves;
    public int Wave = 1;
    float counterWave = 0;
    float counter = 0;

    private void Start()
    {
        SpawnEnemies();
    }

    private void Update()
    {
        counter += Time.deltaTime;
        counterWave += Time.deltaTime;

        if(timeBetweenWaves <= counterWave && counter < timeToBoss)
        {
            SpawnEnemies();
            counterWave = 0;
        }
        if(counter >= timeToBoss)
        {
            // SpawnBoss (Destroi esse codigo após isso)
        }
    }

    private void SpawnEnemies()
    {
        var enemyQnt = Random.Range(2 * Wave, Wave * 4);

        for(int i = 0; i < enemyQnt; i++) {
            Vector2 spawnPos = GetRandomSpawnPosition();

            if (spawnPos == Vector2.zero)
            {
                break;
            }

            GameObject spawnedEnemy = Instantiate(enemiesPrefab[Random.Range(0, enemiesPrefab.Length - 1)], spawnPos, Quaternion.identity);

            var enemyBehaviour = spawnedEnemy.GetComponent<Enemy>();

            enemyBehaviour.SetTarget(target);
            enemies++;
        }

        Wave++;
    }

    private Vector2 GetRandomSpawnPosition()
    {
        Vector2 spawnPosition = Vector2.zero;
        bool isSpawnValid = false;

        int attemptCount = 0;
        int maxAttempt = 200;

        while(!isSpawnValid && attemptCount < maxAttempt ) {
            spawnPosition = GetRandomPointInCollider(collider2d);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 0.5f);

            bool isInvalidCollision = false;
            foreach(Collider2D collider in colliders)
            {
                if(((1 << collider.gameObject.layer) & layerEnemyCannotSpawn) != 0)
                {
                    isInvalidCollision = true;
                    break;
                }
            }

            if (!isInvalidCollision)
            {
                isSpawnValid = true;
            }

            attemptCount++;
        }

        if (!isSpawnValid)
        {
            Debug.LogWarning("Couldn't find a valid point");
        }

        return spawnPosition;
    }

    private Vector2 GetRandomPointInCollider(Collider2D collider, float offset = 1f)
    {
        Bounds collBounds = collider.bounds;

        Vector2 minBounds = new Vector2(collBounds.min.x + offset, collBounds.min.y + offset);
        Vector2 maxBounds = new Vector2(collBounds.max.x - offset, collBounds.max.y - offset);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);

        return new Vector2(randomX, randomY);
    }
}
