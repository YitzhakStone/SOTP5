//
// nome do programa: EX_6_3.java
//
// programadores: 
// Mateus Fernando          484555
// Vinicius Ponciano        482955
// Yitzhak Stone            478493
// data: 30/04/2015
// descricao: resolução do problema de produtor/consumidor
// são criados vários produtores/consumidores (um para cada integrante do grupo).
// 

class Produtor extends Thread {
	private Buffer buf;
	private int numero;
	private String produzir;

	public Produtor(Buffer buf, int numero, String produzir) {
		this.buf= buf; 
		this.numero = numero;
		this.produzir = produzir;
	}

	public void run() {
		char[] arr = this.produzir.toCharArray();
		for (int i = 0; i < produzir.length(); i++) { // armazena 10 valores no buffer
			
			buf.put(arr[i]);
			
			System.out.println("Produtor #" + numero + " put: " + arr[i]);

			try {
				sleep((int)(Math.random() * 100));
			}
			catch (InterruptedException e) { }
		}
	}
}

class Consumidor extends Thread {
	private Buffer buf;
	private int numero;
	private int size;

	public Consumidor(Buffer buf, int numero, int size) {
		this.buf= buf; 
		this.numero = numero;
		this.size = size;
	}

	public void run() { // retira 10 valores do buffer
		char x;
		for (int i = 0; i < size; i++) {
			x = buf.get();
			System.out.println("Consumidor #"+ numero + " get: " + x);
		}
	}
}

class Buffer {
	private char valor;
	private boolean cheio= false;
	
	public synchronized char get() {
		while (!cheio) {
			try {
				wait();
			}
			catch (InterruptedException e)
			{ }
		}
		cheio = false;
		notifyAll();
		System.out.println("get " + valor);
		return valor;
	}

	public synchronized void put(char valor) {
		while (cheio) {
			try {
				wait();
			}
			catch (InterruptedException e)
			{ }
		}
		this.valor= valor;
		cheio = true;
		System.out.println("put " + valor);
		notifyAll();
	}
}

public class EX_6_3 {
	public static void main (String [] args) {
        System.out.println("484555\t\tMateus Fernando");
        System.out.println("482955\t\tVinicius Ponciano");
        System.out.println("478493\t\tYitzhak Stone");
        System.out.println();

		String[] produzir = new String[] {
			"484555 Mateus Fernando",
			"482955 Vinicius Ponciano",
			"478493 Yitzhak Stone"
		};

		Buffer buf= new Buffer();

		for (int i= 0; i < 3; i++) {
			new Consumidor(buf, i, produzir[i].length()).start();
			new Produtor(buf, i, produzir[i]).start();
		}
	}
}
