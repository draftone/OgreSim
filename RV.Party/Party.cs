
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RV.Unit;
using GameDataEditor;

namespace RV.Party
{
    public abstract class Party<T>
    {
        public Party()
        {
            unit_list = new List<T>();
        }

        public int id;

        public List<T> unit_list;

        public string formation_name;

        public List<string> inventory_item;

        public GDEFormationData formation_data;

        /// <summary>
        /// フォーメーションが有効かどうか
        /// e.g: ユニット数が足りない場合はdisable
        /// </summary>
        public bool is_enable_formation;

        /// <summary>
        ///  /// 選択されているかどうか
        /// </summary>
        public bool is_selected;

        public abstract void RemoveUnit(T unit);

        public void RegisterUnit(T unit)
        {
            unit_list.Add(unit);
        }

        public void NoticeUpdate()
        {
            // TODO implement here
        }

    }
}