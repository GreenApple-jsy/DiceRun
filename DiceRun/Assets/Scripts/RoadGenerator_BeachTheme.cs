using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator_BeachTheme : MonoBehaviour
{
    public GameObject[] targetRoads;
    public GameObject sampleTree;
    public GameObject sampleGrass;
    private GameObject[] roadDeco;
    private float grassMinX;
    private float grassMaxX;
    private float leftTreeX;
    private float rightTreeX;
    private float treeMinHeightY;
    private float treeMaxHeightY;
    private float roadLength;

    //랜덤 : 회전, 위치, 크기
    private void Start()
    {
        grassMinX = -1.5f;
        grassMaxX = 1.5f;
        leftTreeX = -1.5f;
        rightTreeX = 1.5f;
        treeMinHeightY = 1.4f;
        treeMaxHeightY = 1.9f;
        roadLength = 15f;

        roadDeco = new GameObject[targetRoads.Length];
        for (int i = 0; i < targetRoads.Length; ++i) {
            roadDeco[i] = targetRoads[i].transform.Find("Deco").gameObject;
        }

        reGenerateMap();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Dice"))
        {
            Debug.Log(this.name + " Regenarate Map");
            reGenerateMap();
        }
    }

    private void reGenerateMap() {
        clearPreviousDeco();
        addLeftLineTrees();
        addRightLineTrees();
        addGrasses();
    }

    private void clearPreviousDeco() {
        for (int i = 0; i < roadDeco.Length; ++i) {
            int childCount = roadDeco[i].transform.childCount;
            for (int c = 0; c < childCount; c++) {
                Destroy(roadDeco[i].transform.GetChild(c).gameObject);
            }
        }
    }

    private void addLeftLineTrees() {
        int treeCount = Random.Range(1, 4);
        Debug.Log(this.name + " leftTrees : " + treeCount);
        for (int i = 0; i < treeCount; ++i) {
            Vector3 treeScale = new Vector3(1.2f, Random.Range(treeMinHeightY, treeMaxHeightY), 1.3f);
            Quaternion treeRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            for (int p = 0; p < roadDeco.Length; ++p) {
                Vector3 treePos = new Vector3(leftTreeX, -0.3f, -7 + (14 / treeCount * (i + 1)) + targetRoads[p].transform.position.z);
                GameObject newTree = Instantiate(sampleTree, treePos, treeRotation, roadDeco[p].transform);
                newTree.transform.localScale = treeScale;
            }
        }
    }

    private void addRightLineTrees() {
        int treeCount = Random.Range(1, 4);
        Debug.Log(this.name + " rightTrees : " + treeCount);
        for (int i = 0; i < treeCount; ++i) {
            Vector3 treeScale = new Vector3(1.2f, Random.Range(treeMinHeightY, treeMaxHeightY), 1.3f);
            Quaternion treeRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            for (int p = 0; p < roadDeco.Length; ++p) {
                Vector3 treePos = new Vector3(rightTreeX, -0.3f, -7 + (14 / treeCount * (i + 1)) + targetRoads[p].transform.position.z);
                GameObject newTree = Instantiate(sampleTree, treePos, treeRotation, roadDeco[p].transform);
                newTree.transform.localScale = treeScale;
            }
        }
    }

    private void addGrasses() {
        int grassCount = Random.Range(1, 6);
        Debug.Log(this.name + " Grasses : " + grassCount);
        for (int i = 0; i < grassCount; ++i)
        {
            Vector3 grassScale = new Vector3(Random.Range(0.5f, 1.3f), Random.Range(0.5f, 1.3f), Random.Range(0.5f, 1.3f));
            Quaternion grassRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            float grassPosX = Random.Range(grassMinX, grassMaxX);
            for (int p = 0; p < roadDeco.Length; ++p)
            {
                Vector3 grassPos = new Vector3(grassPosX, -0.3f, -7 + (14 / grassCount * (i + 1)) + targetRoads[p].transform.position.z);
                GameObject newTree = Instantiate(sampleGrass, grassPos, grassRotation, roadDeco[p].transform);
                newTree.transform.localScale = grassScale;
            }
        }
    }







}
