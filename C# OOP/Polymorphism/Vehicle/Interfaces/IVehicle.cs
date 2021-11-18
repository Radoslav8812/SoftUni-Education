
namespace Vehicles.Interfaces
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }

        public bool CanDrive(double km);
        void Drive(double km);
        void Refuel(double litters);
    }
}
