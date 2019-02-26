using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private float DurationScaleUp = 0.02f;
    [SerializeField] private float DurationScaleDown = 0.03f;
    [SerializeField] float playerJumpSpeed = .14f;
    [SerializeField] float playerStrechOffset = 0.9f;

    public AudioSource playerSound;
    public Splash splashCall;
    // Start is called before the first frame update
    void Start()
    {


        Vector3 upDirection = Vector3.up;

        transform.DOLocalMoveY(1, playerJumpSpeed).SetLoops(-1, LoopType.Yoyo);
        transform.DOBlendableLocalMoveBy(new Vector3(.2f, 0, 0), playerJumpSpeed * 2).SetLoops(-1, LoopType.Yoyo);



        float startDelay = playerJumpSpeed * 2;
        InvokeRepeating("Strech", startDelay * playerStrechOffset, startDelay);

    }

    public void Strech()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOScale(new Vector3(1.1f, .7f, 1.1f), DurationScaleDown));
        s.Insert(DurationScaleDown, transform.DOScale(new Vector3(1, 1f, 1), DurationScaleUp));
        SoundandSplash();

    }
    public void SoundandSplash()
    {
        playerSound.Play();
        splashCall.InstantiateSplash();
    }

}
