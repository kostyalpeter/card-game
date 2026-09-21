using UnityEngine;
    public interface ISaveable
    {
        void SaveData(Save data);
        void LoadData(Save data);
    }