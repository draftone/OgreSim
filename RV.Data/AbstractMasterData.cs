using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameDataEditor;
using UnityEngine;

namespace RV.Data
{
    public abstract class AbstractMasterData<T> : RVSingleton<AbstractMasterData<T>>
    {

        public AbstractMasterData() : base(false, false)
        {
        }

        public List<T> list_data;
        public T data;

        /// <summary>
        /// @param technicalName
        /// </summary>
        public abstract T GetData(string technicalName);

        public abstract List<T> GetList();

        public abstract int GetListCount();

        /// <summary>
        /// @param index
        /// </summary>
        public abstract string GetGDEDataName(int index);

        /// <summary>
        /// @param index
        /// </summary>
        public abstract string GetGDEDataKey(int index);
        public abstract T GetRandomData();

        public abstract string GetGDEIconPath(int index);
    }
}