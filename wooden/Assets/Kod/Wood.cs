using UnityEngine ;
using DG.Tweening ;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wood : MonoBehaviour {
   [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer ;
   [SerializeField] private Transform woodTransform ;
    [SerializeField] private SkinnedMeshRenderer skinnMeshRenderer;
    [SerializeField] private Vector3 rotationVector ;
    [SerializeField] private float rotationDuration ;
    [SerializeField] private GameObject bos;
    [SerializeField] private GameObject bir;
    [SerializeField] private GameObject iki;
    [SerializeField] private GameObject uc;
    [SerializeField] private GameObject Next;
    float top;
    float a;
    

    private void Start () {
        woodTransform
           .DOLocalRotate(rotationVector, rotationDuration, RotateMode.FastBeyond360)
           .SetLoops(-1, LoopType.Restart)
           .SetEase(Ease.Linear);
        bos.SetActive(true);
        PlayerPrefs.SetString("bolum", SceneManager.GetActiveScene().name);
    }

    public void Hit (int keyIndex, float damage) {
      float colliderHeight = 2.39705f ;
      //Skinned mesh renderer key's value is clamped between 0 & 100
      float newWeight = skinnedMeshRenderer.GetBlendShapeWeight (keyIndex) + damage * (100f / colliderHeight) ;
      skinnedMeshRenderer.SetBlendShapeWeight (keyIndex, newWeight);
        if (skinnMeshRenderer.GetBlendShapeWeight(keyIndex) - skinnedMeshRenderer.GetBlendShapeWeight(keyIndex) <= -30) SceneManager.LoadScene("GameOver");
        for (int i = 0; i < 19; i++)
        {
            a = skinnMeshRenderer.GetBlendShapeWeight(i) - skinnedMeshRenderer.GetBlendShapeWeight(i);
            
            top += a;
        }
        if(top <= -50) SceneManager.LoadScene("GameOver");
        if (top <= 200) 
        {
            bos.SetActive(false);
            bir.SetActive(true);
            iki.SetActive(false);
            uc.SetActive(false);

        }
        if (top <= 100)
        {
            bos.SetActive(false);
            bir.SetActive(false);
            iki.SetActive(true);
            uc.SetActive(false);

        }
        if (top <= 0)
        {
            bos.SetActive(false);
            bir.SetActive(false);
            iki.SetActive(false);
            uc.SetActive(true);
            Next.SetActive(true);

        }
        
        top = 0;



    }

}
