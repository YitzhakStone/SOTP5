//
// nome do programa: EX_6_1.java
//
// programadores:
// Mateus Fernando          484555
// Vinicius Ponciano        482955
// Yitzhak Stone            478493
// data: 30/04/2015
// descricao: treinamento de threads.
// 

class LabSOEC_s213 extends Thread {
	private String palavra;

	public LabSOEC_s213(String palavra) {
		this.palavra= palavra;
        System.out.println("484555\t\tMateus Fernando");
        System.out.println("482955\t\tVinicius Ponciano");
        System.out.println("478493\t\tYitzhak Stone");
        System.out.println();
	}


	public void run() { // threads devem implementar o método run
		try {
			for(int i= 0; i < 1000; i++) {
				System.out.print(palavra + " ");
				if (palavra.equals("ping"))
				Thread.sleep(500);
				else Thread.sleep(100);
			}
		}
		catch (InterruptedException e) {
			return;
		} // levantada pelo sleep
	}
}

class EX_6_1 {
	public static void main(String [] args) {
		Thread t1= new LabSOEC_s213("ping");
		Thread t2= new LabSOEC_s213("PONG");
		t1.start();
		t2.start();
	}
}