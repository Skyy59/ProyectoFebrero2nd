using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public Transform startPoint;
    public Transform[] path;

    private void Awake()
    {
        Instance = this;
    }


}
