//Buneas practicas 1
using System;

class ProgramaSuma
{
    static void Main()
    {
        int primerNumero = 3;
        int segundoNumero = 7;
        int resultadoDeLaSuma = SumarNumeros(primerNumero, segundoNumero);

        Console.WriteLine($"La suma es: {resultadoDeLaSuma}");
    }

    static int SumarNumeros(int numeroA, int numeroB)
    {
        return numeroA + numeroB;
    }
}
//Buenas praticas 2
public class Calculadora
{
    public int Sumar(int a, int b)
    {
        return a + b;
    }

    public int Restar(int a, int b)
    {
        return a - b;
    }

    public bool EsNumeroValido(string input)
    {
        return int.TryParse(input, out _);
    }
}

//Buneas practicas 3 
public class UsuarioService
{
    private readonly IUsuarioRepository usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        this.usuarioRepository = usuarioRepository;
    }

    public Usuario ObtenerPorId(int id)
    {
        return usuarioRepository.GetById(id);
    }

    public bool EsNombreValido(string nombre)
    {
        return !string.IsNullOrWhiteSpace(nombre);
    }
}

//Buenas practicas 4
public decimal CalcularPrecioFinal(decimal precioBase, decimal descuento)
{
    // Aplicamos el descuento aquí porque el precio final
    // se usa en facturación y debe reflejar promociones vigentes.
    return precioBase - descuento;
}

//Buenas practicas 5

//Antes 
public void Procesar()
{
    var x = ObtenerDatos();
    if (x != null && x.Count > 0)
    {
        foreach (var i in x)
        {
            if (i.Estado == 1)
            {
                Guardar(i);
            }
        }
    }
}


//Despues
public void Procesar()
{
    var datos = ObtenerDatos();

    if (datos == null || datos.Count == 0) return;

    foreach (var item in datos)
    {
        if (EsActivo(item))
        {
            Guardar(item);
        }
    }
}

private bool EsActivo(Dato item) => item.Estado == 1;
 

//Buenas practicas 6

public Usuario ObtenerUsuarioPorId(int id)
{
    if (id <= 0)
    {
        throw new ArgumentException("El ID de usuario debe ser mayor a cero.", nameof(id));
    }

    var usuario = usuarioRepository.GetById(id);

    if (usuario == null)
    {
        
        throw new InvalidOperationException($"No se encontró usuario con ID {id}.");
    }

    return usuario;
}

//Buenas practicas 7

//TEST RED 
[TestClass]
public class CalculadoraTests
{
    [TestMethod]
    public void Sumar_DosNumeros_RetornaResultadoCorrecto()
    {
        var calculadora = new Calculadora();
        var resultado = calculadora.Sumar(2, 3);

        Assert.AreEqual(5, resultado);
    }
}


//TEST GREEN 
public class Calculadora
{
    public int Sumar(int a, int b)
    {
        return a + b;
    }
}


//TEST GREEN


public class Calculadora
{
    public int Sumar(int a, int b)
    {
        return a + b;
    }
}



//TEST REFACTOR 

public class Calculadora
{
    
    public int Sumar(params int[] numeros)
    {
        return numeros.Sum();
    }
}



//Buenas praticas 8 
//Features
   //Usuarios
      //UsuarioController.cs
      //UsuarioService.cs
      //UsuarioRepository.cs
      //UsuarioModel.cs
   //Productos
      //ProductoController.cs
      //ProductoService.cs
      //ProductoRepository.cs
      //ProductoModel.cs
//Shared
   //BaseRepository.cs
   //LoggerService.cs


//Buenas practicas 9

//Incorrecto 
public decimal Calc(decimal s, decimal t)
{
    return s + s * t;
}

//Correcto
public class PedidoService
{
    public decimal CalcularTotalConImpuestos(decimal subtotal, decimal tasaImpuesto)
    {
        // Se aplica el impuesto al subtotal para obtener el total final
        return subtotal + (subtotal * tasaImpuesto);
    }
}


//Buenas practicas 10

public static class ConfiguracionSistema
{
    public const decimal TasaImpuesto = 0.19m;
    public const int MaxIntentosLogin = 5;

    public static bool EsUsuarioValido(Usuario usuario)
    {
       
        return usuario.Activo && usuario.Verificado;
    }
}


//Buenas practicas 11

public bool ValidarCredenciales(string email, string password)
{
    var usuario = usuarioRepository.GetByEmail(email);

    if (usuario == null  usuario.ValidarPassword(password))
    {
       
        throw new UnauthorizedAccessException("Credenciales inválidas.");
    }

    return true;
}

