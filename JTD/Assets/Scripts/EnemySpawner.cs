using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /*
        Method for using instantiation
        - Provide list of enemy GameObjects
        - In Start(), have method InstantiateEnemies() that creates all rounds and fills our 'rounds' list
        - Will still use old method of keeping track of inactive (dead) enemies and such
    */

    public static EnemySpawner enemySpawner;
    UI_Manager uiManager;

    // 0 = Rat , 1 = Bat , 2 = Crab , 3 = Golem , 4 = Reinforced Golem
    public GameObject[] EnemyPrefabs;
    [SerializeField] SoundFX_Manager soundManager;
    
    private static int Rounds_Size = 10;
    private static int AmountOfRounds = 10;
    private GameObject[] currentRound = new GameObject[Rounds_Size];
    private GameObject[] round_1 = new GameObject[Rounds_Size];
    private GameObject[] round_2 = new GameObject[Rounds_Size];
    private GameObject[] round_3 = new GameObject[Rounds_Size];
    private GameObject[] round_4 = new GameObject[Rounds_Size];
    private GameObject[] round_5 = new GameObject[Rounds_Size];
    private GameObject[] round_6 = new GameObject[Rounds_Size];
    private GameObject[] round_7 = new GameObject[Rounds_Size];
    private GameObject[] round_8 = new GameObject[Rounds_Size];
    private GameObject[] round_9 = new GameObject[Rounds_Size];
    private GameObject[] round_10 = new GameObject[Rounds_Size];
    public GameObject enemyToSpawn;
    public GameObject StartWaveButtonObject;
    public GameObject roundCompletionText;
    public Transform spawnPoint;

    private float spawnDelay = 1.0f;
    private float timeSinceLastSpawn = 0f;
    private int currentRoundIndex = 0;
    private int currentEnemyIndex = 0;
    private int runningLength; // Keeps track of how many enemies are in a round, even as they die
    public bool allRoundsCompleted = false;
    public bool roundComplete;
    private bool finishRound; // Use this to limit EndRound() to only occur once after a round is over

    private void Start()
    {
        enemySpawner = this;
        roundComplete = true;
        InstantiateEnemies();
        currentRound = round_1;
        runningLength = currentRound.Length;
        roundCompletionText.SetActive(false);
        uiManager = GetComponent<UI_Manager>();
        uiManager.PlayRoundMusic(currentRoundIndex);
    }

    private void InstantiateEnemies()
    {
        for (int i = 0 ; i < Rounds_Size; i++)
        {
            // For first 4 enemies
            if (i < 4)
            {
                round_1[i] = Instantiate(EnemyPrefabs[0], spawnPoint.position, spawnPoint.rotation); // First 4 enemies of round 1 are rats
                round_1[i].gameObject.SetActive(false);

                round_2[i] = Instantiate(EnemyPrefabs[0], spawnPoint.position, spawnPoint.rotation); // First 4 enemies of round 2 are rats
                round_2[i].gameObject.SetActive(false);

                round_3[i] = Instantiate(EnemyPrefabs[1], spawnPoint.position, spawnPoint.rotation); // First 4 enemies of round 3 are bats
                round_3[i].gameObject.SetActive(false);

                round_4[i] = Instantiate(EnemyPrefabs[1], spawnPoint.position, spawnPoint.rotation); // First 4 enemies of round 4 are bats
                round_4[i].gameObject.SetActive(false);

                round_5[i] = Instantiate(EnemyPrefabs[2], spawnPoint.position, spawnPoint.rotation); // First 4 enemies of round 5 are crabs
                round_5[i].gameObject.SetActive(false);

                round_6[i] = Instantiate(EnemyPrefabs[0], spawnPoint.position, spawnPoint.rotation); // First 4 enemies of round 6 are rats
                round_6[i].gameObject.SetActive(false);

                round_7[i] = Instantiate(EnemyPrefabs[3], spawnPoint.position, spawnPoint.rotation); // First 4 enemies of round 7 are golems
                round_7[i].gameObject.SetActive(false);

                round_8[i] = Instantiate(EnemyPrefabs[3], spawnPoint.position, spawnPoint.rotation); // First 4 enemies of round 8 are golems
                round_8[i].gameObject.SetActive(false);

                round_9[i] = Instantiate(EnemyPrefabs[3], spawnPoint.position, spawnPoint.rotation); // First 4 enemies of round 9 are golems
                round_9[i].gameObject.SetActive(false);

                round_10[i] = Instantiate(EnemyPrefabs[4], spawnPoint.position, spawnPoint.rotation); // First 4 enemies of round 10 are reinforced golems
                round_10[i].gameObject.SetActive(false);
            }

            // Enemies 5 - 7
            else if (i >= 4 && i < 7)
            {
                round_1[i] = Instantiate(EnemyPrefabs[0], spawnPoint.position, spawnPoint.rotation); // 5th - 7th enemies of round 1 are rats
                round_1[i].gameObject.SetActive(false);

                round_2[i] = Instantiate(EnemyPrefabs[1], spawnPoint.position, spawnPoint.rotation); // 5th - 7th enemies of round 2 are bats
                round_2[i].gameObject.SetActive(false);
                
                round_3[i] = Instantiate(EnemyPrefabs[1], spawnPoint.position, spawnPoint.rotation); // 5th - 7th enemies of round 3 are bats
                round_3[i].gameObject.SetActive(false);

                round_4[i] = Instantiate(EnemyPrefabs[2], spawnPoint.position, spawnPoint.rotation); // 5th - 7th enemies of round 4 are crabs
                round_4[i].gameObject.SetActive(false);

                round_5[i] = Instantiate(EnemyPrefabs[2], spawnPoint.position, spawnPoint.rotation); // 5th - 7th enemies of round 5 are crabs
                round_5[i].gameObject.SetActive(false);

                round_6[i] = Instantiate(EnemyPrefabs[0], spawnPoint.position, spawnPoint.rotation); // 5th - 7th enemies of round 6 are rats
                round_6[i].gameObject.SetActive(false);

                round_7[i] = Instantiate(EnemyPrefabs[3], spawnPoint.position, spawnPoint.rotation); // 5th - 7th enemies of round 7 are golems
                round_7[i].gameObject.SetActive(false);

                round_8[i] = Instantiate(EnemyPrefabs[2], spawnPoint.position, spawnPoint.rotation); // 5th - 7th enemies of round 8 are crabs
                round_8[i].gameObject.SetActive(false);

                round_9[i] = Instantiate(EnemyPrefabs[3], spawnPoint.position, spawnPoint.rotation); // 5th - 7th enemies of round 9 are golems
                round_9[i].gameObject.SetActive(false);

                round_10[i] = Instantiate(EnemyPrefabs[4], spawnPoint.position, spawnPoint.rotation); // 5th - 7th enemies of round 10 are reinforced golems
                round_10[i].gameObject.SetActive(false);
            }
            
            // Enemies 8 - 10
            else
            {
                round_1[i] = Instantiate(EnemyPrefabs[0], spawnPoint.position, spawnPoint.rotation); // 8th - 10th enemies of round 1 are rats
                round_1[i].gameObject.SetActive(false);
                
                round_2[i] = Instantiate(EnemyPrefabs[1], spawnPoint.position, spawnPoint.rotation); // 8th - 10th enemies of round 2 are bats
                round_2[i].gameObject.SetActive(false);
                
                round_3[i] = Instantiate(EnemyPrefabs[1], spawnPoint.position, spawnPoint.rotation); // 8th - 10th enemies of round 3 are bats
                round_3[i].gameObject.SetActive(false);

                round_4[i] = Instantiate(EnemyPrefabs[2], spawnPoint.position, spawnPoint.rotation); // 8th - 10th enemies of round 4 are crabs
                round_4[i].gameObject.SetActive(false);

                round_5[i] = Instantiate(EnemyPrefabs[2], spawnPoint.position, spawnPoint.rotation); // 8th - 10th enemies of round 5 are crabs
                round_5[i].gameObject.SetActive(false);

                round_6[i] = Instantiate(EnemyPrefabs[0], spawnPoint.position, spawnPoint.rotation); // 8th - 10th enemies of round 6 are rats
                round_6[i].gameObject.SetActive(false);

                round_7[i] = Instantiate(EnemyPrefabs[3], spawnPoint.position, spawnPoint.rotation); // 8th - 10th enemies of round 7 are golems
                round_7[i].gameObject.SetActive(false);

                round_8[i] = Instantiate(EnemyPrefabs[3], spawnPoint.position, spawnPoint.rotation); // 8th - 10th enemies of round 8 are golems
                round_8[i].gameObject.SetActive(false);

                round_9[i] = Instantiate(EnemyPrefabs[2], spawnPoint.position, spawnPoint.rotation); // 8th - 10th enemies of round 9 are crabs
                round_9[i].gameObject.SetActive(false);

                round_10[i] = Instantiate(EnemyPrefabs[4], spawnPoint.position, spawnPoint.rotation); // 8th - 10th enemies of round 10 are reinforced golems
                round_10[i].gameObject.SetActive(false);
            }
        }
    }

    private void NullifyEnemies()
    {
        for (int i = 0 ; i < Rounds_Size; i++)
        {
            round_1[i] = null;
            round_2[i] = null;
            round_3[i] = null;
            round_4[i] = null;
            round_5[i] = null;
            round_6[i] = null;
            round_7[i] = null;
            round_8[i] = null;
            round_9[i] = null;
            round_10[i] = null;
        }
    }

    public void ResetEnemySpawner()
    {
        NullifyEnemies();
        InstantiateEnemies();
        currentRound = round_1;
        currentRoundIndex = 0;
        currentEnemyIndex = 0;
        roundComplete = true;
        runningLength = currentRound.Length;
        roundCompletionText.SetActive(false);
        StartWaveButtonObject.SetActive(true);
    }

    private void Awake()
    {
        enemySpawner = this;
    }


    private void Update()
    {
        if (!roundComplete)
        {
            timeSinceLastSpawn += Time.deltaTime;
            UpdateEnemyIndex();

            if (timeSinceLastSpawn >= spawnDelay)
            {
                SpawnEnemy();
                timeSinceLastSpawn = 0f;
            }
            
            roundComplete = CheckRoundCompletion();
            
        }
        else if (roundComplete && finishRound)
        {
            EndRound();
            CheckGameCompletion();
        }
    }

    // This function starts the round solely by the if-statement in "Update()"
    public void StartWave()
    {
        soundManager.Play_ClickSound();
        
        currentEnemyIndex = 0;
        runningLength = currentRound.Length;
        StartWaveButtonObject.SetActive(false);
        uiManager.UpdateWaveText();
        uiManager.PlayRoundMusic(currentRoundIndex + 1);
        roundComplete = false;
    }

    private void SpawnEnemy()
    {
        // Only spawn enemies when round isn't complete
        if(!roundComplete && currentEnemyIndex < Rounds_Size)
        {
            // Next enemy to spawn is the next child of the round parent
            enemyToSpawn = currentRound[currentEnemyIndex].gameObject;
            enemyToSpawn.SetActive(true);
            currentEnemyIndex++;
        }
    }


    private void UpdateEnemyIndex()
    {
        /* 
        ISSUE: 
            - As the knight killed enemies, they were destroyed, lessening the number of children of the round parent
            - The currentEnemyIndex had no way of accounting for this change and would often try to spawn an enemy index out of bounds
        
        SOLUTION:
            - When round starts, set 'runningLength' to how many enemies there are
            - Constantly check for if the childCount (number of enemies) of the round is less than the most recent number of enemies
            - If it has changed, subtract this difference from the currentEnemyIndex
            - Then change 'runningLength' to how many enemies there currently are  
        */

        if (currentRound.Length < runningLength)
        {
            int temp = runningLength - currentRound.Length;
            currentEnemyIndex -= temp;
            runningLength = currentRound.Length;
        }
    }
    

    private void EndRound()
    {
        currentRoundIndex++; // Increment this so we know to go to the next round on the next StartWave() call
        StartWaveButtonObject.SetActive(true);
        roundCompletionText.SetActive(true);
        Invoke(nameof(DisableRoundCompletionText), 2.0f); // Disables the "All Enemies Defeated!" text after 2 seconds
        finishRound = false;
        UpdateCurrentRound();
    }

    private bool CheckRoundCompletion()
    {       
        for(int i = 0; i < currentRound.Length; i++)
        {
            // If we find one enemy from the round who's not null, return true
            if (currentRound[i] != null)
            {
                return false;
            }
        }
        finishRound = true;
        return true;
        
    }

    private void CheckGameCompletion()
    {
        // If this is the last round, then the level is complete
        if(currentRoundIndex == AmountOfRounds && !uiManager.screenBlackedOut)
        {
            uiManager.PlayerHasWon();
        }
    }

    private void UpdateCurrentRound()
    {
        if (currentRoundIndex == 0)
        {
            currentRound = round_1;
        } 
        else if (currentRoundIndex == 1)
        {
            currentRound = round_2;
        }
        else if (currentRoundIndex == 2)
        {
            currentRound = round_3;
        }
        else if (currentRoundIndex == 3)
        {
            currentRound = round_4;
        }
        else if (currentRoundIndex == 4)
        {
            currentRound = round_5;
        }
        else if (currentRoundIndex == 5)
        {
            currentRound = round_6;
        }
        else if (currentRoundIndex == 6)
        {
            currentRound = round_7;
        }
        else if (currentRoundIndex == 7)
        {
            currentRound = round_8;
        }
        else if (currentRoundIndex == 8)
        {
            currentRound = round_9;
        }
        else if (currentRoundIndex == 9)
        {
            currentRound = round_10;
        }
    }

    private void DisableRoundCompletionText()
    {
        roundCompletionText.SetActive(false);
    }
}
