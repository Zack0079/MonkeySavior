using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DropDownScript : MonoBehaviour
{

  private MainManager mainManager;

  void Start()
  {
    mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    if(mainManager != null){
      GetComponent<TMPro.TMP_Dropdown>().value = mainManager.difficulty-1;
    }
  }


  public void DropDownList(int index)
  {
    switch (index)
    {
      case 0:
        mainManager.difficulty = 1;
        break;

      case 1:
        mainManager.difficulty = 2;
        break;

      case 2:
        mainManager.difficulty = 3;
        break;

    }
  }
}
