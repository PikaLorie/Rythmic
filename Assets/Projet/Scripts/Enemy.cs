using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private CharacterCombat combat = null;
 
    private void Awake()
    {
        combat.SetCombatMode(true);
    }

    private void Update()
    {
        combat.Punch();
    }
}
