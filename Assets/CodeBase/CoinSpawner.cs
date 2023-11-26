using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _spawnPoints;

    private Coroutine _spawnCoinJob;
    private bool _isGameWorked;

    private void OnEnable()
    {
        _isGameWorked = true;
        _spawnCoinJob = StartCoroutine(SpawnCoin());
    }

    private void OnDisable() => 
        StopCoroutine(_spawnCoinJob);

    private IEnumerator SpawnCoin()
    {
        WaitForSeconds waitTime = new WaitForSeconds(1f);

        while (_isGameWorked)
        {
            yield return waitTime;

            {
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                Instantiate(_coin, _spawnPoints[spawnPointNumber].position, Quaternion.identity);
            }            
        }        
    }
}