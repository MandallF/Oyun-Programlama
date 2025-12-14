using UnityEngine;
using System.Collections;




public class SpawnManager_sc : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;
    [SerializeField] private bool stopSpawning = false;
    [SerializeField] private GameObject[] bonusPrefabs;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (stopSpawning == false)
        {
            Vector3 position = new Vector3(Random.Range(-9.5f, 9.5f), 7.4f, 0);
            GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            enemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

IEnumerator SpawnBonusRoutine()
{
    while (stopSpawning == false)
    {
        yield return new WaitForSeconds(Random.Range(3, 12));
        Vector3 position = new Vector3(Random.Range(-9.67f, 9.67f), 7.6f, 0);
        int randomBonus = Random.Range(0,3);
        Instantiate(bonusPrefabs[randomBonus], position, Quaternion.identity);
    }
}

    public void OnPlayerDeath()
    {
        stopSpawning = true;
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnBonusRoutine());
    }
}