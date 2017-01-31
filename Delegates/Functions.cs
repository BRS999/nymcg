using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net;
using System.Threading.Tasks;

public class Func {

  public static void getFunc() {
    
    // Func types
    Func<int, bool> even = (x) => x % 2 == 0;
    
    //Create a list with only odd numbers
    var arr = Enumerable.Range(1, 100).Where(even).ToList();
    
    arr.ForEach(Console.Write);
  }
}