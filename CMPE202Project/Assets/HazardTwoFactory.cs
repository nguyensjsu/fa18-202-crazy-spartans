using UnityEngine;

public class HazardTwoFactory : HazardFactory
{
    public static GameObject hazard;

    public void setHazard(GameObject inputHazard)
    {
        hazard = inputHazard;
    }


    public GameObject createHazard()
   
    {
        return hazard;
    }

}