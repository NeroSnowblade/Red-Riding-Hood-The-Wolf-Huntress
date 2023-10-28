using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadMenuUIController : MonoBehaviour
{
   public SaveLoadDataSlot SaveLoadDataSlot;

   public GameObject txtEmpetyslot1,txtEmpetyslot2,txtEmpetyslot3,txtEmpetyslot4;
   public GameObject notEmpety1,notEmpety2,notEmpety3,notEmpety4;
   public TMP_Text txtRegionNotEmpety1,txtRegionNotEmpety2,txtRegionNotEmpety3,txtRegionNotEmpety4;
   public TMP_Text txtStageNotEmpety1,txtStageNotEmpety2,txtStageNotEmpety3,txtStageNotEmpety4;

   private void Start() 
   {
      SaveLoadDataSlot.InitializedDataSlot();
      SetTextSlot();
      SetNotEmpetyTxt();
   }
   public void SetTextSlot()
   {
         txtEmpetyslot1.SetActive(SaveLoadDataSlot.DataSlot.DataSlot[0].isEmpety);
         notEmpety1.SetActive(!SaveLoadDataSlot.DataSlot.DataSlot[0].isEmpety);
         txtEmpetyslot2.SetActive(SaveLoadDataSlot.DataSlot.DataSlot[1].isEmpety);
         notEmpety2.SetActive(!SaveLoadDataSlot.DataSlot.DataSlot[1].isEmpety);
         txtEmpetyslot3.SetActive(SaveLoadDataSlot.DataSlot.DataSlot[2].isEmpety);
         notEmpety3.SetActive(!SaveLoadDataSlot.DataSlot.DataSlot[2].isEmpety);
         txtEmpetyslot4.SetActive(SaveLoadDataSlot.DataSlot.DataSlot[3].isEmpety);
         notEmpety4.SetActive(!SaveLoadDataSlot.DataSlot.DataSlot[3].isEmpety);
   }

   public void SetNotEmpetyTxt(){
      txtRegionNotEmpety1.text = "Region " + SaveLoadDataSlot.DataSlot.DataSlot[0].unlockLvRegion.ToString();
      txtRegionNotEmpety2.text = "Region " + SaveLoadDataSlot.DataSlot.DataSlot[1].unlockLvRegion.ToString();
      txtRegionNotEmpety3.text = "Region " + SaveLoadDataSlot.DataSlot.DataSlot[2].unlockLvRegion.ToString();
      txtRegionNotEmpety4.text = "Region " + SaveLoadDataSlot.DataSlot.DataSlot[3].unlockLvRegion.ToString();

      txtStageNotEmpety1.text = "Stage " + SaveLoadDataSlot.DataSlot.DataSlot[0].unlockStage.ToString();
      txtStageNotEmpety2.text = "Stage " + SaveLoadDataSlot.DataSlot.DataSlot[1].unlockStage.ToString();
      txtStageNotEmpety3.text = "Stage " + SaveLoadDataSlot.DataSlot.DataSlot[2].unlockStage.ToString();
      txtStageNotEmpety4.text = "Stage " + SaveLoadDataSlot.DataSlot.DataSlot[3].unlockStage.ToString();
   }
}
