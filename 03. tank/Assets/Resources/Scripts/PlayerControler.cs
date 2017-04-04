using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControler : MonoBehaviour
{

    [SerializeField]
    private float mSpeed = (float)3;
    [SerializeField]
    private float rSpeed = (float)30;

    [SerializeField]
    private float turboMultiple = (float)6;
    [SerializeField]
    private float backMultiple = (float)1;

    private float mCurrSpeed = 0;

    private float h, v = 0;

    [SerializeField]
    private GameObject gTurboFire;
    [SerializeField]
    private ParticleSystem pTurboFire;

    private ParticleSystem.EmissionModule turboFireEmiss;

    [SerializeField]
    private ParticleSystem idleDust;
    [SerializeField]
    private ParticleSystem moveDust_R;
    [SerializeField]
    private ParticleSystem moveDust_L;

    private ParticleSystem.EmissionModule idleEmiss;
    private ParticleSystem.EmissionModule moveDustREmiss;
    private ParticleSystem.EmissionModule moveDustLEmiss;

    [SerializeField]
    private Transform firePos;
    [SerializeField]
    private Rigidbody Bullet;
    private Rigidbody cloneBullet;
    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private Transform turretTransform;
    [SerializeField]
    private float turretRSpeed;

    private float angleY;
    [SerializeField]
    private float minAngleY;
    [SerializeField]
    private float maxAngleY;

    [SerializeField]
    private Transform tubeTransform;
    [SerializeField]
    private float tubeRSpeed;

    private float angleX;
    [SerializeField]
    private float minAngleX;
    [SerializeField]
    private float maxAngleX;

    [SerializeField]
    private float cdTime = 2f;
    private float curTime = 0;

    [SerializeField]
    private Image FireCDImage;

    [SerializeField]
    private AudioClip fireSound;

    [SerializeField]
    private float maxHP = 100f;
    private float curHP;
    [SerializeField]
    private float reHP = 3f;

    [SerializeField]
    private Image HPImage;

    [SerializeField]
    private float maxMP = 100f;
    [SerializeField]
    private float curMP;
    [SerializeField]
    private float costMP = 15f;
    [SerializeField]
    private float reMP = 5f;

    [SerializeField]
    private Image MPImage;

    [SerializeField]
    private GameObject tankBroke;

    void Awake()
    {
        if (gTurboFire == null)
        {
            gTurboFire = GameObject.FindWithTag("turboFire");
        }
        idleEmiss = idleDust.emission;
        moveDustREmiss = moveDust_R.emission;
        moveDustLEmiss = moveDust_L.emission;
        curHP = maxHP;
        curMP = maxMP;
    }

    // Use this for initialization
    void Start()
    {
        idleEmiss.rate = new ParticleSystem.MinMaxCurve((float)10);
        moveDustREmiss.rate = new ParticleSystem.MinMaxCurve((float)0);
        moveDustLEmiss.rate = new ParticleSystem.MinMaxCurve((float)0);
    }

    void FixedUpdate()
    {
        if (curTime > 0f)
        {
            curTime -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Translate(new Vector3(0.0f, -9.8f, 0.0f));
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        PlayerMove();
        DustController();
        Fire();
        TurretController();
        TubeController();
        FireCDImage.fillAmount = curTime / cdTime;
        HPImage.fillAmount = curHP / maxHP;
        MPImage.fillAmount = curMP / maxMP;

        if (curHP != maxHP)
        {
            curHP += reHP * Time.deltaTime;
        }
        if (curHP >= maxHP)
        {
            curHP = maxHP;
        }
        if (curHP <= maxHP)
        {
            die();
        }

        if (curMP != maxMP)
        {
            curMP += reMP * Time.deltaTime;
        }
        if (curMP >= maxMP)
        {
            curMP = maxMP;
        }

    }

    void die()
    {
        if (curHP <= 0f)
        {
            GameObject clone = (GameObject)Instantiate(tankBroke, this.transform.position, this.transform.rotation);
            Camera.main.transform.parent = null;
            Destroy(this.gameObject);
        }
    }

    void PlayerMove()
    {
        this.transform.Translate(0, 0, v * Time.deltaTime * mCurrSpeed);
        this.transform.Rotate(0, h * Time.deltaTime * rSpeed, 0);

        //Debug.Log(v);

        if (v > 0 && Input.GetButton("Turbo"))
        {
            mCurrSpeed = mSpeed * turboMultiple;
            gTurboFire.SetActive(true);


        }
        else if (v <= 0)
        {
            mCurrSpeed = mSpeed * backMultiple;
            gTurboFire.SetActive(false);
        }
        else
        {
            mCurrSpeed = mSpeed;
            gTurboFire.SetActive(false);
        }
    }

    void DustController()
    {
        if (v != 0 || h != 0)
        {
            idleEmiss.rate = new ParticleSystem.MinMaxCurve((float)0);
            moveDustREmiss.rate = new ParticleSystem.MinMaxCurve((float)10);
            moveDustLEmiss.rate = new ParticleSystem.MinMaxCurve((float)10);
        }
        else
        {
            idleEmiss.rate = new ParticleSystem.MinMaxCurve((float)10);
            moveDustREmiss.rate = new ParticleSystem.MinMaxCurve((float)0);
            moveDustLEmiss.rate = new ParticleSystem.MinMaxCurve((float)0);
        }
    }

    void Fire()
    {
        if (Input.GetButtonDown("Fire1") && curTime <= 0f && curMP >= costMP)
        {
            cloneBullet = (Rigidbody)Instantiate(Bullet, firePos.position, firePos.rotation);
            cloneBullet.velocity = firePos.TransformDirection(new Vector3(0, 0, bulletSpeed));
            //Debug.Log("Fire");
            GetComponent<AudioSource>().PlayOneShot(fireSound);
            curMP -= costMP;
            curTime = cdTime;
        }
    }

    void TubeController()
    {
        float mouseScrollWhell = Input.GetAxis("Mouse ScrollWheel") * tubeRSpeed * Time.deltaTime;
        //Debug.Log (mouseScrollWhell);
        angleX -= mouseScrollWhell;
        Vector3 newRot = turretTransform.localEulerAngles;
        newRot.x = Mathf.Clamp(angleX, minAngleX, maxAngleX);
        angleX = newRot.x;
        turretTransform.localEulerAngles = newRot;
    }

    void TurretController()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * turretRSpeed * Time.deltaTime;
            angleY += mouseX;
            Vector3 newRot = turretTransform.localEulerAngles;
            newRot.y = Mathf.Clamp(angleY, minAngleY, maxAngleY);
            angleY = newRot.y;
            turretTransform.localEulerAngles = newRot;
        }
    }

    void ApplyDamage(float damage)
    {
        curHP -= damage;
        //Debug.Log(damage);
    }

}
