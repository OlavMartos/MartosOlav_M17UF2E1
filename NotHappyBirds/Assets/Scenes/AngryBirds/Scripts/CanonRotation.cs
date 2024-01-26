using UnityEngine;

public class CanonRotation : MonoBehaviour
{
    public Vector3 _maxRotation;
    public Vector3 _minRotation;
    private float offset = /*-51.6f*/-60f;
    public GameObject ShootPoint;
    public GameObject Bullet;
    public float ProjectileSpeed = 0;
    public float MaxSpeed;
    public float MinSpeed;
    public GameObject PotencyBar;
    private float initialScaleX;

    private void Awake()
    {
        initialScaleX = PotencyBar.transform.localScale.x;
    }
    void Update()
    {
        var mousePos = Input.mousePosition;                                                                                 //guardem posici� de la c�mera
        var dist = mousePos - Bullet.transform.position;                                                                    //dist�ncia entre el click i la bala
        var ang = (Mathf.Atan2(dist.y, dist.x) * 180f / Mathf.PI + offset);
        transform.rotation = Quaternion.Euler(0, 0, ang);                                                                   //angle que s'ha de rotar

        if (Input.GetMouseButton(0))
        {
            ProjectileSpeed += 0.004f;                                                                                      //cada frame s'ha de fer 4 cops m�s gran
        }
        if (Input.GetMouseButtonUp(0))
        {
            var projectile = Instantiate(Bullet, transform.position, Quaternion.identity);                                  //On s'instancia?
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(ProjectileSpeed-0.5f, ProjectileSpeed-0.5f);                //quina velocitat ha de tenir la bala? s'ha de fer alguna cosa al vector direcci�?
            ProjectileSpeed = 0f;
        }
        CalculateBarScale();

    }
    public void CalculateBarScale()
    {
        PotencyBar.transform.localScale = new Vector3(Mathf.Lerp(0, initialScaleX, ProjectileSpeed / MaxSpeed),
            transform.localScale.y,
            transform.localScale.z);
    }
}
