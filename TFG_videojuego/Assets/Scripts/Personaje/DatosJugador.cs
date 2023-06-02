using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DatosJugador
{
   public int monedas;
   public int corazones;
   public float[] respawnPoint;
   public int nivel;

   public DatosJugador (VidaPersonaje vida, RecogerMonedas monedasActuales, Personaje respawn){
       monedas = monedasActuales.monedas;
       corazones = vida.corazones;
       respawnPoint = new float[3];
       respawnPoint[0] = respawn.transform.position.x;
       respawnPoint[1] = respawn.transform.position.y;
       respawnPoint[2] = respawn.transform.position.z;
       nivel = respawn.nivel;
   }
}
