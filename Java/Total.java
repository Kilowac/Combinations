import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;
public class Total{
		/*
		 * l (L) is the argument array's length made as a global variable so the other methods can use it without having to add more parameters to their methods
		 * Queue stores the strings of the correct combinations and are dequeued and printed after the calculations; they are not printed during calculations because it will interfere with nanoTime()
		 * pow, is a method to find the product of a number to a given power, and is used to determine when to stop the binary calculations, since there will only be 2^l (L) number of combinations.
		 * this method is written explicitly because the standard library in C#'s power funciton might be different than java's and I wanted these programs to be almost a direct translation of eachother.
		 * binary is used to calculate the binary of a number and store them in an array of 'l' length. Used to find all combinations of the ary argument.
		 * The output strings are formatted and the nanoTime() result is then converted to ms because C#'s stopwatch is timed in ms; used for comparison.
		 * PrintWriter is a global variable so Total can write the times and array length to javaDat.txt (used for writing to a spreadsheet) without having to instance it multiple times; pased from the testing program (Main.java).
		 */
		static int l = 0;
		static Queue<String> q = new Queue<String>();
		public static int FindTotal(int[] ary, int n, boolean show) throws IOException {
			long start = 0, stop = 0, overhead = 0;
			start = System.nanoTime(); stop = System.nanoTime(); overhead = stop - start;
			start = System.nanoTime();
			l = ary.length;
			int[] index = new int[l];
			int limit = pow(2,l); int sum = 0; int count = 0;
			String str = "";
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
						if(count%10==0)//any system call output are to be put in a queue and printed after timed
							q.enqueue(String.format("\n%-24s",""));
						q.enqueue("{" + str + "\b} ");
					}
				}
				str = "";
				sum = 0;
			}
			stop = System.nanoTime();
			while(!q.isEmpty())
				System.out.print(q.dequeue());
			if(show){ System.out.print("\n");}
			stop = (stop-start-overhead)/1000000;
			System.out.printf("Time(ms): %d\n", stop);
			return count;
		}

		public static int[] binary(int n){
			int[] ary = new int[l];
			for(int i = l-1; n!= 0; i--){
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
