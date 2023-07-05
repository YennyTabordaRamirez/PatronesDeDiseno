using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pPatronesDiseño.Patrones.Creacionales.Abstract_Factory
{
    //Fábrica abstracta de vehículos
    public interface IAbstractFactoryVehiculos
    {
        string Propietario { get; set; }
        eTipoVehiculo TipoVehiculo { get; set; }
        //Métodos para crear las interfaces abstractas de los vehículos (con y sin motor)
        IAbstractFactoryVehiculosMotor CrearVehiculosMotor();
        IAbstractFactoryVehiculosSinMotor CrearVehiculosSinMotor();
    }
    //Fábrica abstracta vehículos con motor
    public interface IAbstractFactoryVehiculosMotor
    {
        string Propietario { get; set; }
        string NumeroMotor { get; set; }
        string NumeroChasis { get; set; }
        int Potencia { get; set; }
        string RegistrarRUNT();
        string Matricular();
        string PagarSOAT();
        string DefinirCaracterísticas();
    }
    //Fábrica abstracta vehículos sin motor
    public interface IAbstractFactoryVehiculosSinMotor
    {
        string Propietario { get; set; }
        string NumeroSerie { get; set; }
        string Registrar();
    }
    public enum eTipoVehiculo
    {
        Automovil = 1,
        Camioneta = 2,
        Camion = 3,
        Bicicleta = 4,
        Motocicleta = 5,
        TractoCamion = 6,
        Carro_Traccion_Animal = 7,
        Carro_rodillos = 8,
        MotoCarro = 9,
        Carretilla = 10
    }
    //Factory de clases concretas -- Vehículos motor
    public class VehiculosMotorFactory : IAbstractFactoryVehiculos
    {
        public string Propietario { get; set; }
        public eTipoVehiculo TipoVehiculo { get; set; }
        public IAbstractFactoryVehiculosMotor CrearVehiculosMotor()
        {
            //Invoca la creación de las clases concretas con motor
            switch (TipoVehiculo)
            {
                case eTipoVehiculo.Automovil:
                    return new Automovil();
                case eTipoVehiculo.Motocicleta:
                    return new Motocicleta();
                case eTipoVehiculo.MotoCarro: 
                    return null;
                case eTipoVehiculo.Camion:
                    return null;
                case eTipoVehiculo.Camioneta:
                    return null;
                case eTipoVehiculo.TractoCamion:
                    return null;
                default : return null;
            }
        }
        public IAbstractFactoryVehiculosSinMotor CrearVehiculosSinMotor()
        {
            return null;
        }
    }
    public class Motocicleta : IAbstractFactoryVehiculosMotor
    {
        public string Propietario { get; set; }
        public string NumeroMotor { get; set; }
        public string NumeroChasis { get; set; }
        //Adicional
        public string NumeroPasajeros { get; set; }
        public int Potencia { get; set; }
        //Adicional
        public string DefinirCaracterísticas()
        {
            NumeroPasajeros = "2";
            Potencia = 60;
            return "CARACTERÍSTICAS MOTO\nNúmero de pasajeros: " + NumeroPasajeros +
                   "\nPotencia: " + Potencia.ToString();
        }
        public string Matricular()
        {
            return "La moto con número de chasís: " + NumeroChasis + "\n" +
                   "Número de motor: " + NumeroMotor + "\n" +
                   "Se matrículó correctamente";
        }
        public string PagarSOAT()
        {
            return "Se pagó el SOAT de la moto del propietario " + Propietario;
        }
        public string RegistrarRUNT()
        {
            return "Se registró la moto del propietario " + Propietario +
                "en el RUNT nacional";
        }
    }
    public class Automovil : IAbstractFactoryVehiculosMotor
    {
        public string Propietario { get; set; }
        public string NumeroMotor { get; set; }
        public string NumeroChasis { get; set; }
        //Adicional
        public string NumeroPasajeros { get; set; }
        public int Potencia { get; set; }
        //Adicional
        public string DefinirCaracterísticas()
        {
            NumeroPasajeros = "4";
            Potencia = 110;
            return "CARACTERÍSTICAS AUTOMÓVIL\nNúmero de pasajeros: " + NumeroPasajeros +
                   "\nPotencia: " + Potencia.ToString();
        }
        public string Matricular()
        {
            return "El automóvil con número de chasís: " + NumeroChasis + "\n" +
                   "Número de motor: " + NumeroMotor + "\n" +
                   "Se matrículó correctamente";
        }
        public string PagarSOAT()
        {
            return "Se pagó el SOAT del automóvil del propietario " + Propietario;
        }
        public string RegistrarRUNT()
        {
            return "Se registró el automóvil del propietario " + Propietario +
                "en el RUNT nacional";
        }
    }
    //Factory de clases de vehículos sin motor
    public class VehiculosSinMotorFactory : IAbstractFactoryVehiculos
    {
        string IAbstractFactoryVehiculos.Propietario { get; set; }
        public eTipoVehiculo TipoVehiculo { get; set; }
        IAbstractFactoryVehiculosMotor IAbstractFactoryVehiculos.CrearVehiculosMotor()
        {
            return null;
        }
        IAbstractFactoryVehiculosSinMotor IAbstractFactoryVehiculos.CrearVehiculosSinMotor()
        {
            switch (TipoVehiculo) 
            {
                case eTipoVehiculo.Bicicleta:
                    return new Bicicleta();
                case eTipoVehiculo.Carro_Traccion_Animal:
                    return new Carro_Traccion_Animal();
                default: return null;
            }
        }
    }
    public class Bicicleta : IAbstractFactoryVehiculosSinMotor
    {
        public string Propietario { get; set; }
        public string NumeroSerie { get; set; }
        public string Registrar()
        {
            return "Se registró la bicicleta del señor(a): " + Propietario + "\n" +
                   "Número de serie: " + NumeroSerie;
        }
    }
    public class Carro_Traccion_Animal : IAbstractFactoryVehiculosSinMotor
    {
        public string Propietario { get; set; }
        public string NumeroSerie { get; set; }
        public int EdadAnimal { get; set; }
        public string Registrar()
        {
            return "Se registró el vehículo de tracción animal del señor(a): " + Propietario + "\n" +
                   "Edad del animal: " + EdadAnimal.ToString();
        }
    }
}
