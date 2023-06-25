using System;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    [Header("RUN DATA")]
    public static bool isOnRun;
    public static event EventHandler OnDamaged;
    public static event EventHandler OnHealed;
    public static event EventHandler OnRunning;
    public static event EventHandler OnShowHealth;
    RunStarter runStarter;


    //bu metot ekrandaki tu�lar�n bir k�sm�ndan sorumlu, run, can g�t�rme gibi.
    //Silinebilir ama eventler d�zenlenmeden silinmesini tavsiye etmem.
    private void OnGUI()
    {
        if (isOnRun)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, 65, 100, 30), "Can� Azalt"))
            {
                if (!RunEnder.isDead)
                {
                    OnDamaged?.Invoke(this, EventArgs.Empty);
                }
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 50, 35, 100, 30), "Can� Artt�r"))
            {
                if (!RunEnder.isDead)
                {
                    OnHealed?.Invoke(this, EventArgs.Empty); 
                }
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 50, 95, 100, 30), "Can� G�ster"))
            {
                OnShowHealth?.Invoke(this, EventArgs.Empty);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Run'� ba�lat"))
            {
                OnRunning?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    private void Start()
    {
        
    }

    public void HandleRun()
    {

    }
}
