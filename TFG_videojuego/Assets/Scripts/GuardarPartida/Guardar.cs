using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Guardar : MonoBehaviour
{
    public static void GuardarJugador (VidaPersonaje vida, RecogerMonedas monedasActuales, Personaje respawn){
        BinaryFormatter formatter = new BinaryFormatter();
        string ruta = "/Users/javivi/Desktop/Unity/MonsterSlayer/TFG_videojuego/DatosGuardados/jugador.bin";
        FileStream stream = new FileStream(ruta, FileMode.Create);

        DatosJugador datos = new DatosJugador(vida, monedasActuales, respawn);

        formatter.Serialize(stream, datos);
        stream.Close();
    }

    public static DatosJugador CargarJugador(){
        string ruta = "/Users/javivi/Desktop/Unity/MonsterSlayer/TFG_videojuego/DatosGuardados/jugador.bin";

        if(File.Exists(ruta)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(ruta, FileMode.Open);

            DatosJugador datos = formatter.Deserialize(stream) as DatosJugador;
            stream.Close();

            return datos;
        } else{
            return null;
        }
    }

    public static void BorrarDatos(){
        string ruta = "/Users/javivi/Desktop/Unity/MonsterSlayer/TFG_videojuego/DatosGuardados/jugador.bin";

        if(File.Exists(ruta)){
            File.Delete(ruta);
        }
        
    }
}
