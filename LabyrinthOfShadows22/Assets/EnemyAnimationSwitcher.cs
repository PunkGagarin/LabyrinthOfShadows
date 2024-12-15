using UnityEngine;

public class EnemyAnimationSwitcher : MonoBehaviour
{
    // [SerializeField] private GameObject visual;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        SwitchAnimationToIdle();
    }

    public void SwitchAnimationToIdle()
    {
        animator.SetBool("Move", false);
    }

    public void SwitchAnimationToRun()
    {
        animator.SetBool("Move", true);
    }
}