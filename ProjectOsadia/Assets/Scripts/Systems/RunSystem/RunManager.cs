using UnityEngine;

public class RunManager : MonoBehaviour
{
    [Header("RUN DATA")]
    public static bool isOnRun;
    public delegate void isRunning();
    public static event isRunning OnRunning;
    public static event isRunning OnDamaged;
    public static event isRunning OnHealed;
    public static event isRunning OnShowHealth;

    //bu metodda baya if var, ama b�y�k �o�unlu�u button �al��mas� i�in...
    private void OnGUI()
    {
        if (isOnRun)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Can� Azalt"))
            {
                if (RunManager.OnRunning != null && !RunEnder.isDead)
                {
                    OnDamaged();
                }
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 50, 35, 100, 30), "Can� Artt�r"))
            {
                if (RunManager.OnRunning != null)
                {
                    OnHealed();
                }
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 50, 95, 100, 30), "Can� G�ster"))
            {
                if (RunManager.OnRunning != null)
                {
                    OnShowHealth();
                }
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 50, 65, 100, 30), "Run'� ba�lat"))
            {
                if (RunManager.OnRunning != null)
                {
                    OnRunning();
                }
            }

        }

    }
       
}
