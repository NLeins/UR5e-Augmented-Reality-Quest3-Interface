using System;
using System.Collections;
using System.Collections.Generic;
using Meta.XR.BuildingBlocks;
using UnityEngine;

public class AnchorManager : MonoBehaviour
{
    public GameObject anchorPrefab;
    public SpatialAnchorCoreBuildingBlock spatialAnchorCoreBuildingBlock;
    private OVRSpatialAnchor robotAnchor;

    void Start()
    {
        // load saved anchor
        bool success = LoadAnchorsFromPreviousSession();
        if(success){
            // deacticate anchor placer
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    void Update()
    {
        // Create anchor
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            // delete old anchor
            spatialAnchorCoreBuildingBlock.EraseAllAnchors();
            
            // create new anchor
            spatialAnchorCoreBuildingBlock.InstantiateSpatialAnchor(anchorPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }

        // activate anchor placer
        if(OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.RTouch))
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void OnAnchorCreateCompleted(OVRSpatialAnchor anchor, OVRSpatialAnchor.OperationResult result)
    {
        if(result == OVRSpatialAnchor.OperationResult.Success)
        {
            robotAnchor = anchor;
            SaveAnchorUUID(robotAnchor.Uuid);
        }
    }
    private void SaveAnchorUUID(Guid uuid)
    {
        List<string> savedUUIDs = new List<string>();

        if (PlayerPrefs.HasKey("SavedAnchors"))
        {
            string json = PlayerPrefs.GetString("SavedAnchors");
            savedUUIDs = JsonUtility.FromJson<UUIDList>(json).uuids;
        }

        savedUUIDs.Add(uuid.ToString());

        UUIDList uuidList = new UUIDList { uuids = savedUUIDs };
        string newJson = JsonUtility.ToJson(uuidList);
        PlayerPrefs.SetString("SavedAnchors", newJson);
        PlayerPrefs.Save();
    }
    [Serializable]
    private class UUIDList
    {
        public List<string> uuids;
    }
    private List<Guid> LoadSavedUUIDs()
    {
        if (!PlayerPrefs.HasKey("SavedAnchors"))
            return new List<Guid>();

        string json = PlayerPrefs.GetString("SavedAnchors");
        List<string> savedUUIDs = JsonUtility.FromJson<UUIDList>(json).uuids;
        
        List<Guid> uuids = new List<Guid>();
        foreach (string uuidStr in savedUUIDs)
        {
            if (Guid.TryParse(uuidStr, out Guid uuid))
            {
                uuids.Add(uuid);
            }
        }
        return uuids;
    }
    public bool LoadAnchorsFromPreviousSession()
    {
        List<Guid> savedUUIDs = LoadSavedUUIDs();
        if (savedUUIDs.Count > 0)
        {   
            spatialAnchorCoreBuildingBlock.LoadAndInstantiateAnchors(anchorPrefab, savedUUIDs);
            return true;
        }else
        {
            return false;
        }
    }
}
