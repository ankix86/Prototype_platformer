using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randongenration : MonoBehaviour
{
    Vector2 worldSize = new Vector2(4, 4);
    Room[,] rooms;

    List<Vector2> takenPosition = new List<Vector2>();
    public int gridSizeX, gridSizeY, numberOfRooms = 10;

    public GameObject roomObject; 
    
    void Start()
    {
        if(numberOfRooms >= (worldSize.x * 2) * (worldSize.y * 2))
        {
            numberOfRooms = Mathf.RoundToInt((worldSize.x * 2) * (worldSize.y * 2));
        }
        gridSizeX = Mathf.RoundToInt(worldSize.x);
        gridSizeY = Mathf.RoundToInt(worldSize.y);

        Debug.Log("Y :" + gridSizeY + "X:" + gridSizeX + "Number of Room: " + numberOfRooms); ;
    }

    void createRoom()
    {
        rooms = new Room[gridSizeX * 2, gridSizeY * 2];
        rooms[gridSizeX, gridSizeY] = new Room(1, Vector2.zero);
        takenPosition.Insert(0, Vector2.zero);
        Vector2 checkPos = Vector2.zero;

        float randomCampare = 0.2f,randomCampStart = 0.2f,randomCampEnd = 0.01f;
        
        for(int i = 0;i < numberOfRooms - 1; i++)
        {
            float randomPerc = (float)i / (((float)numberOfRooms - 1));
            randomCampare = Mathf.Lerp(randomCampStart, randomCampEnd, randomPerc);

            if (numberOfNeigbors(checkPos, takenPosition) > 1 && Random.value > randomPerc)
            {
                int iev = 0;
                do
                {
                    checkPos = SelectiveNewPoistion();
                    iev++;
                }
                while (numberOfNeigbors(checkPos, takenPosition) > 1 && iev > 100);
                if (iev > 50)
                {
                    print("error:");
                }
            }
            //greb New Checkpoistion
            checkPos = newPoistion();

        }


        //finalize Position
        rooms[(int)checkPos.x + gridSizeX, (int)checkPos.y + gridSizeY] = new Room(0, checkPos);
        takenPosition.Insert(0, checkPos);
    }

    Vector2 newPoistion()
    {
        Vector2 checkingPos = Vector2.zero;
        int x = 0, y = 0;
        do
        {
            int index = Mathf.RoundToInt(Random.value * (takenPosition.Count - 1));
            x = (int)takenPosition[index].x;
            y = (int)takenPosition[index].y;

            bool upDown = (Random.value < .5f);
            bool positive = (Random.value < .5f);

            if (upDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y);
        } while (takenPosition.Contains(checkingPos) || x >= gridSizeX || x <= -gridSizeX || y >= gridSizeY || y <= -gridSizeY);
         return checkingPos;
    }

    Vector2 SelectiveNewPoistion()
    {
        int ival = 0,index;
        Vector2 checkingPos = Vector2.zero;
        int x = 0, y = 0;
        do
        {
            do
            {
                index = Mathf.RoundToInt(Random.value * (takenPosition.Count - 1));
                ival++;
            }
            while (numberOfNeigbors(takenPosition[index], takenPosition) > 1 && ival < 100);
            x = (int)takenPosition[index].x;
            y = (int)takenPosition[index].y;

            bool upDown = (Random.value < .5f);
            bool positive = (Random.value < .5f);

            if (upDown)
            {
                if (positive)
                {
                    y += 1;
                }
                else
                {
                    y -= 1;
                }
            }
            else
            {
                if (positive)
                {
                    x += 1;
                }
                else
                {
                    x -= 1;
                }
            }
            checkingPos = new Vector2(x, y);
        } while (takenPosition.Contains(checkingPos) || x >= gridSizeX || x <= -gridSizeX || y >= gridSizeY || y <= -gridSizeY);
        return checkingPos;
    }


    int numberOfNeigbors(Vector2 chekingPos,List<Vector2> usedPos)
    {
        int rec = 0;
        if(usedPos.Contains(chekingPos + Vector2.up))
        {
            rec++;
        }
        if (usedPos.Contains(chekingPos + Vector2.down))
        {
            rec++;
        }
        if (usedPos.Contains(chekingPos + Vector2.left))
        {
            rec++;
        }
        if (usedPos.Contains(chekingPos + Vector2.right))
        {
            rec++;
        }
        return rec;
    }
}
