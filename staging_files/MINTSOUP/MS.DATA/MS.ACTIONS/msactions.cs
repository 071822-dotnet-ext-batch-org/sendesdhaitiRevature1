using System;
using MS.MODELS;
using System.Reflection;
using System.Drawing;
//using MS.REPO.ACTIONS;

namespace MS.ACTIONS
{
    public interface Imsactions
    {
        object CONVERT_INT_TO_ENUM_STATUS(int membership, dynamic statuses);
    }

    public class msactions : Imsactions
    {
        private static Statuses.Role role;
        private static Statuses.ViewerMembership membership;
        private static Statuses.StoreStatus storestatus;
        private static Statuses.Privacylevel storeprivacylevel;
        private static Statuses.ClientStatus clientstatus;
        private static Statuses.LikeStatus likestatus;
        private static Statuses.OrderStatus orderstatus;
        private static Statuses.ProductStatus productstatus;
        private static Statuses.ProductType producttype;

        private static Statuses.Privacylevel GetStoreprivacylevel()
        {
            return storeprivacylevel;
        }

        private static void SetStoreprivacylevel(Statuses.Privacylevel value)
        {
            storeprivacylevel = value;
        }

        private static Statuses.ProductType GetProducttype()
        {
            return producttype;
        }

        private static void SetProducttype(Statuses.ProductType value)
        {
            producttype = value;
        }

        private static Statuses.ProductStatus GetProductstatus()
        {
            return productstatus;
        }

        private static void SetProductstatus(Statuses.ProductStatus value)
        {
            productstatus = value;
        }

        private static Statuses.OrderStatus GetOrderstatus()
        {
            return orderstatus;
        }

        private static void SetOrderstatus(Statuses.OrderStatus value)
        {
            orderstatus = value;
        }

        private static Statuses.LikeStatus GetLikestatus()
        {
            return likestatus;
        }

        private static void SetLikestatus(Statuses.LikeStatus value)
        {
            likestatus = value;
        }

        private static Statuses.ClientStatus GetClientstatus()
        {
            return clientstatus;
        }

        private static void SetClientstatus(Statuses.ClientStatus value)
        {
            clientstatus = value;
        }

        private static Statuses.StoreStatus GetStorestatus()
        {
            return storestatus;
        }

        private static void SetStorestatus(Statuses.StoreStatus value)
        {
            storestatus = value;
        }

        private static Statuses.ViewerMembership GetMembership()
        {
            return membership;
        }

        private static void SetMembership(Statuses.ViewerMembership value)
        {
            membership = value;
        }

        private static Statuses.Role GetRole()
        {
            return role;
        }

        private static void SetRole(Statuses.Role value)
        {
            role = value;
        }



        //------------------------OPERATIONS SECTION---------------------------
        public msactions()
        {
        }
        public static Statuses.Role ConvertINTRole_To_PersonsRole(int role)
        {

            if (role == 0) { SetRole(Statuses.Role.Viewer); }
            else SetRole(Statuses.Role.Admin);
            return GetRole();

        }
        public static Statuses.ViewerMembership ConvertINTStatus_To_PersonsMembershipStatus(int membership)
        {
            if (membership == 0)
            {
                SetMembership(Statuses.ViewerMembership.Free);
            }
            else if (membership == 1)
            {
                SetMembership(Statuses.ViewerMembership.Premium);
            }
            else if (membership == 2)
            {
                SetMembership(Statuses.ViewerMembership.Exclusive);
            }
            else if (membership == 3)
            {
                SetMembership(Statuses.ViewerMembership.Platinum);
            }
            else
            {
                SetMembership(Statuses.ViewerMembership.Free);
            }
            return GetMembership();
        }

        public object CONVERT_INT_TO_ENUM_STATUS(int membership, dynamic statuses)
        {
            var res = typeof(Statuses).GetNestedType(statuses.ToString() ?? "Statuses", BindingFlags.NonPublic);
            if(res != null && res.IsEnum)
            {
                if(res == typeof(Statuses.ClientStatus))
                {
                    foreach (int i in Enum.GetValues(typeof(Statuses.ClientStatus)))
                    {
                        Console.WriteLine($" {Enum.GetName(typeof(Statuses.ClientStatus), i)}");
                        if (i == membership)
                        {
                            SetClientstatus((Statuses.ClientStatus)membership);
                            break;
                        }
                    }

                    return GetClientstatus();
                }
                else if (res == typeof(Statuses.LikeStatus))
                {
                    foreach (int i in Enum.GetValues(typeof(Statuses.LikeStatus)))
                    {
                        Console.WriteLine($" {Enum.GetName(typeof(Statuses.LikeStatus), i)}");
                        if (i == membership)
                        {
                            SetLikestatus((Statuses.LikeStatus)membership);
                            break;
                        }
                    }

                    return GetLikestatus();
                }
                else if (res == typeof(Statuses.OrderStatus))
                {
                    foreach (int i in Enum.GetValues(typeof(Statuses.OrderStatus)))
                    {
                        Console.WriteLine($" {Enum.GetName(typeof(Statuses.OrderStatus), i)}");
                        if (i == membership)
                        {
                            SetOrderstatus((Statuses.OrderStatus)membership);
                            break;
                        }
                    }

                    return GetOrderstatus();
                }
                else if (res == typeof(Statuses.Privacylevel))
                {
                    foreach (int i in Enum.GetValues(typeof(Statuses.Privacylevel)))
                    {
                        Console.WriteLine($" {Enum.GetName(typeof(Statuses.Privacylevel), i)}");
                        if (i == membership)
                        {
                            SetStoreprivacylevel((Statuses.Privacylevel)membership);
                            break;
                        }
                    }

                    return GetStoreprivacylevel();
                }
                else if (res == typeof(Statuses.ProductStatus))
                {
                    foreach (int i in Enum.GetValues(typeof(Statuses.ProductStatus)))
                    {
                        Console.WriteLine($" {Enum.GetName(typeof(Statuses.ProductStatus), i)}");
                        if (i == membership)
                        {
                            SetProductstatus((Statuses.ProductStatus)membership);
                            break;
                        }
                    }

                    return GetProductstatus();
                }
                else if (res == typeof(Statuses.ProductType))
                {
                    foreach (int i in Enum.GetValues(typeof(Statuses.ProductType)))
                    {
                        Console.WriteLine($" {Enum.GetName(typeof(Statuses.ProductType), i)}");
                        if (i == membership)
                        {
                            SetProducttype((Statuses.ProductType)membership);
                            break;
                        }
                    }

                    return GetProducttype();
                }
                else if (res == typeof(Statuses.Role))
                {
                    foreach (int i in Enum.GetValues(typeof(Statuses.Role)))
                    {
                        Console.WriteLine($" {Enum.GetName(typeof(Statuses.Role), i)}");
                        if (i == membership)
                        {
                            SetRole((Statuses.Role)membership);
                            break;
                        }
                    }

                    return GetRole();
                }
                else if (res == typeof(Statuses.StoreStatus))
                {
                    foreach (int i in Enum.GetValues(typeof(Statuses.StoreStatus)))
                    {
                        Console.WriteLine($" {Enum.GetName(typeof(Statuses.StoreStatus), i)}");
                        if (i == membership)
                        {
                            SetStorestatus((Statuses.StoreStatus)membership);
                            break;
                        }
                    }

                    return GetStorestatus();
                }
                else if (res == typeof(Statuses.ViewerMembership))
                {
                    foreach (int i in Enum.GetValues(typeof(Statuses.ViewerMembership)))
                    {
                        Console.WriteLine($" {Enum.GetName(typeof(Statuses.ViewerMembership), i)}");
                        if (i == membership)
                        {
                            SetMembership((Statuses.ViewerMembership)membership);
                            break;
                        }
                    }

                    return GetMembership();
                }
                
            }
            return 0;
        }


    }
}

