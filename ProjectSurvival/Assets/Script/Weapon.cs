using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject ammoPrefab;

    static List<GameObject> ammoPool;

    public int poolSize;

    public float weaponVelocity;

    private void Awake()
    {
        if (ammoPool == null)
        {
            ammoPool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject ammoObject = Instantiate(ammoPrefab);
                ammoObject.SetActive(false);
                ammoPool.Add(ammoObject);
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fireAmmo();
        }
    }

    GameObject SpawnAmmo(Vector3 location)
    {
        //�̸� �ν��Ͻ�ȭ ��Ų ������Ʈ�� Ǯ(ammoPool)�� �ݺ�
        foreach (GameObject ammo in ammoPool)
        {
            //������Ʈ�� ��Ȱ��ȭ �����ΰ�?
            if (ammo.activeSelf == false)
            {
                //�׷� Ȱ��ȭ ����
                ammo.SetActive(true);

                //��ġ�� location�̾�(�߻��Ѱ�ó�� ���̰��� ��ġ �� ĳ������ ��ġ)
                ammo.transform.position = location;

                //Ȱ��ȭ��Ų ammo ��������
                return ammo;
            }
        }
        //��Ȱ��ȭ ������Ʈ������? �׷� null ��������
        return null;
    }

    void fireAmmo()
    {
        //���콺�� ��ġ�� ������ ���콺�� ȭ������� ����ϹǷ�
        //ȭ�� ������ ���콺��ġ�� ���������ġ�� ��ȯ����
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //SpawnAmmo�� �̿��Ͽ� List�� ���� objectpool�߿� ��Ȱ��ȭ �ȳ��� ã�´�.
        //��ġ�� ĳ���Ͱ� �߻��ϴ°� ó�� ������ �ϹǷ� ĳ������ ��ġ�� �־��ش�.
        GameObject ammo = SpawnAmmo(transform.position);

        //ammo�� null�� �ƴѰ�? Ȱ��ȭ ���� ���� ������Ʈ�� �ִ°�?
        if (ammo != null)
        {
            //AmmoVector���� ������ Flyammo�� ����ϱ����� AmmoVector�� �����
            AmmoVector ammoVectorScript = ammo.GetComponent<AmmoVector>();

            //weaponVelocity�� �����Ϳ��� ���� �Է��Ѵ�.
            //travelDuration�� object�� ��ǥ�������� �����ϴ� �ð��̿���.
            //weaponVelocity�� 2.0f���� �ָ� 1.0/2.0 = 0.5�� �ǹǷ�
            //�Ѿ��� 0.5�ʸ��� ��ǥ������ �����Ѵ�.
            float travelDuration = 1.0f / weaponVelocity;

            //AmmoVector���� ���� FlyAmmo �޼��带 �����´�.
            //��ǥ������ ���콺�� ��ġ, �ӵ���...? �ð����� �־��־���. ����� �ϸ� �ϰ����� ������.
            StartCoroutine(ammoVectorScript.FlyAmmo(mousePosition, travelDuration));
        }


    }

    private void OnDestroy()
    {
        ammoPool = null;
    }
}
