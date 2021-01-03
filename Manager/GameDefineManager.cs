using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RV
{
    public class GameDefineManager : RVSingleton<GameDefineManager>
    {
        public GameDefineManager() : base(false, false)
        {
        }

        /// <summary>
        /// Defines the size of a 'cell' in our map (width,height,depth) in unity units
        /// </summary>
        public Vector3 g_tile_size;

        /// <summary>
        /// The Size of the Grid, where the height is mapSize.y
        /// </summary>
        public Vector3 g_map_size;

        /// <summary>
        /// prefab unit size.
        /// </summary>
		public Vector3 g_prefab_unit_size = new Vector3(1.0f, 0.5f, 1.0f);

    }
}