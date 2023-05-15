using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfPlant : MonoBehaviour
{
    public enum PlantType { Blue, White, Red };

    public PlantType type;

    public enum WhoHasit { None, Player1, Player2 };

    public WhoHasit hasIt = WhoHasit.None;

}
