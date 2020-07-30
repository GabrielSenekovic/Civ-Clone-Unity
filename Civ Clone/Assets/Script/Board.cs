using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject tile;
    public Vector2Int boardDimensions;
    void Start()
    {
        float percentageAltitudeOfOneRow = 1.0f / boardDimensions.y;
        for(int i = 0; i < boardDimensions.x * boardDimensions.y; i++)
        {
            int row = i / boardDimensions.x;
            int column = i % boardDimensions.x;
            float currentPercentage = percentageAltitudeOfOneRow * row;

            float colorModifier = currentPercentage > 0.5f ? //if current percentage is more than 50%
                currentPercentage - (currentPercentage - 0.5f) * 2 : //then this is the modifier
                currentPercentage; //otherwise it is this

            GameObject temp = Instantiate(tile, new Vector2(column, row)*2, Quaternion.identity); //Create and put down the tile

            temp.GetComponentInChildren<SpriteRenderer>().color = new Color(2 * colorModifier, 2 * colorModifier, 2 * colorModifier, 1); //Change the color of the tile
        }
    }
}
