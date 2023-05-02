

using Codice.Client.BaseCommands;
using NUnit.Framework;
using SuperTiled2Unity.Editor;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace SuperTiled2Unity
{

    public class CustomIsometricImporter : CustomTmxImporter
    {
        public override void TmxAssetImported(TmxAssetImportedArgs args)
        {
            // Note: args.ImportedSuperMap is the root of the imported prefab
            // You can modify the gameobjects and components any way you wish here
            // Howerver, the results must be deterministic (i.e. the same prefab is created each time)
            var map = args.ImportedSuperMap;
            Debug.LogFormat("Map '{0}' has been imported.", map.name);


            SetSortOrder(map);
            SetCollisionLayer(map);
            
        }

        private void SetCollisionLayer(SuperMap map)
        {
            SuperTileLayer collisionLayer = map.GetComponentsInChildren<SuperTileLayer>().Where(layer => layer.m_TiledName == "Collision").FirstOrDefault();
            if(collisionLayer != null)
            {
                collisionLayer.gameObject.AddComponent<HideTilemapColliderOnPlay>();
            }
        }


        private void SetSortOrder(SuperMap map)
        {
            List<TilemapRenderer> TMRenderers = new List<TilemapRenderer>();
            TMRenderers = map.GetComponentsInChildren<TilemapRenderer>().ToList<TilemapRenderer>();

            foreach (var renderer in TMRenderers)
            {
                if (renderer != null)
                {
                    renderer.sortOrder = TilemapRenderer.SortOrder.TopRight;
                }
            }
        }
    }
}
