using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private float _timeToSpawn;

    [SerializeField] private TMP_Text _speedText;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _distanceText;
    
    
    private SpawnPoint[] _spawnPoints;
    private float _timer;

    private float _cubeSpeed = 5f;
    private float _cubeDistance = 5f;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        InitializeTexts();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeToSpawn)
        {
            SpawnPoint randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            var cube = Instantiate(_cube, randomSpawnPoint.transform);
            cube.GetComponent<CubeMover>().SetSpeedAndDistance(_cubeDistance, _cubeSpeed);
            _timer = 0;
        }
    }

    private void InitializeTexts()
    {
        _distanceText.text = _cubeDistance.ToString();
        _timeText.text = _timeToSpawn.ToString();
        _speedText.text = _cubeSpeed.ToString();
    }

    public void ChangeDistance(float distanceToChange)
    {
        _cubeDistance += distanceToChange;
        _distanceText.text = _cubeDistance.ToString();
    }
    
    public void ChangeTimeToSpawn(float TimeToChange)
    {
        _timeToSpawn += TimeToChange;
        _timeText.text = _timeToSpawn.ToString();
    }
    
    public void ChangeSpeed(float speedToChange)
    {
        _cubeSpeed += speedToChange;
        _speedText.text = _cubeSpeed.ToString();
    }
}
