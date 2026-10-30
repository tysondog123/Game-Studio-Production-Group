using Ink.UnityIntegration;
using UnityEngine;

public class TempNPC : MonoBehaviour
{
    [SerializeField]
    InkFile StandardDialog;
   public InkFile GetInkFile()
   {
        return StandardDialog;
   }
}
