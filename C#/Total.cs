using System;
namespace Project2{
	class Total{
		static int l = 0;
		public static int FindTotal(int[] ary, int n, bool show){
			l = ary.Length;
			int[] index = new int[l];
			int limit = pow(2,l); int sum = 0; int count = 0;
			string str = "";
			Console.Write("Combinations: {0,-10}","");
			if(!show){ Console.Write("N/A\n"); }
			for(int i = 0; i < limit; i++){
				index = binary(i);
				for(int j = 0; j < l; j++){
					if(index[j] == 1){
						sum += ary[j];
						str += ary[j] + ",";
					}
				}
				if(sum == n){
					count++;
					if(show){
						if(count%16==0)
							Console.Write("\n{0,-24}","");
						Console.Write("{{0}\b}", str);
					}
				}
				str = "";
				sum = 0;
			}
			Console.Write("\n");
			return count;
		}

		private static int[] binary(int n){
			int[] ary = new int[l];
			for(int i = l-1; n != 0; i--){
				ary[i] = n%2;
				n /= 2;
			}
			return ary;
		}
		public static int pow(int b, int p){
			int n = 1;
			for(int i = 1; i <= p; i++)
				n *= b;
			return n;
		}
	}
}
