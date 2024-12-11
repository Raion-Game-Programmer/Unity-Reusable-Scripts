using UnityEngine;

public class Player : MonoBehaviour, IDamagable {

    #region Variables
    public float speed = 5f;
    //if has sprinting
    //public float speedMultiplier = 2f;

    public float jumpForce = 5f;

    //combats
    public float attackDamage = 10f;
    public float attackDelay;

    //health
    public float currentHealth;
    public float maxHealth;


    #endregion
    private void Awake() {
        // playerControls = new PlayerInputActions();
    }
}