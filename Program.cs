using System;

namespace Lab4 // Реализовать для классов, созданных при выполнении лабораторной работы 2, механизм интерфейсов.
					// Использовать стандартные интерфейсы IComparable и IComparer для выполнения сортировки объектов по различным полям.

{
	interface IProgramm
	{
		void print();
		void scan();
		void Square();
		void Volume();
		int CountWindow { get; set; }
		string Name { get; set; }
	}

	class Room : IProgramm, IComparable
	{
		string name;
		double length;
		double width;
		double high;
		int countWindow;

		public Room()
		{
			Name = "Kitchen";
			Length = 1.0;
			Width = 1.0;
			High = 1.0;
			CountWindow = 1;
		}
		public Room(string name, double length, double width, double high, int countWindow)
		{
			this.Name = name;
			this.Length = length;
			this.Width = width;
			this.High = high;
			this.CountWindow = countWindow;
		}

		public void print()
		{
			Console.WriteLine($"\nИмя комнаты: {Name} Длина комнаты: {Length}, ширина: {Width}, высота: {High}, количество окон: {CountWindow}.\n");
		}

		public void scan()
		{
			Console.Write("\nВведите имя комнаты: ");
			this.Name = Console.ReadLine()!;

			Console.Write("\nВведите длину команты: ");
			this.Length = Double.Parse(Console.ReadLine()!);

			Console.Write("Введите ширину команты: ");
			this.Width = Double.Parse(Console.ReadLine()!);

			Console.Write("Введите высоту комнаты: ");
			this.High = Double.Parse(Console.ReadLine()!);

			Console.Write("Введите количество окон в комнате: ");
			this.CountWindow = Int32.Parse(Console.ReadLine()!);
		}

		public void Square()
		{
			Console.WriteLine($"Площадь комнаты: {Length * Width}.\n");
		}
		public void Volume()
		{
			Console.WriteLine($"Объем комнаты: {Length * Width * High}.\n");
		}
		public string Name
		{
			set
			{
				// if (value != "")
				//    Console.WriteLine("Значение не может быть пустым!\n");
				// else
				name = value;
			}
			get { return name; }
		}
		protected double Length
		{
			set
			{
				if (value < 1)
					Console.WriteLine("Значение не может быть отрицательным!\n");
				else
					length = value;
			}
			get { return length; }
		}
		protected double Width
		{
			set
			{
				if (value < 1)
					Console.WriteLine("Значение не может быть отрицательным!\n");
				else
					width = value;
			}
			get { return width; }
		}
		protected double High
		{
			set
			{
				if (value < 1)
					Console.WriteLine("Значение не может быть отрицательным!\n");
				else
					high = value;
			}
			get { return high; }
		}
		public int CountWindow
		{
			set
			{
				if (value < 1)
					Console.WriteLine("Значение не может быть отрицательным!\n");
				else
					countWindow = value;
			}
			get { return countWindow; }
		}

		int IComparable.CompareTo(object o)
		{
			IProgramm temp = (IProgramm)o;
			if (this.CountWindow > temp.CountWindow)
				return 1;
			if (this.CountWindow < temp.CountWindow)
				return -1;
			else
				return 0;
		}

		private class SortByNameHelper : System.Collections.Generic.IComparer<Room>
		{
			public SortByNameHelper() { }
			int System.Collections.Generic.IComparer<Room>.Compare(Room o1, Room o2)
			{
				Room t1 = o1;
				Room t2 = o2;
				return String.Compare(t1.Name, t2.Name);
			}
		}

		public static System.Collections.Generic.IComparer<Room> SortByName
		{ get { return new SortByNameHelper(); } }

		static void Main(string[] args)
		{
			Console.Clear();
			Console.Write("\nЦель данной программы заполнение данных о комнатах с последующим их выводом на экран,");
			Console.Write("а так же вычисление площади и объёма комнат.\n");
			int option = 0;
			while (option != 10)
			{
				Console.Write("\n1. Старт;\n10. ВЫХОД.\nВвод: ");
				option = Convert.ToInt32(Console.ReadLine()!);
				switch (option)
				{
					case 1:
						{
							Console.Write("\nВведите количество комнат: ");
							int RoomsCount = Int32.Parse(Console.ReadLine()!);
							var AI = new Room[RoomsCount];

							for (int i = 0; i < RoomsCount; i++)
							{
								AI[i] = new Room();
								AI[i].scan();
							}
							for (int i = 0; i < RoomsCount; i++)
							{
								Console.WriteLine("\nКомната №" + (i + 1));
								AI[i].print();
								AI[i].Square();
								AI[i].Volume();
							}
							Console.WriteLine("\nПосле сортировки: ");
							Array.Sort(AI);
							for (int i = 0; i < RoomsCount; i++)
							{
								Console.WriteLine("\nКомната №" + (i + 1));
								AI[i].print();
							}
							Console.WriteLine("\nПосле сортировки по окнам: ");
							Array.Sort(AI, SortByName);
							for (int i = 0; i < RoomsCount; i++)
							{
								Console.WriteLine("\nКомната №" + (i + 1));
								AI[i].print();
							}
						}
						break;
					case 10:
						{
							//exit
							break;
						}
					default:
						{
							Console.WriteLine("\nВведено неверное число.\nВведите число 1 или 10.");
							break;
						}
				}
			}
		}
	}
}
