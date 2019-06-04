package br.com.pratoTest.programa;
import javax.swing.JOptionPane;

import br.com.pratoTest.Model.Pergunta;
import br.com.pratoTest.Model.Prato;
import br.com.pratoTest.utils.FilaPerguntas;

public class Progama {
	
	private static FilaPerguntas fila = new FilaPerguntas();
	public static int finalizar = 0;
	public static int confirmation = 1;
	public static String perguntaNomePrato = "Qual prato você pensou?";
	public static String perguntaCaracPrato = "%s é _____, mas %s não.";
	
	public static void main(String[] args) {
		Inicializacao();
		Run();
		
	}

	private static void Run() {	
		fila.setCount(0);
		confirmation = 1;
		JOptionPane.showMessageDialog(null, "Pense em um prato que gosta", "Teste Prato", JOptionPane.QUESTION_MESSAGE);
		
		PercorrerFila(fila);
		
		
		Run();

	}

	private static void Inicializacao() {
		Pergunta perguntaMassa = new Pergunta(new Prato("Massa",""));
		perguntaMassa.setFilaPerguntas(new FilaPerguntas());
		perguntaMassa.getFilaPerguntas().push(new Pergunta(new Prato("Lasanha","")));
		fila.push(new Pergunta(new Prato("Bolo de Chocolate","")));
		fila.push(perguntaMassa);
	}

	private static void CriarNovaPergunta(FilaPerguntas filaAtual) {
		String nomePratoNovo = JOptionPane.showInputDialog(null, perguntaNomePrato);
		
		String caracPratoNovo = JOptionPane.showInputDialog(null, String.format(perguntaCaracPrato, nomePratoNovo, filaAtual.tail().getPrato().getNome()));
		
		if(nomePratoNovo != null || caracPratoNovo != null) {
			Prato novoPrato = new Prato(nomePratoNovo, caracPratoNovo);
			
			Pergunta novaPergunta = new Pergunta(novoPrato);
			
			filaAtual.push(novaPergunta);
			
			Run();
		}else {
			JOptionPane.showConfirmDialog(null, "Você não digitou o nome ou a caracteristica do Prato.", "Erro", JOptionPane.WARNING_MESSAGE);
		}
	}

	private static void PercorrerFila(FilaPerguntas filaAtual) {
		filaAtual.setCount(0);
		while(confirmation != 0) {
			confirmation = 1;
			if(filaAtual.size() <= filaAtual.getCount()) break;
			
			
			Pergunta pergunta = filaAtual.next();
			confirmation = JOptionPane.showConfirmDialog(null, pergunta.getPergunta(), "Confirm", JOptionPane.YES_NO_OPTION);	
			
			if((confirmation == 1 && filaAtual.size() == filaAtual.getCount()) ) {
				CriarNovaPergunta(filaAtual);
				break;
			} else if(confirmation == 0 && filaAtual.size() > filaAtual.getCount() && pergunta.getFilaPerguntas().size() > 0 ){
				confirmation = 1;
				PercorrerFila(pergunta.getFilaPerguntas());
				break;
			} else if(confirmation == 0 && (filaAtual.size() == filaAtual.getCount() || pergunta.getFilaPerguntas().size() == 0)) {
			
				JOptionPane.showMessageDialog(null, "Acertei de novo", "Teste Prato", JOptionPane.QUESTION_MESSAGE);
				break;
			}
			
		}
		
		
	}
	
	
}
