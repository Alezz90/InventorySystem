using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace InventorySystem
{
    class Program
    {   static void Main(string[] args)
        {
            #region cheack admin
            string admin;
            string password;
            Console.WriteLine("Welcome to the Inventory Management System!");
            Console.Write("Please enter your username:");
            string adm = Console.ReadLine();
            admin = (adm.ToLower() == "admin!") ? "admin!" : "check agin";
            Console.Write("Please enter your password:");
            string admpass = Console.ReadLine();
            password = (admpass.ToLower() == " adminpass") ? "accept" : "check agin ";
            Console.WriteLine($"Authentication successful! Welcome, {admin}");
            #endregion
            int Qunt =0;
            int ArraySize =0;
            int[] ProductID = { };
            string[] ProductName = { };
            double[] ProductPrice = { };
            int[] ProductQuantity = { };

            int saleRecord = 0;
            int[] ProductSale = new int[saleRecord];
            int[] QuantitySale = new int[ProductSale.Length];
            while (true)//loop the app
            {
                Console.WriteLine(" 1. Add a new product  \n 2. Update product quantity  \n 3. Display product list \n 4.Record sale \n 5. Generate product report  \n 6. Generate sales report  \n 7. Exit");
                 int swit = Convert.ToInt32(Console.ReadLine());
                if ((swit < 1) || (swit > 8))
                {
                    Console.WriteLine("Invalid enter");
                }
                else if ((swit > 0) && (swit < 7))
                {
                    // case 1 =add, 2=update 3=Product List 4=recordsale 5=reportSaleforproduct 6=reportallsale 7=exit
                    #region switch
                    switch (swit)
                    {

                        #region add product case1
                        case 1:
                             Console.WriteLine("How many product you want to add?");
                            ArraySize = Convert.ToInt32(Console.ReadLine());

                            ProductID = new int[ArraySize];
                            ProductName = new string[ArraySize];
                            ProductPrice = new double[ArraySize];
                            ProductQuantity = new int[ArraySize];
                            for (int i = 0; i < ProductName.Length; i++)
                            {
                                Console.WriteLine("Enter product Name?");
                                ProductName[i] = Console.ReadLine();
                                ProductID[i] = i + 1;
                                Console.WriteLine("Enter product Price?");
                                ProductPrice[i] = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Enter product Quntity?");
                                ProductQuantity[i] = Convert.ToInt32(Console.ReadLine());
                            }

                            break;
                        #endregion
                        #region case2 update prod
                        case 2:
                            Console.WriteLine("choocs the product by enter it number");
                            for (int i = 0; i < ProductName.Length; i++)
                            {
                                Console.WriteLine($" {ProductID[i]}.{ProductName[i]}");
                            }
                            int prodNum = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("What you need to update??please enter the number \n 1.Product Name \n 2.Product Size \n 3.Product price");
                            int update = Convert.ToInt32(Console.ReadLine());
                            if (update == 1)
                            {
                                for (int i = 0; i < ProductName.Length; i++)
                                {
                                    if (ProductID[i] == prodNum)
                                    {
                                        Console.WriteLine($"old name is {ProductName[i]}, please enter new name");
                                        ProductName[i] = Console.ReadLine();

                                    }
                                }
                            }
                            break;
                        #endregion

                        #region case3 Prod List
                        case 3:
                            for (int i = 0; i < ProductID.Length; i++)
                            {
                                Console.WriteLine($"{ProductName[i]} , {ProductPrice[i]}, {ProductQuantity[i]}");
                            }
                            #endregion
                            break;

                        #region case4 record sale
                        case 4:
                            saleRecord++;
                            Console.WriteLine("choose the product to Record sale by enter it is number");
                            for (int i = 0; i < ProductName.Length; i++)
                            {
                                Console.WriteLine($" {ProductID[i]}.{ProductName[i]}");
                            }
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("how many piece you saled?");
                             Qunt = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < ProductName.Length; i++)
                            {
                                if (ProductID[i] == id)
                                {
                                    
                                    ProductQuantity[i] = ProductQuantity[i] - Qunt;
                                    for (int j = 0; j < ProductSale.Length; j++)
                                    {
                                        ProductSale[j] = ProductID[i];
                                        QuantitySale[i] = Qunt;
                                    }

                                    Console.WriteLine($" sale record sucssefull {ProductName[i]} has {ProductQuantity[i]} pc left  ");
                                }
                            }
                            break;
                        #endregion
                        #region case5 display sale
                        case 5:
                           
                            Console.WriteLine("List of sale product");
                            for (int i = 0; i < ProductSale.Length; i++)
                            {
                                Console.WriteLine($" {ProductSale[i]}.{QuantitySale[i]}");
                            }
                            
                            break;
                        #endregion
                        #region case 6 salereport
                        case 6:
                            if (Qunt > 0)
                            {
                                Console.WriteLine("choose the product to see sale by enter it is number");
                                for (int i = 0; i < ProductName.Length; i++)
                                {
                                    Console.WriteLine($" {ProductID[i]}.{ProductName[i]}");
                                }
                                id = Convert.ToInt32(Console.ReadLine());

                                // int Qunt = Convert.ToInt32(Console.ReadLine());
                                for (int i = 0; i < ProductName.Length; i++)
                                {
                                    if (ProductID[i] == id)
                                    {
                                        //ProductQuantity[i] = ProductQuantity[i] - Qunt;

                                        Console.WriteLine($"sale record for {ProductName[i]} is {Qunt}  ");
                                    }
                                }
                            }
                            break;
                        #endregion
                        default:

                            break;
                    }
                    #endregion

                }
            
                else if (swit == 7)
                {
                    break;
                }
              
           
            }
           
        }
    }
}