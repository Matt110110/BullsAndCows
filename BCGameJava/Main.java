package game;
import java.util.*;
public class Main {
	
			
	
	public static void main(String[] args) {
		
		Word obj=new Word();
		Bully ob=new Bully();
		boolean guessed=false;
		int guesses=0;
		do {
			printIntro();
		ob.dic();
		int max_tries=ob.target.length()-1;
		
		do {
			
			int cows=0,bulls=0;
			
		
		System.out.println("Enter a "+ob.target.length()+ " lettered isogram");
	
		obj.getWord();
		
		
		
		if(obj.checkIsogram()==true) {
		
		if(obj.word.length()==ob.target.length()) {
		
		for(int i=0;i<obj.word.length();i++) {
			for(int j=0;j<obj.word.length();j++) {
				int asci_word=obj.word.charAt(i);
				int asci_target=ob.target.charAt(j);
				
				if(asci_word==asci_target ||asci_target==asci_word+32)
				{
					if(i==j)
						bulls++;
					else 
						cows++;
				}
			}
		}
		}
		else {
			System.out.println("Count your letters dearie!Let's start again shall we?");
			break;
		}
		
		if(bulls==ob.target.length()) {
			System.out.println("Bulls:"+bulls+" Cows:"+cows);
			guessed=true;}
		else {guesses++;

		
			System.out.println("Bulls:"+bulls+" Cows:"+cows);
		System.out.println("You have "+(max_tries-guesses)+" guesses remaining");
		
		}
		}
		else {
			System.out.println("In an isogram letters do not repeat ");
			System.out.println("Try again");}
		}while(!guessed && guesses<max_tries);
		if(guessed==true && guesses<max_tries)
			System.out.println("You Won!");
		else if(guessed==false && guesses==max_tries)
			System.out.println("You Lost!");
		guesses=0;guessed=false;
		}while(playAgain()==true);
		
		
		
		
		
	
			
		
		
	}
	public static boolean playAgain() {
		Scanner sc=new Scanner(System.in);
		System.out.println("Want to play again?Enter y or n");
		String answer=sc.next();
		
		if(answer.equals("y") || answer.equals("Y"))
		return true;
		else { 
			System.out.print("Okay then!BaBye");
			
			return false;}
		
				
	}
	public static void printIntro() {
		System.out.println("Welcome to Bulls and Cows");
		System.out.println("             }    {               _//___\\");
		System.out.println("             (o  o)               (o  o) ");
		System.out.println("    /--------\\  /                  \\  /--------\\");
		System.out.println("   / |        |O                     o|         |\\ ");
		System.out.println("  *  |-,------|                       |-------,,|  * ");
		System.out.println("     ^        ^                       ^         ^  ");
		System.out.println("Can you think of an isogram I'm thinking of?");
		System.out.println("Let's get started!");
	}
	
} 
	
	
	
		
	


