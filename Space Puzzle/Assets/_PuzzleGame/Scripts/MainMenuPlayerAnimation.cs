using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MainMenuPlayerAnimation : MonoBehaviour
{

    [SerializeField] private float DurationScaleUp1 = 0.02f;
    [SerializeField] private float DurationScaleDown1 = 0.03f;
    [SerializeField] float playerJumpSpeed1 = .14f;
    [SerializeField] float playerStrechOffset1 = 0.9f;

    public AudioSource playerSound;
    public Splash splashCall;
    // Start is called before the first frame update
    void Start()
    {


        Vector3 upDirection = Vector3.up;

        transform.DOLocalMoveY(0.2f, playerJumpSpeed1).SetLoops(-1, LoopType.Yoyo);
        transform.DOBlendableLocalMoveBy(new Vector3(.2f, 0, 0), playerJumpSpeed1 * 2).SetLoops(-1, LoopType.Yoyo);



        float startDelay = playerJumpSpeed1 * 2;
        InvokeRepeating("Strech", startDelay * playerStrechOffset1, startDelay);

    }

    public void Strech()
    {
        Sequence s = DOTween.Sequence();
        s.Append(transform.DOScale(new Vector3(1.1f, .7f, 1.1f), DurationScaleDown1));
        s.Insert(DurationScaleDown1, transform.DOScale(new Vector3(1, 1f, 1), DurationScaleUp1));
        SoundandSplash();

    }
    public void SoundandSplash()
    {
        playerSound.Play();
        splashCall.InstantiateSplash();
    }

}


