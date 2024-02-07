using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Mirror;
public class Bridge_Behaviour : NetworkBehaviour
{
    [SerializeField] private Renderer thisRender;
    [SerializeField] private BoxCollider thisCollider;
    [SerializeField] private AudioSource thisAudio;
    [SerializeField] private AudioClip disableAudio;

    [ContextMenu("TestBridge"),ClientRpc]
    public void DisableBridge()
    {
        StartCoroutine("TweenBridge");
    }

    private IEnumerator TweenBridge()
    {
        thisAudio.Play();
        for(int i = 0; i < 3;i++)
        {
            Tween colorTween = thisRender.material.DOColor(Color.red,0.2f);
            yield return colorTween.WaitForCompletion();
            colorTween = thisRender.material.DOColor(Color.yellow,0.2f);
            yield return colorTween.WaitForCompletion();
        }
        thisCollider.enabled = false;
        thisRender.material.color = Color.red;
        thisAudio.PlayOneShot(disableAudio);

        yield return new WaitForSeconds(1);
        thisCollider.enabled = true;
        thisRender.material.color = Color.yellow;
    }
}
