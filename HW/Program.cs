using System;

namespace HW
{
    class Program
    {
        public static int sum = 0;
        public static int MaxSum = 0;


        static void Main(string[] args)
        {
            BinTreeNode<int> e = new BinTreeNode<int>(6);
            BinTreeNode<int> d = new BinTreeNode<int>(3);
            BinTreeNode<int> c = new BinTreeNode<int>(d, 1, e);
            BinTreeNode<int> f = new BinTreeNode<int>(5);
            BinTreeNode<int> g = new BinTreeNode<int>(4);
            BinTreeNode<int> b = new BinTreeNode<int>(g,9,f);
            BinTreeNode<int> a = new BinTreeNode<int>(b, 2, c); //root

            // Page 1

            Console.WriteLine(CheckNode(5,a)); // Ex.2
            Console.WriteLine(AmountOfVertices(a)); // Ex.3
            Console.WriteLine(Sum_Values(a)); // Ex.4
            Console.WriteLine(AmountOfLeaves(a));//Ex.5
            Console.WriteLine(AmountOfTwoSons(a));//Ex.6
            Console.WriteLine(AmountOfSingleSons(a));//Ex.7
            Console.WriteLine(WholeTree(a)); //8

            Console.WriteLine();

            // Page 2

            DevideEven(a);
            Console.WriteLine(SumOfEven(a));
            AddBrother(a);
            Console.WriteLine(SumOfRightSons(a));
            //Console.WriteLine(Father(a,2));
            Console.WriteLine(EvenTree(a));
            Console.WriteLine(Halciuho(a));
            Console.WriteLine(MaxLeafToRoot(a));


        }

        #region Page1
        public static bool CheckNode(int num, BinTreeNode<int> S)
        {
            if (S == null)
                return false;
            if (S.GetValue() == num)
                return true;
            return CheckNode(num, S.GetLeft()) || CheckNode(num, S.GetRight());
        }

        public static int AmountOfVertices(BinTreeNode<int> S)
        {
            if (S == null)
                return 0;
            return 1 + AmountOfVertices(S.GetLeft()) + AmountOfVertices(S.GetRight());
        }

        public static int Sum_Values(BinTreeNode<int> S)
        {
            if (S == null)
                return 0;
            return S.GetValue() + Sum_Values(S.GetLeft()) + Sum_Values(S.GetRight());
        }

        public static int AmountOfLeaves(BinTreeNode<int> S)
        {
            if (S == null)
                return 0;
            if (S.GetLeft() == null && S.GetRight() == null)
                return 1;
            return AmountOfLeaves(S.GetLeft()) + AmountOfLeaves(S.GetRight());
        }

        public static int AmountOfTwoSons(BinTreeNode<int> S)
        {
            if (S == null)
                return 0;
            if (S.GetLeft() != null && S.GetRight() != null)
                return 1 + AmountOfTwoSons(S.GetLeft()) + AmountOfTwoSons(S.GetRight()); ;
            return  AmountOfTwoSons(S.GetLeft()) + AmountOfTwoSons(S.GetRight());
        }

        public static int AmountOfSingleSons(BinTreeNode<int> S)
        {
            if (S == null)
                return 0;
            if (S.GetLeft() != null && S.GetRight() == null || S.GetLeft() == null && S.GetRight() != null)
                return 1;
            return AmountOfSingleSons(S.GetLeft()) + AmountOfSingleSons(S.GetRight());
        }

        public static bool WholeTree(BinTreeNode<int> S)
        {
            if (S == null)
                return false;
            if (S.GetLeft() == null && S.GetRight() != null || S.GetLeft() != null && S.GetRight() == null)
                return false;
            return WholeTree(S.GetLeft()) && WholeTree(S.GetRight());
        }
        #endregion

        #region Page2
        
        public static void DevideEven(BinTreeNode<int> S)
        {
            if (S != null)
            {
                if (S.GetValue() % 2 == 0)
                    S.SetValue(S.GetValue() / 2);
                DevideEven(S.GetLeft());
                DevideEven(S.GetRight());
            }
        }

        public static void AddBrother(BinTreeNode<int> S)
        {
            if(S.GetLeft() != null && S.GetRight() != null)
            {
                if(S.GetLeft() == null)
                {
                    BinTreeNode<int> LeftB = new BinTreeNode<int>(0);
                    S.SetLeft(LeftB);
                }
                if (S.GetRight() == null)
                {
                    BinTreeNode<int> RightB = new BinTreeNode<int>(0);
                    S.SetLeft(RightB);
                }
                AddBrother(S.GetLeft());
                AddBrother(S.GetRight());
            }
        }

        public static int SumOfEven(BinTreeNode<int> S)
        {
            if (S == null)
                return 0;
            if (S.GetValue() % 2 == 0)
                return 1 + SumOfEven(S.GetLeft()) + SumOfEven(S.GetRight());
            return  SumOfEven(S.GetLeft()) + SumOfEven(S.GetRight()) ;
        }
        public static int SumOfRightSons(BinTreeNode<int> S)
        {
            if (S == null)
                return 0;
            if (S.GetRight() != null)
                return S.GetRight().GetValue() + SumOfRightSons(S.GetLeft()) + SumOfRightSons(S.GetRight());
            return SumOfRightSons(S.GetLeft()) + SumOfRightSons(S.GetRight());
        }
        //public static BinTreeNode<int> Father(BinTreeNode<int> S, int num)
        //{
        //    if (S == null)
        //        return null;
        //    if (S.GetRight() != null)
        //    {
        //        if (S.GetRight().GetValue() == num)
        //            return S;
        //    }
        //    if (S.GetLeft() != null)
        //    {
        //        if (S.GetLeft().GetValue() == num)
        //            return S;
        //    }
        //    return Father(S.GetLeft(), num) +  Father(S.GetRight(), num);
        //}
        public static bool EvenTree(BinTreeNode<int> S)
        {
            if (S == null)
                return true;
            if (S.GetValue() % 2 != 0)
                return false;
            return EvenTree(S.GetLeft()) && EvenTree(S.GetRight());
        }
        public static bool Halciuho(BinTreeNode<int> S)
        {
            if (S == null)
                return true;
            if (AmountOfSingleSons(S) > 0)
                return false;
            if(S.GetRight() != null && S.GetLeft() != null)
            {
                if (S.GetLeft().GetValue() % S.GetRight().GetValue() != 0 || S.GetLeft().GetValue() / S.GetRight().GetValue() != S.GetValue())
                    return false;
            }
            return Halciuho(S.GetLeft()) && Halciuho(S.GetRight());
        }
        public static int MaxLeafToRoot(BinTreeNode<int> S)
        {
            if (S == null)
                return 0;
                sum += S.GetValue();
                if (sum > MaxSum && S.GetLeft() == null && S.GetRight() == null)
                    MaxSum = sum;
            if (MaxLeafToRoot(S.GetLeft()) > MaxLeafToRoot(S.GetRight()))
                return MaxLeafToRoot(S.GetLeft());
            else
                return MaxLeafToRoot(S.GetRight());

        }
        public static int Path(BinTreeNode<int> s)
        {
            if (s != null)
            {
                if (s.GetLeft() == null && s.GetRight() == null)
                    return 0;
                if (s.GetLeft() != null && s.GetRight() != null)
                    return Math.Max(Path(s.GetRight()), Path(s.GetLeft())) + s.GetValue();
                if (s.GetLeft() != null)
                    return Path(s.GetLeft()) + s.GetValue();
                if (s.GetRight() != null)
                    return Path(s.GetRight()) + s.GetValue();
            }
        }
        public static void Leaves(BinTreeNode<int> bt, Stack<BinTreeNode<int>> s)
        {
            if(bt != null)
            {
                if (bt.GetLeft() == null && bt.GetRight() == null)
                    s.Push(bt);
                Leaves(bt.GetLeft(), s);
                Leaves(bt.GetRight(), s);
            }
        }
        #endregion
    }
}