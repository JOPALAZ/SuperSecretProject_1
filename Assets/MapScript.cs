using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MapScript : MonoBehaviour
{

    static public GameObject[,] sprites;

    private static void texturize(double perlinHeight, int buildingType, GameObject obj, float spriteSize)
    {
        Texture2D[] textures = GlobalVariableHandler.textures;
        obj.AddComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        if (buildingType != Convert.ToInt32(Constants.Buildings.None)) 
        {
            spriteRenderer.sprite = Sprite.Create(GlobalVariableHandler.roadTexture, new(0, 0, GlobalVariableHandler.roadTexture.width, GlobalVariableHandler.roadTexture.height), new(0.5f, 0.5f));
        }
        else
        {
            int height = Convert.ToInt32(255 * (perlinHeight + 1.0) / 2.0);
            if (height <= GlobalVariableHandler.waterline)
            {
                spriteRenderer.sprite = Sprite.Create(textures.First(), new(0, 0, textures.First().width, textures.First().height), new(0.5f, 0.5f));
                return;
            }
            else if (height >= 255 - GlobalVariableHandler.montainLine)
            {
                spriteRenderer.sprite = Sprite.Create(textures.Last(), new(0, 0, textures.Last().width, textures.Last().height), new(0.5f, 0.5f));
                return;
            }
            int range = 255 - GlobalVariableHandler.waterline - GlobalVariableHandler.montainLine;
            int singleInterval = range / (textures.Count() - 2);
            spriteRenderer.sprite = Sprite.Create(textures[(height - GlobalVariableHandler.waterline) / singleInterval + 1], new(0, 0, textures[(height - GlobalVariableHandler.waterline) / singleInterval + 1].width, textures[(height - GlobalVariableHandler.waterline) / singleInterval + 1].height), new(0.5f, 0.5f));
        }
    }
    public static void CreateSpriteMap(int sizeX, int sizeY, double[,] terrain, int[,] buldings,float spriteSize,GameObject map)
    {
        sprites=new GameObject[sizeY,sizeX];
        for(int i = 0; i < sizeY; ++i)
        {
            for (int j = 0; j < sizeX; ++j) 
            {
                sprites[i, j] = new GameObject();
                texturize(terrain[i, j], buldings[i, j], sprites[i, j], spriteSize);
                sprites[i, j].transform.position= new Vector3(j*spriteSize/100.0f,i*spriteSize/100.0f, 10);
                sprites[i, j].transform.parent = map.transform;
            }
        }
        
    }   
}
