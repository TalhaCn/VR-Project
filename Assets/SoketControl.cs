using UnityEngine;
using UnityEngine.UI;

public class SoketKontrol : MonoBehaviour
{
    public Text durumText;
    public Color dogruRenk = Color.blue;
    public Color yanlisRenk = Color.red;

    private bool dogruDurum = false;
    private bool yanlisDurum = false;
    private Vector3 baslangicKonumu;

    void Start()
    {
        baslangicKonumu = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nesne"))
        {
            KontrolEt(other.gameObject);
        }
    }

    void KontrolEt(GameObject nesne)
    {
        if (nesne.CompareTag("Cube_nesne") && gameObject.CompareTag("cube_soket"))
        {
            DogruNesne();
        }
        else if (nesne.CompareTag("Capsule_nesne") && gameObject.CompareTag("capsule_socket"))
        {
            DogruNesne();
        }
        else if (nesne.CompareTag("Cylinder_nesne") && gameObject.CompareTag("cylinder_soket"))
        {
            DogruNesne();
        }
        else
        {
            YanlisNesne();
        }
    }

    void DogruNesne()
    {
        dogruDurum = true;
        yanlisDurum = false;

        durumText.text = "Doğru";
        durumText.color = dogruRenk;

        // İhtiyaçlarınıza bağlı olarak ek işlemler ekleyebilirsiniz.
    }

    void YanlisNesne()
    {
        yanlisDurum = true;
        dogruDurum = false;

        durumText.text = "Yanlış";
        durumText.color = yanlisRenk;

        // İhtiyaçlarınıza bağlı olarak ek işlemler ekleyebilirsiniz.
    }

    void Update()
    {
        if (yanlisDurum || dogruDurum)
        {
            // Eğer yanlış veya doğru durumu varsa, nesneyi başlangıç konumuna taşı.
            transform.position = baslangicKonumu;
        }
    }
}
