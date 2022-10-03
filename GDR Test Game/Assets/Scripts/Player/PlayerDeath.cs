using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerDeath : MonoBehaviour, IResetable
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

    }
    public void Reset()
    {
        transform.gameObject.SetActive(true);
        transform.position = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Spike>())
        {

            StartCoroutine(Die());
        }
    }


    private IEnumerator Die()
    {
        _animator.CrossFade("Player Death", 0);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        transform.gameObject.SetActive(false);
        transform.position = Vector2.zero;
        GameEventManager.OnPlayerDied();
        _animator.CrossFade("Player Idle", 0f);

        yield return null;
    }

    private IEnumerator WaitForAnimation(Animation animation)
    {
        do
        {
            yield return null;
        } while (animation.isPlaying);
    }
}
