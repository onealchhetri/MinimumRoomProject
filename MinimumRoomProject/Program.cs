using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumRoomProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            //if  starting of one class is same as ending time of next class then it requires next room to start(my version)
            //to change this property uncomment a code in step 2.1 and comment above if statements

            #region Variables Declarations
            int minimumRoom = 0;
            int paircount;
            List<int> pair = new List<int>();
            List<int[,]> arr = new List<int[,]>();
            List<int[,]> Overlappingarr = new List<int[,]>();
            List<int[,]> NonOverlappingarr = new List<int[,]>();
            //List<int[,]> sortedArray = new List<int[,]>();
            #endregion

            #region Input for the program
            //uncomment any one 
            #region entry for random input data
            arr.Add(new int[1, 2] { { 30, 75 } });
            arr.Add(new int[1, 2] { { 0, 50 } });
            arr.Add(new int[1, 2] { { 60, 150 } });

            //arr.Add(new int[1, 2] { { 0, 20 } });
            //arr.Add(new int[1, 2] { { 25, 45 } });
            //arr.Add(new int[1, 2] { { 50, 90 } });
            //arr.Add(new int[1, 2] { { 95, 150 } });

            //arr.Add(new int[1, 2] { { 0, 10 } });
            //arr.Add(new int[1, 2] { { 20, 30 } });
            //arr.Add(new int[1, 2] { { 25, 40 } });
            //arr.Add(new int[1, 2] { { 45, 90 } });
            //arr.Add(new int[1, 2] { { 50, 90 } });

            //arr.Add(new int[1, 2] { { 10, 50 } });
            //arr.Add(new int[1, 2] { { 70, 80 } });
            //arr.Add(new int[1, 2] { { 75, 120 } });
            //arr.Add(new int[1, 2] { { 80, 120 } });


            //arr.Add(new int[1, 2] { { 0, 20 } });
            //arr.Add(new int[1, 2] { { 30, 50 } });
            //arr.Add(new int[1, 2] { { 70, 90 } });
            //arr.Add(new int[1, 2] { { 65, 105 } });

            #endregion


            #region input from User if need

            //string answer = "";

            //do {
            //    int[,] input = new int[1, 2];
            //    Console.WriteLine("Enter starting time(only interger or whole number):: ");
            //    input[0, 0] = int.Parse(Console.ReadLine());


            //    Console.WriteLine("Enter ending time(only interger or whole number):: ");
            //    input[0, 1] = int.Parse(Console.ReadLine());

            //    arr.Add(input);

            //    Console.WriteLine("Continue[Yes/No]");
            //    answer = Console.ReadLine();

            //} while (answer.ToLower() != "no" || answer.ToLower() != "n");
            #endregion

            #endregion

            #region Given Input Data
            Console.WriteLine("Given time array:::");
            arr.ForEach(v =>
            {
                Console.WriteLine($"{v[0, 0]} , {v[0, 1]}");
            });
            #endregion
        
            #region step 1[sorting the given data according starting time
            var sort = arr.OrderBy(v => v[0, 0]);
            var sortedArray = sort.ToList();


            #endregion
            
            #region showing sorted array
            //Console.WriteLine("sorted array");
            //sortedArray.ForEach(v =>
            //{
            //    Console.WriteLine($"{v[0, 0]}  {v[0, 1]}");
            //});
            #endregion

            #region step 2 [arranging the data into overlapped array and non overlapped array]

            for (int i =0; i<sortedArray.Count; i++)
            {
                paircount = 0;
                if (!checkinoverlapped(sortedArray[i]))
                {
                    int count = 0;
                    for (int j = i + 1; j < sortedArray.Count; j++)
                    {

                        if (!checkinoverlapped(sortedArray[j]))
                        {
                            var temp1 = sortedArray[i][0, 1];
                            var temp2 = sortedArray[j][0, 0];
                            if (temp1 >= temp2)
                            #region step 2.1 [section to uncomment as per required according to above given condition]
                            //comment above if 
                            //if(temp1 > temp2) 
                            #endregion
                            {
                                count++;
                                paircount++;
                                Overlappingarr.Add(sortedArray[j]);

                            }
                        }
                    }

                    if (count > 0 && !checkinoverlapped(sortedArray[i]))
                    {
                        Overlappingarr.Add(sortedArray[i]);
                        paircount++;
                        pair.Add(paircount);
                    }


                    else
                    {
                        if (!checkinoverlapped(sortedArray[i]))
                            NonOverlappingarr.Add(sortedArray[i]);
                    }
                }
            }

            //if (!checkinoverlapped(sortedArray[sortedArray.Count-1]))
            //    NonOverlappingarr.Add(sortedArray[sortedArray.Count-1]);
            #endregion

            #region step 3 [checking if overlapped array already contains given element]
            bool checkinoverlapped(int[,] temp)
            {
                bool result = false;
                Overlappingarr.ForEach(v =>
                {
                    if (v == temp)
                        result = true;
                });
                return result;
            }

            #endregion

            #region Displaying overlapped and non overlapped data
            
            //Console.WriteLine("Overlapping array");

            //Overlappingarr.ForEach(v =>
            //{
            //    Console.WriteLine($"{v[0, 0]}  {v[0, 1]}");
            //});
            //Console.WriteLine("Non overlapping array");
            //NonOverlappingarr.ForEach(v =>
            //{
            //    Console.WriteLine($"{v[0, 0]}  {v[0, 1]}");
            //});

            #endregion

            #region step4 [assign the minimum room and formation of final result]
            if (Overlappingarr.Count == 0)
            {
                minimumRoom++;
            }
            else
            {
                minimumRoom = pair.Min();
            }
            #endregion

            #region step 5 [Displaying final result]
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"the minimum room required is :: {minimumRoom}");
            //Console.WriteLine("pari count:: ");
            ////pair.ForEach(c => Console.WriteLine(c));
            #endregion


            Console.Read();

        }

    }
}
