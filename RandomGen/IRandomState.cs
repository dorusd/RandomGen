namespace RandomGen
{
    public interface IRandomState
    {
        double GetLastValue();
        void SetNextValue(double nextInput);
        double[] GetLastValues(int amount);
    }
}