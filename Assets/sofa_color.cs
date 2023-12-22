using UnityEngine;

public class sofa_color : MonoBehaviour
{
    public GameObject targetObject; // Hedef nesnenin referansı
    public Material newMaterial; // Yeni malzeme
    private Material originalMaterial; // Orijinal malzeme
    private bool isMaterialChanged = false; // Malzeme değiştirildi mi?

    void Start()
    {
        // Hedef nesnenin Renderer bileşenini al
        Renderer renderer = targetObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Orijinal malzemeyi sakla
            originalMaterial = renderer.material;
        }
        else
        {
            Debug.LogError("TargetObject üzerinde Renderer bileşeni bulunamadı!");
        }
    }

    void Update()
    {
        // VR işaretçisinin ucu üzerine ray gönder
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            // Eğer ray bir nesne ile temas ederse ve sol tıklama yapıldıysa
            if (hit.collider.gameObject == targetObject && Input.GetMouseButtonDown(0))
            {
                ChangeMaterial(); // Malzeme değiştirme fonksiyonunu çağır
            }
        }
    }

    void ChangeMaterial()
    {
        // Hedef nesnenin Renderer bileşenini al
        Renderer renderer = targetObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            // Malzemeyi değiştir veya eski haline getir
            if (isMaterialChanged)
            {
                renderer.material = originalMaterial;
                Debug.Log("Material reverted to original.");
            }
            else
            {
                renderer.material = newMaterial;
                Debug.Log("Material changed.");
            }

            // Malzeme değişim durumunu güncelle
            isMaterialChanged = !isMaterialChanged;
        }
        else
        {
            Debug.LogError("TargetObject üzerinde Renderer bileşeni bulunamadı!");
        }
    }
}
