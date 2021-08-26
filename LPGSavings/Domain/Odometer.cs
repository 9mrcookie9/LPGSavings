namespace LPGSavings.Domain
{
    public class Odometer
    {
        public int OdometerId { get; private set; }
        public uint Distance { get; private set; }
        public uint FirstDistance { get; private set; }
        public uint DistanceLPG { get; private set; }
        public uint FirstDistanceLPG { get; private set; }

        private Odometer() { }
        public Odometer(uint distance, uint firstDistance, uint distanceLPG, uint firstDistanceLPG)
        {
            Distance = distance;
            FirstDistance = firstDistance;
            DistanceLPG = distanceLPG;
            FirstDistanceLPG = firstDistanceLPG;
        }
        public void UpdateDistance(uint distance) => Distance = distance;
        public void UpdateDistanceLPG(uint distanceLPG) => DistanceLPG = distanceLPG;
    }
}
