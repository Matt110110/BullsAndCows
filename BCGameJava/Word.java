package game;
import java.util.*;

public class Word {
	String word;
	
	
	
	Scanner sc=new Scanner(System.in);
	public String getWord() {

		word=sc.next();
		
		
		return word;		
		
	}
	public boolean checkIsogram(){
		
		int a=0;
	
		for(int i=0;i<word.length()-1;i++) {
			for(int j=i+1;j<word.length();j++) {
				if(word.charAt(i)==word.charAt(j))
					a++;
				
							
			}
		}
		if(a>0)
			return false;
		else return true;
		
	}
	

}
