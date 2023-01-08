using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PengkiKontol : MonoBehaviour
{
  public GameObject Pengki;
  private float kontolPengkiBelok;
  private float kontolPengkiNaikTurun;

  public float porosKontolPengki = 5.0f;
  public float kecepatanKontolPengki = 5.0f;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    kontolPengkiBelok = Input.GetAxis("Horizontal");
    kontolPengkiNaikTurun = Input.GetAxis("Vertical");

    transform.Translate(Vector3.forward * Time.deltaTime * kontolPengkiNaikTurun * kecepatanKontolPengki);
    if (kontolPengkiNaikTurun != 0)
    {
      transform.Rotate(Vector3.up * Time.deltaTime * kontolPengkiBelok * porosKontolPengki);
    }
  }
}
