using System.Collections;

namespace Car;

public class CarPriceComparer : IComparer
{
    public int Compare(object x, object y)
    {
        if (x is Car car1 && y is Car car2)
        {
            return car1.Price.CompareTo(car2.Price);
        }
        return 0;
    }
}