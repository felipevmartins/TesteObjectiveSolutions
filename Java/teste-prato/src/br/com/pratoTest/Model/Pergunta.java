package br.com.pratoTest.Model;

import br.com.pratoTest.utils.FilaPerguntas;

public class Pergunta {
	private String pergunta = "O prato que você pensou é %s?";
	private Prato prato;
	private FilaPerguntas filaPerguntas = new FilaPerguntas(); 
	
	public Pergunta() {
	}
	
	public Pergunta(Prato prato) {
		this.prato = prato;
	}
	
	public String getPergunta() {
		return String.format(pergunta, prato.getNome());
	}
	public Prato getPrato() {
		return prato;
	}
	public void setPrato(Prato prato) {
		this.prato = prato;
	}

	public FilaPerguntas getFilaPerguntas() {
		return filaPerguntas;
	}

	public void setFilaPerguntas(FilaPerguntas filaPerguntas) {
		this.filaPerguntas = filaPerguntas;
	}

	
	
	
}
