using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatnipControl : MonoBehaviour, ICatnipInter
{
    
    public int Catnip { get => _catnip; set => _catnip = value; }

    public int _catnip = 0;
}
