using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PopUpMenus : MonoBehaviour
{
    public GameObject popupMenu; // ������ �� ����������� ����
    [SerializeField] private new Camera camera;
    void Update()
    {
        //// ���������, ���� �� ������ ����� ������ ����
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // ������� ��� �� ������� ����
        //    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    // ���������, ����� �� ��� � ��� ������
        //    if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        //    {
        //        // ���� ��, ���������� ����������� ����
        //        ShowPopupMenu();
        //    }
        //    else
        //    {
        //        // ���� ��� �� ����� � ������, �������� ����
        //        HidePopupMenu();
        //    }
        //}

    }


    void ShowPopupMenu()
    {
        // ���������� ����������� ����
        popupMenu.SetActive(true);
    }

    void HidePopupMenu()
    {
        // �������� ����������� ����
        popupMenu.SetActive(false);
    }

    void Start()
    {
    }
}