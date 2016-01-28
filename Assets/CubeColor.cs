using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeColor : MonoBehaviour
{
    /*
        
        
        
    */
    public int selectedCube = -1;
    private int dayoftheweek;

    // Use this for initialization
    private void Start() {

    }

    // Update is called once per frame
    private void Update()
    {
        ColorData cols = new ColorData();

        //Searches for all cubes tagged with "cube" and adds them to an array
        //The array will be used to go through all the cubes in the scene
        GameObject [] allCubes;
        allCubes = GameObject.FindGameObjectsWithTag("cube");

        for (int i = 0; allCubes.Length > i ; i++) {
            GameObject o = GameObject.Find("Cube" + i);
            if (allCubes[1] == o )
            {
                o.GetComponent<Renderer>().material.color = cols.GetAColorToUse(i);
                Debug.Log(o);
            }
        }

        if (Input.GetButtonDown("Jump"))
            set_scale_of_cubes();
    }


    //the comparison needs to be changed to be checked against length of allCubes array
    private void set_scale_of_cubes()
    {
        GameObject o;
        
        if (selectedCube > -1 && selectedCube < 5)
        {
          
            o = GameObject.Find("Cube" + selectedCube);
            o.transform.localScale = new Vector3(1, 1, 1);

        }

        if (selectedCube < 5)
        {
            selectedCube++;
        }
        else selectedCube = 0;

        o = GameObject.Find("Cube" + selectedCube);
      
        o.transform.localScale = new Vector3(1, 2, 1);
       
        Debug.Log(o);
    }

    public float yOfCube(int cubeNumber)
    {
        GameObject ob = GameObject.Find("Cube" + selectedCube);
        return ob.transform.localScale.y;
    }
}

public class ColorData
{
    public Color GetAColorToUse(int indexOfTheColorToGet) {
        List<Color> color_list = new List<Color>();
        color_list.Add(new Color(1, 0, 0));
        color_list.Add(new Color(.7f, .7f, 0));
        color_list.Add(new Color(0, 1, 0));
        color_list.Add(new Color(0, .3f, 1));
        color_list.Add(new Color(0, 1, 1));
        return color_list[indexOfTheColorToGet];
    }
}

public class CubeData
{
    // When we find a cube, we should put its data in here for tidier access
}
