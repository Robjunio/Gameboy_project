using UnityEngine;

public class EnemySpawer : MonoBehaviour
{
    [SerializeField] private Transform target;

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

        if(timeBetweenWaves <= coun)
        {
            SpawnEnemies();
        }
        if(counter >= timeToBoss)
        {
            // SpawnBoss (Destroi esse codigo após isso)
        }
    }

    private void SpawnEnemies()
    {
        var enemyQnt = Random.Range(2 * Wave, Wave * 3);

        for(int i = 0; i < enemyQnt; i++)
        {
            var pos = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f) + new Vector3(5,5,0);

            var obj =Instantiate(enemiesPrefab[Random.Range(0, enemiesPrefab.Length - 1)], pos, Quaternion.identity);

            obj.GetComponent<Enemy>().SetTarget(target);
            enemies++;
        }
    }
}
