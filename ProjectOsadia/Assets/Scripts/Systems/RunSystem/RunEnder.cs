using UnityEngine;
public class RunEnder : MonoBehaviour
{
    public static bool isDead;
    [SerializeField]private GameObject player;
    private void Start()
    {
        ChangeHealth.OnDeath += Death;
    }
    private void Death()
    {
        isDead = true;
        RunManager.isOnRun = false;
        player.GetComponent<FPS_MovementScript>().enabled = false;
        Debug.Log("�ld�k " + isDead);
        Debug.Log("Run Bitti " + RunManager.isOnRun);
    }
}
