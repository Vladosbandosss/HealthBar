using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private float _fill;

    private float _startFill;
    private float _changeHealth; 

    private  void Start()
    {
        _startFill = 1f;
        _fill = 1f;
        _bar.fillAmount = _fill;
        _changeHealth = 0.1f;
    }

    private  void Update()
    {
         MoveBar();
    }

    private void MoveBar()
    {

        if (Input.GetMouseButtonDown(0))
        {

          StartCoroutine(nameof(LowHealth));

        }

        if (Input.GetMouseButtonDown(1))
        {

          StartCoroutine(nameof(UpHealth));

        }

    }

   private IEnumerator LowHealth()
   {

      if (_fill <= 0)
      {
       
       StopAllCoroutines();

      }
       
        for (int i = 0; i < int.MaxValue; i++)
        {

          _fill -= _changeHealth * Time.deltaTime;
          _bar.fillAmount = _fill;

          yield return _changeHealth;

          if (_fill + _changeHealth <= _startFill)
          {

           _startFill -= _changeHealth;

            StopAllCoroutines();

          }

        }
   }

  private  IEnumerator UpHealth()
  {
        if (_fill >= 1)
        {

            StopAllCoroutines();

        }

        for (int i = 0; i < int.MaxValue; i++)
        {
            _fill += _changeHealth * Time.deltaTime;
            _bar.fillAmount = _fill;

            yield return _changeHealth;

            if (_fill - _changeHealth >= _startFill)
            {
                _startFill += _changeHealth;

                StopAllCoroutines();
            }
        }

        yield return null;
    }
}
