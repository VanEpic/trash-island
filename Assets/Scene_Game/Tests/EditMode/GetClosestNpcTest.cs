using System.Collections.Generic;
using NUnit.Framework;
using Scene_Game.Scripts.Player;
using UnityEngine;

namespace Scene_Game.Tests.EditMode
{
    public class GetClosestNpcTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void GetAnyTest()
        {
            GameObject playerObject = new GameObject();
            playerObject.transform.position = new Vector3(-1, 0, 0);
            Player player = playerObject.AddComponent<Player>();

            player.npcs = new List<GameObject>();
            player.npcs.Add(new GameObject());
            player.npcs.Add(new GameObject());
            player.npcs.Add(new GameObject());

            player.npcs[0].transform.position = new Vector3(0,0,0);
            
            player.npcs[1].transform.position = new Vector3(1,0,0);
            player.npcs[2].transform.position = new Vector3(2,0,0);
            
            Assert.AreEqual(player.GetClosestNpc(), player.npcs[0]);
        }

        [Test]
        public void GetCandyTest()
        {
            GameObject playerObject = new GameObject();
            playerObject.transform.position = new Vector3(365.320007f,34.2200012f,518.530029f); // player close to Mandicoot
            Player player = playerObject.AddComponent<Player>();

            GameObject mandicoot = new GameObject();
            mandicoot.transform.position = new Vector3(359.980011f,34.2200000f,514.330017f);
            
            GameObject candy = new GameObject();
            candy.transform.position = new Vector3(365.320007f,34.2200012f,518.299988f);
            
            player.npcs = new List<GameObject>();
            player.npcs.AddRange(new List<GameObject>{mandicoot, candy});

            Assert.AreEqual(player.npcs[1], player.GetClosestNpc());
        }
    
        [Test]
        public void GetMandicootTest()
        {
            GameObject playerObject = new GameObject();
            playerObject.transform.position = new Vector3(359.320007f,34.2200012f,514.530029f); // player close to Mandicoot
            Player player = playerObject.AddComponent<Player>();

            GameObject mandicoot = new GameObject();
            mandicoot.transform.position = new Vector3(359.980011f,34.2200000f,514.330017f);
            
            GameObject candy = new GameObject();
            candy.transform.position = new Vector3(365.320007f,34.2200012f,518.299988f);
            
            player.npcs = new List<GameObject>();
            player.npcs.AddRange(new List<GameObject>{mandicoot, candy});

            Assert.AreEqual(player.npcs[0], player.GetClosestNpc());
        }
    }
}
