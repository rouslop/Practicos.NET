// See https://aka.ms/new-console-template for more information
using Shared;
using DataAccessLayer.DALs;
using DataAccessLayer.IDALs;
using BusinessLayer.IBLs;
using BusinessLayer.BLs;
using PracticoClase1;

Console.WriteLine("Primera Aplicación con .NET");

IDAL_Personas _personas = new DAL_Personas_ADONet();
IBL_Personas _personasBL = new BL_Personas(_personas);
Commands commands = new Commands(_personasBL);

Console.WriteLine("Comandos Posibles:");
Console.WriteLine("1 - Agregar Persona");
Console.WriteLine("2 - Listar Personas");
Console.WriteLine("3 - Eliminar Persona");
Console.WriteLine("4 - Mostrar Persona");
Console.WriteLine("5 - Actualizar Persona");
Console.WriteLine("6 - Salir");

Console.Write("Ingrese Comando> ");
string command = Console.ReadLine();

while(command != "6")
{
    try
    {
        switch (command)
        {
            case "1":
                commands.AddPersona();
                break;
            case "2":
                commands.ListPersonas();
                break;
            case "3":
                commands.RemovePersona();
                break;
            case "4":
                commands.MostrarPersona();
                break;
            case "5":
                commands.UpdatePersona();
                break;
            default:
                Console.WriteLine("Comando no reconocido");
                break;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine("ERROR --> " + ex.Message);
    }
    finally
    {
        Console.Write("Ingrese Comando > ");
        command = Console.ReadLine();
    }
}

Console.WriteLine("Gracias por usar la aplicación");
