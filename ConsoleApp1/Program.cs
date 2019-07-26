using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter a 7 or 10 digit phone number, no dashes or spaces");
            //var number = Console.ReadLine();
            //if (!(number.Length == 7 || number.Length == 10))
            //{
            //    Console.WriteLine("Invalid Input");
            //    Console.ReadLine();
            //    return;
            //}

            //var numericOnly = long.TryParse(number, out long n);
            //if (!numericOnly)
            //{
            //    Console.WriteLine("Invalid Input");
            //    Console.ReadLine();
            //    return;
            //}
            var number = "1234567890";
            PhoneNumberCombinator phoneNumberCombinator = new PhoneNumberCombinator();
            var combinedresult = phoneNumberCombinator.Combinator(number);
            //var output = new ArrayList();
            //var output2 = new ArrayList();
            //var output3 = new ArrayList();
            //PhoneNumberCombinator phoneNumberCombinator = new PhoneNumberCombinator();
            //    var counter = 0;
            //    number.ToList().ForEach(x =>
            //    {
            //        output3.Clear();
            //        phoneNumberCombinator.Combine(x).ToList().ForEach(y =>
            //        {
            //            if (output2.Count == 0)
            //            {
            //                output3.Add(y + number.Substring(1));
            //            }
            //            else
            //            {
            //                foreach (var o in output2)
            //                {
            //                    string somestring = o.ToString();
            //                    var s = new StringBuilder();
            //                    s.Append(somestring.Substring(0, counter));
            //                    s.Append(y);
            //                    if(number.Length == counter+1)
            //                        output3.Add(s.ToString());
            //                    else
            //                        output3.Add(s.ToString() + number.Substring(s.Length));
            //                }
            //            }

            //        });

            //        output2 = (ArrayList)output3.Clone();
            //        output.AddRange(output2);
            //        counter++;
            //    });
            //output.ToArray().Distinct().ToList().Sort();
            foreach (var combination in combinedresult.ArrayList)
            {
                Console.WriteLine(combination);
            }
            Console.WriteLine(String.Format("Total Combination: {0} ", combinedresult.Totalcombinations));
            Console.ReadLine();
        }
    }

    public class CombinedResult
    {
        private int totalcombinations;
        private ArrayList arrayList;

        public int Totalcombinations { get => totalcombinations; set => totalcombinations = value; }
        public ArrayList ArrayList { get => arrayList; set => arrayList = value; }
    }
    public class PhoneNumberCombinator
    {
        readonly Dictionary<char, char[]> numberLookup = new Dictionary<char, char[]>();

        public PhoneNumberCombinator()
        {
            numberLookup.Add('0', null);
            numberLookup.Add('1', null);
            numberLookup.Add('2', new char[] { 'A', 'B', 'C' });
            numberLookup.Add('3', new char[] { 'D', 'E', 'F' });
            numberLookup.Add('4', new char[] { 'G', 'H', 'I' });
            numberLookup.Add('5', new char[] { 'J', 'K', 'L' });
            numberLookup.Add('6', new char[] { 'M', 'N', 'O' });
            numberLookup.Add('7', new char[] { 'P', 'Q', 'R', 'S' });
            numberLookup.Add('8', new char[] { 'T', 'U', 'V' });
            numberLookup.Add('9', new char[] { 'W', 'X', 'Y', 'Z' });
        }

        public IEnumerable<char> Combine(char number)
        {
            var y = numberLookup.FirstOrDefault(x => x.Key == number).Value;
            if (y == null)
            {
                yield return number;
            }
            else
            {
                foreach (var x in y)
                {
                    yield return x;
                }
            }
        }

        public CombinedResult Combinator(string number)
        {
            //var number = "1234567890";
            var output = new ArrayList();
            var output2 = new ArrayList();
            var output3 = new ArrayList();
            var counter = 0;
            number.ToList().ForEach(x =>
            {
                output3.Clear();
                Combine(x).ToList().ForEach(y =>
                {
                    if (output2.Count == 0)
                    {
                        output3.Add(y + number.Substring(1));
                    }
                    else
                    {
                        foreach (var o in output2)
                        {
                            string somestring = o.ToString();
                            var s = new StringBuilder();
                            s.Append(somestring.Substring(0, counter));
                            s.Append(y);
                            if (number.Length == counter + 1)
                                output3.Add(s.ToString());
                            else
                                output3.Add(s.ToString() + number.Substring(s.Length));
                        }
                    }

                });

                output2 = (ArrayList)output3.Clone();
                output.AddRange(output2);
                counter++;
            });
            output.ToArray().Distinct().ToList().Sort();
            var combinedResult = new CombinedResult
            {
                ArrayList = output,
                Totalcombinations = output.Count
            };
            return combinedResult;
        }
    }
}
