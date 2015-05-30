//
// nome do programa: EX_6_1.java
//
// programadores: nome dos alunos
// Mateus Fernando          484555
// Vinicius Ponciano        482955
// Yitzhak Stone            478493
// data: 30/04/2015
// descricao:
/**
* Esse programa cria um thread separado implementando a interface
* Runnable.
*
* Figura 4.11
*
* @author Gagne, Galvin, Silberschatz
* Fundamentos de Sistemas Operacionais - Oitava Edição
* Copyright John Wiley e Sons - 2011.
*/
class Sum
{
	private int sum;
	public int get() {
		return sum;
	}
	public void set(int sum) {
		this.sum = sum;
	}
}

class Summation implements Runnable
{
	private int upper;
	private Sum sumValue;

	public Summation(int upper, Sum sumValue) {
		if (upper < 0)
		throw new IllegalArgumentException();
		this.upper = upper;
		this.sumValue = sumValue;
	}

	public void run() {
		int sum = 0;
		for (int i = 0; i <= upper; i++)
		sum += i;
		sumValue.set(sum);
	}
}

public class EX_6_2
{
	public static void main(String[] args) {
		
        System.out.println("484555\t\tMateus Fernando");
        System.out.println("482955\t\tVinicius Ponciano");
        System.out.println("478493\t\tYitzhak Stone");
        System.out.println();

		if (args.length != 1) {
			System.err.println("Usage EX_6_2 <integer>");
			System.exit(0);
		}

		Sum sumObject = new Sum();
		int upper = Integer.parseInt(args[0]);
		Thread worker = new Thread(new Summation(upper, sumObject));
		worker.start();
		
		try {
			worker.join();
		} catch (InterruptedException ie) { }

		System.out.println("The sum of " + upper + " is " +
		sumObject.get());
	}
}