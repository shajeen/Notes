using System;
using System.Runtime.InteropServices;

// https://stackoverflow.com/questions/13293888/how-to-call-a-c-sharp-library-from-native-c-using-c-cli-and-ijw
// https://www.guidgenerator.com/online-guid-generator.aspx

namespace excel_access
{
    public class excel_a
    {
        
    }
}

namespace MyCSharpClass
{
    [ComVisible(true)] // Don't forget 
    [ClassInterface(ClassInterfaceType.AutoDual)] // these two lines
    [Guid("485B98AF-53D4-4148-B2BD-CC3920BF0ADF")] // or this GUID
    public class TheClass
    {
        public String GetTheThing(String arg) // Make sure this is public
        {
            return arg + "the thing";
        }

        public double GetTheThing(double a, double b, double c)
        {
            return a + b + c;
        }

        public double[] getArray()
        {
           double[] b = { 1.2, 1.4, 1.5};
            return b;
        }
    }
}