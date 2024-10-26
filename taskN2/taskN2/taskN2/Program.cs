using System;

class Program
{
    static void Main()
    {
        // 1) შექმენით კონსოლური აპლიკაცია, რომელიც შეასრულებს მარტივ არითმეტიკულ ოპერაციებს რიცხვებზე.
        // *გამოაცხადეთ ორი ცვლადი
        //*შეასრულეთ მიმატების, გამოკლების, გამრავლების, გაყოფისა და ნაშთის ოპერაციები.
        // *შედეგები დაბეჭდეთ კონსოლში

        Console.WriteLine("Num1:");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Num2:");
        int num2 = Convert.ToInt32(Console.ReadLine());

        int sum = num1 + num2;
        int difference = num1 - num2;
        int product = num1 * num2;
        double quotient = (double)num1 / num2;
        int remainder = num1 % num2;


        Console.WriteLine("shekreba: " + sum);
        Console.WriteLine("gamokleba: " + difference);
        Console.WriteLine("gamravleba: " + product);
        Console.WriteLine("gayofa: " + quotient);
        Console.WriteLine("nashti: " + remainder);


        // 2) წარმოაჩინეთ float, double და decimal შორის სიზუსტის სხვაობა:
        //*შექმენით სამი ცვლადი float, double და decimal ტიპებით. თითოეულს მიანიჭეთ მნიშვნელობად 1.0 / 7.0 ზე
        //* თითოეული ცვლადი გაამრავლეთ 7 ზე
        //* დაბეჭდეთ თითოეული შედეგი და შეადარეთ

        float a1 = (float)(1.0 / 7.0);
        double a2 = 1.0 / 7.0;
        decimal a3 = (decimal)(1.0 / 7.0);

        Console.WriteLine(a1 * 7);
        Console.WriteLine(a2 * 7);
        Console.WriteLine(a3 * 7);

        //3) გადაიყვანეთ სხვადასხვა მონაცემთა ტიპები განსხვავებულ ტიპებში
        //*გამოაცხადეთ int, double, float და decimal ტიპის ცვლადები
        //* მიანიჭეთ თითეულ მათგანს მნიშვნელობები
        //* შეასრულეთ explicit და implicit კონვერტაციებით ამ ტიპებს შორის(სადაც რომელია შესაძლებელი)

        int b1 = 5;
        double b2 = 2.5;
        float b3 = 2 / 7;
        decimal b4 = 1 / 3;


        int c1 = (int)b2;
        int c2 = (int)b3;
        int c3 = (int)b4;

        double d1 = b1;
        double d2 = b3;
        double d3 = (double)b4;

        float e1 = b1;
        float e2 = (float)b2;
        float e3 = (float)b4;

        decimal f1 = b1;
        decimal f2 = (decimal)b2;
        decimal f3 = (decimal)b3;

        Console.WriteLine(c1);
        Console.WriteLine(c2);
        Console.WriteLine(c3);
        Console.WriteLine(d1);
        Console.WriteLine(d2);
        Console.WriteLine(d3);
        Console.WriteLine(e1);
        Console.WriteLine(e2);
        Console.WriteLine(e3);
        Console.WriteLine(f1);
        Console.WriteLine(f2);
        Console.WriteLine(f3);


        // 4) შექმენით კონსოლური აპლიკაცია, როკმელიც ორ ცვლადს მნიშვნელობას გაუცვლის.
        //მაგ.:
        //before:
        //int x = 5;
        //int b = 10;

        //after:
        //int x = 10;
        //int b = 5;

        int x = 5;
        int y = 10;

        Console.WriteLine("Before:");
        Console.WriteLine("x = " + x);
        Console.WriteLine("y = " + y);

        int z = x;
        x = y;
        y = z;

        Console.WriteLine("After:");
        Console.WriteLine("x = " + x);
        Console.WriteLine("y = " + y);


        Console.ReadLine();


        //5) შექმენით კონსოლური აპლიკაცია, რომელიც დაითვლის BMI(Body Mass Index) მნიშვნელობას და ამის შესაბამისად დაბეჭდავს რჩევებს.
        //*შემოატანინეთ მომხმარებელს კონსოლიდან ინფორმაცია - სიმაღლე და წონა(https://www.geeksforgeeks.org/console-readline-method-in-c-sharp/)
        //*დაითვალეთ BMI https://en.wikipedia.org/wiki/Body_mass_index
        //*მიღებული შედეგების მიხედვით დაბეჭდეთ სხვადასხვა რჩევები


        float height;
        float weight;

        Console.WriteLine("Enter your height: ");

        height = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter your weight: ");

        weight = Convert.ToInt32(Console.ReadLine());

        float BMI = weight / (height * height);

        if (BMI <= 18.5)
        {
            Console.WriteLine("თქვენ წონა" + weight + "არ შეესაბამება თქვენს სიმაღლე" + height + "გირჩევთ მოუმატოთ ჭამას");
        }
        else if (BMI <= 24.9)
        {
            Console.WriteLine("თქვენ წონა" + weight + "და სიმაღლე" + height + "შესაბამისობაშია, ასე გააგრძელეთ");

        }
        else if (BMI > 24.9)
        {
            Console.WriteLine("თქვენ წონა" + weight + "არ შეესაბამება თქვენს სიმაღლე" + height + "გირჩევთ დაიცვათ დიეტა");

        }


    }



}