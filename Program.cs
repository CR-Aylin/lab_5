namespace lab_5_POO;
using System;
using System.IO;
using System.Runtime.CompilerServices;
class BaseDatos{
    string u_archivo = "C:\\Users\\alumno\\Desktop\\LAB5\\LAB5poo\\lab5\\datos\\Pokemon-SIMPLE.csv";
    public List<Carta_Pokemon>lista = new List<Carta_Pokemon>();
public void leer(){
   StreamReader archivo = new StreamReader(u_archivo);//abre archivo
    char separador = ',';
    List<string> lineas = new List<string>(File.ReadAllLines(this.u_archivo)); // convierte en una lista
    lineas.RemoveAt(0);
    foreach(string linea in lineas){

        string[] po = linea.Split(separador); //creo un array  de la linea y separo la linea
        Console.WriteLine(linea); 
        Carta_Pokemon ke = new Carta_Pokemon{ //instancio una carta y guardo los datos

        Nombre  = po[1],
        tipo1 = po[2],
        tipo2 = po[3],
        total = Convert.ToInt32(po[4]),
        HP = Convert.ToInt32(po[5]),
        Attack = Convert.ToInt32(po[6]),
        defense = Convert.ToInt32(po[7]),
        Sp_ATK = Convert.ToInt32(po[8]),
        SP_Def = Convert.ToInt32(po[9]),
        Speed = Convert.ToInt32(po[10]),
        Generation = Convert.ToInt32(po[11]),
        Legendary = po[12],
        
        };
        Console.WriteLine(ke.Nombre);
        lista.Add(ke);

    }
    archivo.Close();
}

public interface ICarta
{
    string Nombre { get; }
    void Usar(Jugador jugador);
}

}
/*
public interface IPokemon{ //contrato
    public string Nombre { get; set; }
    public string tipo1 { get; set; }
    public string tipo2 { get; set; }
    public int? total { get; set; }
    public int? HP { get; set; }
    public int? Attack { get; set; }
    public int? defense { get; set; }
    public int? Sp_ATK { get; set; }
    public int? SP_Def { get; set; }
    public int? Speed { get; set; }
    public int? Generation { get; set; }
    public bool? Legendary { get; set; }

}*/

// Interfaz para las cartas
public interface ICarta
{
    string Nombre { get; }
    void Usar(Jugador jugador);
}

// Clase base para las cartas
public abstract class Carta : ICarta
{
    public string Nombre { get; private set; }
    
    /*
    protected Carta(string nombre, string descripcion)
    {
        Nombre = nombre;
        Descripcion = descripcion;
    }*/

    public abstract void Usar(Jugador jugador);
}

public class Carta_Pokemon:Carta {
    //#,Name,Type 1,Type 2,Total,HP,Attack,Defense,Sp. Atk,Sp. Def,Speed,Generation,Legendary
    public string Nombre { get; set; } = string.Empty;//cadena vacia
    public string tipo1 { get; set; }= string.Empty;
    public string tipo2 { get; set; }= string.Empty;
    public  int total { get; set; } = 0; 
    public int HP { get; set; } = 0; 
    public int Attack { get; set; } = 0; 
    public int defense { get; set; } = 0; 
    public int Sp_ATK { get; set; } = 0; 
    public int SP_Def { get; set; } = 0; 
    public int Speed { get; set; } = 0; 
    public int Generation { get; set; } = 0; 
    public string Legendary { get; set; } = string.Empty;

    public Carta_Pokemon(){}

    public override void Usar(Jugador jugador)
    {
        // Lógica para usar el Pokémon
        Console.WriteLine($"{jugador.Nombre} ha usado a {Nombre}!");
    }

    public void RecibirDanio(int danio)
    {
        HP -= danio;
        if (HP <= 0)
        {
            Console.WriteLine($"{Nombre} ha sido descartado.");
        }
    }
}
public class Carta_Energia : Carta{

    public string Tipo { get; private set; }

    public Carta_Energia(string nombre, string descripcion, string tipo)
    {
        Tipo = tipo;
    }

    public override void Usar(Jugador jugador)
    {
        // Lógica para usar la energía
        Console.WriteLine($"{jugador.Nombre} ha usado energía de tipo {Tipo}.");
    }

}

public class Jugador{
    public string Nombre { get; private set; }
    public List<ICarta> Cartas { get; private set; }

    public Jugador(string nombre)
    {
        Nombre = nombre;
        Cartas = new List<ICarta>();
    }

    public void AgregarCarta(ICarta carta)
    {
        Cartas.Add(carta);
    }

    public void Atacar(Jugador oponente, Carta_Pokemon pokemon)
    {
        if (pokemon != null)
        {
            Console.WriteLine($"{Nombre} ataca a {oponente.Nombre} con {pokemon.Nombre}!");
            oponente.RecibirDanio(pokemon.Attack);
        }
    }

    public void RecibirDanio(int danio)
    {
        // Lógica para recibir daño
        Console.WriteLine($"{Nombre} recibe {danio} de daño.");
    }

}
class Mazo{

}

class Arena_Batalla{ //juego
    private Jugador jugador1;
    private Jugador jugador2;

    public Arena_Batalla(Jugador j1, Jugador j2)
    {
        jugador1 = j1;
        jugador2 = j2;
    }

    public void IniciarJuego()
    {
        // Lógica para iniciar el juego
        Console.WriteLine("El juego ha comenzado!");
        // Aquí se puede implementar el flujo del juego
    }

}
class Registro{

}
class Program
{
    static void Main(string[] args){
    BaseDatos bd = new BaseDatos();

    Jugador jugador1 = new Jugador("Jugador 1");
    Jugador jugador2 = new Jugador("Jugador 2");

    Console.WriteLine("2");
    
    Console.WriteLine("4");
    bd.leer();
    Console.WriteLine("hello");
    }
}

