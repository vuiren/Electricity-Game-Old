namespace Assets.Scripts
{
    public interface IEnergyEmitter
    {
        public EnergyOutput EnergyOutput { get; }
    }

    public interface IEnergyConsumer
    {
        public EnergyInput EnergyInput { get; }
    }
}
