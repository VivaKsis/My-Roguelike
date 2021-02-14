using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private CharacterBattle playerCharacterBattle;
    [SerializeField] private List<Transform> enemyCharacters;
    [SerializeField] private RaycastEmitter _raycastEmitter;

    private List<CharacterBattle> enemiesCharacterBattles = new List<CharacterBattle>();
    private CharacterBattle activeCharacterBattle;

    private RaycastHit _raycastHit;

    private enum State
    {
        WaitingForPlayer,
        Busy,
        GameOver
    }

    private State state;

    private int activeEnemyIndex;

    private CharacterBattle SpawnCharacter(Vector3 position, Transform character)
    {
        return Instantiate(character, position, Quaternion.identity).GetComponent<CharacterBattle>();
    }

    private void Start()
    {
        /*for (int a = 0; a < enemyCharacters.Count; a++)
        {
            enemiesCharacterBattles.Add(SpawnCharacter(enemyCharacters[a]));
        }*/
        enemiesCharacterBattles.Add(SpawnCharacter(new Vector3(-25, 0), enemyCharacters[0]));
        //enemiesCharacterBattles.Add(SpawnCharacter(new Vector3(-5, 0), enemyCharacters[1]));

        SetActiveCharacterBattle(playerCharacterBattle);
        state = State.WaitingForPlayer;
    }

    private void SetActiveCharacterBattle(CharacterBattle ñharacterBattle)
    {
        activeCharacterBattle = ñharacterBattle;
    }

    private bool IsBattleOver()
    {
        if (playerCharacterBattle.IsDead)
        {
            // Enemy wins
            Debug.Log("Enemy wins");
            return true;
        }
        for(int a = 0; a < enemiesCharacterBattles.Count; a++)
        {
            if (!enemiesCharacterBattles[a].IsDead)
            {
                return false;
            }
        }
        // Player wins
        Debug.Log("Player wins");
        return true;
    }

    private void ChooseNextActiveEnemyCharacterBattle()
    {
        SetActiveCharacterBattle(enemiesCharacterBattles[activeEnemyIndex]);

        enemiesCharacterBattles[activeEnemyIndex].Attack(playerCharacterBattle, onAttackComplete: () =>
        {
            activeEnemyIndex++;
            if(activeEnemyIndex == enemiesCharacterBattles.Count)
            {
                ChooseNextActiveCharacterBattle();
            }
            else
            {
                ChooseNextActiveEnemyCharacterBattle();
            }
        });
    }

    private void ChooseNextActiveCharacterBattle()
    {
        if (IsBattleOver())
        {
            activeCharacterBattle = null;
            state = State.GameOver;
            return;
        }
        if(activeCharacterBattle == playerCharacterBattle)
        {
            state = State.Busy;
            activeEnemyIndex = 0;
            ChooseNextActiveEnemyCharacterBattle();
        }
        else
        {
            SetActiveCharacterBattle(playerCharacterBattle);
            state = State.WaitingForPlayer;
        }
    }

    private void Update()
    {
        if (state == State.WaitingForPlayer) 
        {
            Ray ray = Camera.main.ScreenPointToRay(pos: Input.mousePosition);

            if (_raycastEmitter.Raycast(ray: ray, raycastHit: out _raycastHit))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    CharacterBattle targetCharacterBattle = _raycastHit.transform.gameObject.GetComponentInParent<CharacterBattle>();
                    if (targetCharacterBattle && targetCharacterBattle != playerCharacterBattle)
                    {
                        state = State.Busy;
                        playerCharacterBattle.Attack(targetCharacterBattle, () =>
                        {
                            ChooseNextActiveCharacterBattle();
                        });
                    }
                }
            }
        }
    }
}
