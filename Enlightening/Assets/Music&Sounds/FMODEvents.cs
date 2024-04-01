using UnityEngine;
using FMODUnity;
public class FMODEvents : MonoBehaviour
{
    public static FMODEvents Instance { get; private set; }
    [field: Header("UI SFX")]
    [field: SerializeField] public EventReference equiptionSound { get; private set; }

    [field: Header("Creatures SFX")]
    [field: SerializeField] public EventReference spawnerIdle { get; private set; }
    [field: SerializeField] public EventReference enemyDeath { get; private set; }


    [field: Header("Ambience")]
    [field: SerializeField] public EventReference ambient { get; private set; }

    [field: Header("Music")]
    [field: SerializeField] public EventReference music { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        // if (Instance != null)
        // {
        //     Debug.LogError("More than one FMOD Events in the scene");
        // }
        // Instance = this;
    }

}
