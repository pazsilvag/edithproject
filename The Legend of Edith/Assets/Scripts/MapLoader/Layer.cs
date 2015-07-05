//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.18444
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Xml;
using System.Collections.Generic;
using UnityEngine;

namespace MapReader {
	public class Layer {

		public String name;
		int width;
		int height;
		public List<List<LayerTile>> layerTiles;

		const uint Horizontal = 0x80000000;
		const uint Vertical = 0x40000000;
		const uint Diagonal = 0x20000000;
		
		public Layer (XmlNode node) {
			name = node.Attributes["name"].Value;
			width = int.Parse (node.Attributes ["width"].Value);
			height = int.Parse (node.Attributes ["height"].Value);

			XmlNode data = node.SelectSingleNode("data");
			XmlNodeList tiles = data.SelectNodes("tile");

			layerTiles = new List<List<LayerTile>>();

			int tileIndex = 0;
			for (int y = 0; y < height; y++) {

				layerTiles.Add(new List<LayerTile>());

				for (int x = 0; x < width; x++) {
					XmlNode tile = tiles[tileIndex];
					tileIndex++;

					uint gid = uint.Parse (tile.Attributes["gid"].Value);

					bool flippedH = (gid & Horizontal) == Horizontal;
					bool flippedV = (gid & Vertical) == Vertical;
					bool flippedD = (gid & Diagonal) == Diagonal;

					uint gidNoFlags = gid;
					gidNoFlags &= ~(Horizontal | Vertical | Diagonal);

					LayerTile layerTile = new LayerTile((int)gidNoFlags, flippedD, flippedH, flippedV);

					layerTiles[y].Add(layerTile);
				}
			}

			layerTiles.Reverse ();
		}
	}
}

