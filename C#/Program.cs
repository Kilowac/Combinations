using System;
using System.IO;
using System.Diagnostics;
namespace Project2{
	///Read the Java files first, they are more explanitory than this.

	///General node class, same as the Java Node class, just translated over to C#. Compacted togeather to save file length, not supposed to be readable. Look at Java's for readablility
	class Node<T>{
		private T data;//The actual value it holds
		public int weight = 0, lDepth = 0, rDepth = 0;
		private Node<T> parent = null;
		private Node<T> left = null;//also prev
		private Node<T> right = null;//also next
		public Node(){ data = default(T); }
		public Node(T data){ this.data = data; }
		public Node(T data, Node<T> right){ this.data = data; this.right = right; }
		public Node(T data, Node<T> right, Node<T> left){ this.data = data; this.right = right; this.left = left; }
		public void setData(T data){ this.data = data; }
		public void setParent(Node<T> parent){ this.parent = parent; }
		public void setLeft(Node<T> left){ this.left = left; }
		public void setRight(Node<T> right){ this.right = right; }	
		public T getData(){ return data; }	
		public Node<T> getParent(){ return parent; }	
		public Node<T> getLeft(){ return left; }
		public Node<T> getRight(){ return right; }
	}

	///Queue
	class Queue<T>{
		private bool empty = true;
		private Node<T> end = new Node<T>();
		private Node<T> ptr;
		private Node<T> front;
		private T data;	
		public Queue(){	front = end; }
		public Queue(T data){ front = end; enqueue(data); }
		public void enqueue(T data){
			if(data == null) return;
			if(empty){
				front = new Node<T>(data);
				front.setRight(end);
				end.setLeft(front);
			} else {
				ptr = new Node<T>(data);
				end.getLeft().setRight(ptr);
				ptr.setRight(end);
				end.setLeft(ptr);
			}
			empty = false;
		}
		public T peek(){ return front.getData(); }
		public T dequeue(){
			if(empty) return default(T);
			data = front.getData();
			front = front.getRight();
			if(front.getData() == null){	
				front.setLeft(null);
				empty = true;
			}
			return data;
		}
		public bool isEmpty(){ return empty; }
	}
	
	///To the best of my knowledge the calculations (which is the one that's timed, not the setup or output) is a literal direct translation from Java, nothing is different.
	class Total{
		static int l = 0;
		public static StreamWriter output;
		static Stopwatch sw = new Stopwatch();
		static Queue<string> q = new Queue<string>();
		public static int FindTotal(int[] ary, int n, bool show){
			long time = 0;
			sw.Start();
			l = ary.Length;
			int[] index = new int[l];
			int limit = pow(2,l); int sum = 0; int count = 0;
			string str = "";
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
						if(count%10==0)
							q.enqueue(String.Format("\n{0,-24}",""));
						q.enqueue("{" + str + "\b} ");
					}
				}
				str = "";
				sum = 0;
			}	
			time = sw.ElapsedMilliseconds;
			while(!q.isEmpty())
				Console.Write(q.dequeue());
			if(show){Console.Write("\n");}
			Console.Write("Time(ms): {0}\n", time);
			sw.Reset();
			output.Write(time + "\n");
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
	
	///Read in data from, TestCase.txt, converted int arrays and print out the processed calculations.
	///Just like Java, the cdDat.txt is the timed data passed and used by Total.FindTotal();
	class Program{
		public static void Main(string[] args){
			string[] strs = System.IO.File.ReadAllLines(@"TestCase.txt");
			//for(int i = 0; i < strs.Length; i++){ Console.WriteLine(strs[i]); }
			bool show = true;
			string str = "";
			do{
				Console.Write("Would you like to print out all found combinations? (y/n)\n>>");
				str = Console.ReadLine().ToLower();
				if(str.Length == 0){
				} else if (str.Equals("y") || str.Equals("n")){
					show = !show;
				}	
			} while(show);
			show = str.Equals("y") ? true : false;
			int[] ary = new int[strs.Length];
			for(int i = 0; i < strs.Length; i++)
				ary[i] = Convert.ToInt32(strs[i]);
			int[] read; int hold;
			int sum; 
			StreamWriter output = new StreamWriter(@"./csDat.txt");
			Project2.Total.output = output;
			for(int i = 0; i < ary.Length;) {
				sum = ary[i];
				i++;
				read = new int[ary[i]];
				i++;
				for(int j = 0; j < read.Length; j++){
					read[j] = ary[i];
					i++;
				}
				Console.Write("Array: {0,-17}{1}","","[");
				foreach(int j in read){
					Console.Write("{0}, ", j);
				}
				Console.Write("\b\b]\nTotal to find: {0,-9}{1}\n","",sum);
				Console.Write(show ? String.Format("Combinations: {0,-10}","") : "");
				hold = Project2.Total.FindTotal(read, sum, show);
				Console.Write("Number of Combinations: {0}\n\n\n", hold);
				
			}
			output.Close();
		}

	}
}
