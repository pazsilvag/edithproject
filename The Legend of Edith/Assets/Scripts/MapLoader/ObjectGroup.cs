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

namespace MapReader
{
	public class ObjectGroup {

		public String name;
		int width;
		public int height;
		public List<MapObject> objects;

		public ObjectGroup (XmlNode node) {
			this.name = node.Attributes["name"].Value;
			//this.width = int.Parse(node.Attributes["width"].Value);
			//this.height = int.Parse(node.Attributes["height"].Value);
			this.objects = new List<MapObject>();

			XmlNodeList objectList = node.SelectNodes("object");

			foreach (XmlNode objectNode in objectList) {
				MapObject mapObject = new MapObject(objectNode);
				objects.Add(mapObject);
			}

		}
	}
}

