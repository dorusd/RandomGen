namespace RandomGen.Filters
{
    public interface IRandomFilter
    {
        double FilterValue(double nextInput);
    }
}