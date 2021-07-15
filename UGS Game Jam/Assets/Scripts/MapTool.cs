using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTool
{
    

    
    
    

    

    


    //snap portion
    public void CreateHighlight()
    {

        //Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo);
        //Vector3 place = hitinfo.point;
        GetNearestGridPos();

       

    }

    private void SnapSelection()
    {
            //obj.transform.position = obj.GetPosition().Round(_gridSize);
            //if onkey, place
            //if offkey, remove
    }
    //To create blocks
    

   



    //snapping of ghost
    private void GetNearestGridPos()
    {
        throw new NotImplementedException();
    }
}

