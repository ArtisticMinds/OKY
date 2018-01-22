using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    AudioSource audioSource;
    public bool shaketrue = false;

    public Vector3 originalPos;
    float originalShakeDuration;
    Vector3 NewPosition;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
        audioSource = GetComponent(typeof(AudioSource)) as AudioSource;
    }

    void Start()
    {
       originalPos = new Vector3(camTransform.localPosition.x, camTransform.localPosition.y, PlayerPrefs.GetFloat(GameManager.Instance.AppName + "_CameraDistance"));
        //originalPos = camTransform.localPosition;
        originalShakeDuration = shakeDuration;
        shaketrue = false;
        
    }

    void Update()
    {
      //  if (shaketrue)
            if (shaketrue&&shakeDuration > 0)
            {

                camTransform.localPosition = Vector3.Lerp(camTransform.localPosition,originalPos + Random.insideUnitSphere * shakeAmount,Time.deltaTime * 1.5f);

                shakeDuration -= Time.deltaTime * decreaseFactor * GameManager.TimeMultipler;
            }
            else
            {

                shakeDuration = originalShakeDuration;
                camTransform.localPosition = Vector3.Lerp(camTransform.localPosition, originalPos, Time.deltaTime * 0.8f * GameManager.TimeMultipler);
                shaketrue = false;
            }
        

    }

    public void shakecamera()
    {
        shaketrue = true;
    }

    public void shakecamera(float _shakeDuration, float _shakeAmount, float _decreaseFactor)
    {
        if (shaketrue) return;
       if(_shakeDuration>1) audioSource.Play();
        shaketrue = true;
        shakeDuration = _shakeDuration;
        shakeAmount = _shakeAmount;
        decreaseFactor = _decreaseFactor;
    }
}