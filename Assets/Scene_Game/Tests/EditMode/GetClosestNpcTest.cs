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
        public void GetClosestNpcTestSimplePasses()
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
    }
}
