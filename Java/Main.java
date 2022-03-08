import java.io.File;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Scanner;
public class Main{
	/*
	 * TestCase.txt is the data being used for the array parameters.
	 * Main.java is used for formatting instructions for the user, outputs of the calculations, and reading data from TestCase.txt and convering them to an int array and passing them to Total.FindTotal().
	 */
	public static void main(String[] args) throws IOException{
		File inFile = new File("TestCase.txt");
		Scanner input = new Scanner(inFile);
		Scanner user = new Scanner(System.in);
		String str = "";
		boolean show = true;
		do{
			System.out.print("Would you like to print out all found combinations? (y/n)\n>>");
			str = user.nextLine().toLowerCase();
			if(str.length() == 0){
			} else if(str.equals("y") || str.equals("n")){
				show = !show;
			}
		} while(show);
		show = str.equals("y") ? true : false;
		int sum; int hold;
		int[] ary;
		while(input.hasNext()){
			sum = input.nextInt();
			ary = new int[input.nextInt()];
			for(int i = 0; i < ary.length; i++){
				ary[i] = input.nextInt();
			}
			System.out.printf("Array: %-17s%s","","[");
			for(int i : ary){
				System.out.printf("%d, ",i);
			}
			System.out.printf("\b\b]\nTotal to find: %-9s%d\n","",sum);
			System.out.printf(show ? String.format("Combinations: %-10s","") : "");
			hold = Total.FindTotal(ary, sum, show);
			System.out.printf("Number of Combinations: %d\n\n\n", hold);
		}
	}
}
