using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    //accesor arco
    static public BowController BowInstance;
    [SerializeField]
    private float _atackS;
    private float _atCD = 0;
    private bool _canStillShoot = true;
    [SerializeField]
    private float _PredictionCoef;   
    private float _force = 0;

    [SerializeField]
    private GameObject bowRENDER;


    private GameObject _arrow;

    [SerializeField]
    public GameObject _arrowTP;

    [SerializeField]
    public GameObject _arrowDamage;

    private int multiplier=1;

    [SerializeField]
    private GameObject _point;

    private GameObject[] Points;

    [SerializeField]
    private int _numPoints;

    [SerializeField]
    private GameObject ShotPoint;

    [SerializeField]
    private GameObject pointorigin;
    void Start()
    {
        Points = new GameObject[_numPoints];
        for (int i = 0; i < _numPoints; i++)
        {
            Points[i] = Instantiate(_point, transform.position, Quaternion.identity);
        }
        _arrow = _arrowTP;
        BowInstance = this;
    }

    public bool MaxForce = false;
    // Update is called once per frame
    void Update()
    {
        Vector2 bPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Dir = mousePos - bPos;
        transform.up = Dir;
        
        if (Input.GetMouseButton(0) && _atCD <= 1.5f && _canStillShoot)
        {
            _point.SetActive(true);
            _atCD += Time.deltaTime * _atackS;
            _force += Mathf.Pow(Time.deltaTime * _atackS*100, 2);
            BowANIM.isBow = true;
            for (int i = 0; i < _numPoints; i++)
            {
                Points[i].SetActive(true);
                Points[i].transform.position = PointPosition(0.1f * i, Dir, _force, ShotPoint.transform.position);
            }
            Time.timeScale = 0.5f;
        }
        
        else if (_atCD >=1.5f && Input.GetMouseButton(0))
        {
            MaxForce = true;
            for (int i = 0; i < _numPoints; i++)
            {
                Points[i].transform.position = PointPosition(0.1f * i, Dir, _force, ShotPoint.transform.position);
            }
            Time.timeScale = 0.5f;
        }
        else if (!Input.GetMouseButton(0))
        {
            if(_atCD > 0) Shoot(Dir, _force);
            for (int i = 0; i < _numPoints; i++)
            {
                Points[i].SetActive(false);
            }
            BowANIM.isBow = false;
            Time.timeScale = 1;
            MaxForce = false;
            _canStillShoot = true;
            _atCD = 0;
        }
    }
    public void CambioDeFlecha()
    {
        if(_arrow == _arrowTP)
        {
            _arrow = _arrowDamage;
            _PredictionCoef = 0f;
            multiplier = _arrowDamage.GetComponent<Arrow2>().multiplier;
        }
        else
        {
            _arrow = _arrowTP;
            _PredictionCoef = 0.5f;
            multiplier = _arrowTP.GetComponent<Arrow>().multiplier;
        }
    }
    public void CancelacionDisparo()
    {
        FinDisparo();
        _canStillShoot = false;
    }
    private void FinDisparo()
    {
        Time.timeScale = 1f;
        _atCD = 0;
        _force = 0;
        BowANIM.isBow = false;
        for (int i = 0; i < _numPoints; i++)
        {
            Destroy(Points[i]);
        }
        for (int i = 0; i < _numPoints; i++)
        {
            Points[i] = Instantiate(_point, transform.position, Quaternion.identity);
        }
    }
    private void Shoot(in Vector2 Dir, float force)
    {
        if (shotPointDetector.canShootArrow)
        {
            GameObject newArrow = Instantiate(_arrow, ShotPoint.transform.position, ShotPoint.transform.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity =multiplier* _force * Dir.normalized;
        }
        FinDisparo();
        
    }
   
    private Vector2 PointPosition(float t, Vector2 Direction, float force, Vector2 bPos)
    {
        Vector2 currentPosition = bPos + (Direction.normalized * force * t) + _PredictionCoef * Physics2D.gravity * (t * t);
        return currentPosition;
    }
}
