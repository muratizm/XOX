using UnityEngine;
using TMPro;
public class Cannon : MonoBehaviour
{
    [SerializeField] private Projection _projection;
    private RemaningThrowBar remaningThrowBar;
    private Joystick joystick;

    private float horizontalAngle = 20f;
    private float verticalAngle = 45f;
    private bool activeChanging = false;
    private float startHorizontalDirection;
    private float startVerticalDirection;
    private LineRenderer lineRenderer;

    public int throwCounter;
    [SerializeField] float maxThrow = 4;

    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private float _force = 20;
    private float newForce; // sapan gerilince force artacak - newForce sapan gerilirken oluþan sapandaki yeni gücü temsil ediyor sapan býrakýldýðýnda tekrardan eski haline dönecek
    [SerializeField] private Transform _ballSpawn;
    [SerializeField] private Transform _barrelPivot;
    [SerializeField] private float _rotateSpeed = 30;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private ParticleSystem _launchParticles;

    private void Awake()
    {
        remaningThrowBar = FindObjectOfType<RemaningThrowBar>();
        remaningThrowBar.setMaxThrow(maxThrow);
    }
    private void Start()
    {
        joystick = FindObjectOfType<FloatingJoystick>();
        lineRenderer = GetComponent<LineRenderer>();
        startHorizontalDirection = transform.eulerAngles.y;
        startVerticalDirection = transform.eulerAngles.x;
        newForce = _force;
    }

    private void Update()
    {

        if (remaningThrowBar.currentThrow > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                activeChanging = true;
                lineRenderer.enabled = true; // sadece atýþ yaparken projection gözüksün diye aç kapat yapýyorum 


            }
            if (Input.GetMouseButtonUp(0))
            {
                activeChanging = false;
                lineRenderer.enabled = false; // sadece atýþ yaparken projection gözüksün diye aç kapat yapýyorum 
                var spawned = Instantiate(_ballPrefab, _ballSpawn.position, _ballSpawn.rotation);

                spawned.Init(_ballSpawn.forward * newForce, false);
                _launchParticles.Play();
                _source.PlayOneShot(_clip);

                // burdan sonrasý atýþ yapýldýktan sonra yapýalcaklar
                throwCounter++;
                remaningThrowBar.ChangerRemainingThrowBar();
                transform.eulerAngles = new Vector3(startVerticalDirection, startHorizontalDirection, transform.eulerAngles.z); // atýþ yapýldýktan sonra sapanýn yönünü yine default haline çeviriyoruz
                newForce = _force; // atýþ yapýldýktan sonra sapanýn gücünü default haline getiriyoruz (sapan ne kadar uzun çekilirse gücü o kadar artýyor onu düzeltiyoruz yani)

            }

            if (activeChanging)
            {
                //if (0 < tensionTimer && tensionTimer < .25) newForce = _force + 5f;
                //else if (.25 < tensionTimer && tensionTimer < .5) newForce = _force + 10f;
                //else if (.5 < tensionTimer && tensionTimer < .75) newForce = _force + 20f;
                //else if (.75 < tensionTimer && tensionTimer < 1) newForce = _force + 25f;
                //else if (1 < tensionTimer && tensionTimer < 1.25) newForce = _force + 30f;

                float horizontalChangeValue = joystick.Horizontal * horizontalAngle;
                //float verticalChangeValue = 0;
                //if (joystick.Vertical < 0)
                //{
                //    verticalChangeValue = -joystick.Vertical * verticalAngle;
                //}

                newForce = (-joystick.Vertical * 10f) + _force;
                if (joystick.Vertical > 0.15) // yani sapan kontrolü yukarý kaldýrýldýðýnda
                {
                    newForce = (joystick.Vertical * 10f) + _force;
                    transform.eulerAngles = new Vector3(40f, startHorizontalDirection - horizontalChangeValue, transform.eulerAngles.z);
                }
                else if (joystick.Vertical < 0.15)
                {
                    newForce = (-joystick.Vertical * 30f) + _force;
                    transform.eulerAngles = new Vector3(startVerticalDirection, startHorizontalDirection - horizontalChangeValue, transform.eulerAngles.z);
                }

                _projection.SimulateTrajectory(_ballPrefab, _ballSpawn.position, _ballSpawn.forward * newForce); // bu projection'u buraya koydum çünkü sadece sapaný çekerken güncellenmesini istiyorum
            }

        }
        else
        {
            Invoke("NoAmmo", 4f);

        }


    }

    private void NoAmmo()
    {
        FindObjectOfType<GameManager>().FinishLevel(false);
    }

}


