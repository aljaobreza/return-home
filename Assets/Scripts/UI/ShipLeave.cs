using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipLeave : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        anim.SetTrigger("leave");
    }
}
