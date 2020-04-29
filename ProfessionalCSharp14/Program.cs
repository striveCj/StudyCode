using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp14
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void NumberDemol(string n)
        {
            if (n is null)
            {
                throw new ArgumentNullException(nameof(n));
            }
            try
            {
                int i = int.Parse(n);
                Console.WriteLine($"{i}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void NumberDemo2(string n)
        {
            if (n is null)
            {
                throw new ArgumentNullException(nameof(n));
            }
            if (int.TryParse(n,out int result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("not a number");
            }
            
         }


        static void SimpleExceptions()
        {
            while (true)
            {
                try
                {
                    string userInput;
                    Console.WriteLine("输入0-5之间");
                    userInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(userInput))
                    {
                        break;
                    }
                    int index = Convert.ToInt32(userInput);
                    if (index<0||index>5)
                    {
                        throw new IndexOutOfRangeException($"你输入的{userInput}");
                    }
                    Console.WriteLine($"你输入的是{index}");
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Exception:"+$"{ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }           
                finally
                {
                    Console.WriteLine("谢谢");
                }
            }

        }

        public static void ThrowWithErrorCode(int code)
        {
            throw new MyCustomException("Error in Foo") { ErrorCode = code };
        }


        public static void HandleAll()
        {
            var methods = new Action[]
            {
                HandleAndThrowAgain,
                HandleAndThrowWithInnerException,
                HandleRethrow,
                HandleWithFilter
            };
            foreach (var item in methods)
            {
                try
                {
                    item();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    if (ex.InnerException!=null)
                    {
                        Console.WriteLine($"\tInner Exception{ex.Message}");
                        Console.WriteLine(ex.InnerException.StackTrace);
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}
