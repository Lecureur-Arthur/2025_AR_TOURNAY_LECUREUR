using UnityEngine;

public class DiceDataManager : MonoBehaviour
{
    public static DiceDataManager Instance;

    public int nbMob; // Cette variable stockera le résultat du dé

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ce GameObject persistera entre les scènes
        }
        else
        {
            Destroy(gameObject); // Évite les doublons
        }
    }
}
